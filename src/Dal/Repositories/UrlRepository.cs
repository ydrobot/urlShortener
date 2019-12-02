using System;
using System.Threading.Tasks;
using Api.Configuration.Model;
using Microsoft.Extensions.Options;
using Model.DalModel;

namespace Dal.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly UrlContext _context;
        
        public UrlRepository(IOptions<MongoSettings> settings)
        {
            _context = new UrlContext(settings);
        }
        
        public Task<string> CreateShortUrlAsync(CreateShortUrlInfo info)
        {
            throw new NotImplementedException();
        }

        public Task<UrlInfo[]> GetAllUrlsInfoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUrlByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UrlInfo[]> GetUrlsInfoByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<UrlInfo> GetUrlInfoByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task FollowUrlByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}