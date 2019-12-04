using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<string> CreateShortUrlAsync(CreateShortUrlInfo info)
        {
            var urlInfo = new UrlInfo
            {
                Id = info.Id,
                Url = info.Url,
                UserId = info.UserId,
                ShortUrl = info.ShortUrl,
                CreatedAt = DateTime.UtcNow,
                FollowedAt = new List<DateTime>()
            };

            await _context.Urls.InsertOneAsync(urlInfo);
            return urlInfo.ShortUrl;
        }

        public async Task<UrlInfo[]> GetAllUrlsInfoAsync()
        {
            var urls = await _context.Urls.Find(_ => true).ToListAsync();
            return urls != null
                       ? urls.ToArray()
                       : new UrlInfo[] { };
        }

        public async Task<UrlInfo[]> GetUrlsInfoByUserIdAsync(Guid userId)
        {
            return (await _context.Urls.Find(f => f.UserId == userId).ToListAsync())?.ToArray();
        }

        public async Task<UrlInfo> GetUrlInfoByShortUrlAsync(string shortUrl)
        {
            return await _context.Urls
                                 .Find(f => f.ShortUrl == shortUrl)
                                 .FirstOrDefaultAsync();
        }

        public async Task FollowUrlByIdAsync(int id)
        {
            var filter = Builders<UrlInfo>.Filter.Eq(e => e.Id, id);
            var update = Builders<UrlInfo>.Update.Push(e => e.FollowedAt, DateTime.UtcNow);
            await _context.Urls.FindOneAndUpdateAsync(filter, update);
        }

        public async Task<int> GetMaxIdAsync()
        {
            var urls = await GetAllUrlsInfoAsync();
            return urls == null || !urls.Any() ? 0 : urls.Max(m => m.Id);
        }
    }
}