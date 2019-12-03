using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Configuration.Model;
using Microsoft.Extensions.Options;
using Model.DalModel;
using MongoDB.Driver;

namespace Dal.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly UrlContext _context;

        public UrlRepository(IOptions<MongoSettings> settings)
        {
            _context = new UrlContext(settings);
        }

        public async Task<Guid> CreateShortUrlAsync(CreateShortUrlInfo info)
        {
            var urlInfo = new UrlInfo
            {
                Url = info.Url,
                UserId = info.UserId,
                ShortUrl = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                FollowedAt = new List<DateTime>()
            };

            await _context.Urls.InsertOneAsync(urlInfo);
            return urlInfo.ShortUrl;
        }

        public async Task<UrlInfo[]> GetAllUrlsInfoAsync()
        {
            return (await _context.Urls.Find(_ => true).ToListAsync())?.ToArray();
        }

        public async Task<UrlInfo[]> GetUrlsInfoByUserIdAsync(Guid userId)
        {
            return (await _context.Urls.Find(f => f.UserId == userId).ToListAsync())?.ToArray();
        }

        public async Task<UrlInfo> GetUrlInfoByShortUrlAsync(Guid shortUrl)
        {
            return await _context.Urls
                                 .Find(f => f.ShortUrl == shortUrl)
                                 .FirstOrDefaultAsync();
        }

        public async Task FollowUrlByIdAsync(Guid shortUrl)
        {
            var filter = Builders<UrlInfo>.Filter.Eq(e => e.ShortUrl, shortUrl);
            var update = Builders<UrlInfo>.Update.Push(e => e.FollowedAt, DateTime.UtcNow);
            await _context.Urls.FindOneAndUpdateAsync(filter, update);
        }
    }
}