using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Configuration.Model;
using Dal.Repositories;
using Microsoft.Extensions.Options;
using Model;
using Model.DalModel;

namespace Domain
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _repository;
        private readonly string _serviceName;

        public UrlService(IOptions<ServiceSettings> options, IUrlRepository repository)
        {
            _serviceName = options.Value.ServiceName;
            _repository = repository;
        }

        public async Task<string> CreateShortUrlAsync(string url, Guid userId)
        {
            var maxId = await _repository.GetMaxIdAsync() + 1;
            var shortUrl = await _repository.CreateShortUrlAsync(new CreateShortUrlInfo
            {
                Id = maxId,
                Url = url,
                UserId = userId,
                ShortUrl = GenerateShortUrlService.Encode(maxId)
            });
            return _serviceName + shortUrl;
        }

        public async Task<string> GetUrlByShortAsync(string shortUrl)
        {
            var urlInfo = await _repository.GetUrlInfoByShortUrlAsync(shortUrl);
            if (urlInfo == null)
            {
                //todo: custom exception
                throw new ArgumentNullException($"Short url {shortUrl} not found");
            }

            await _repository.FollowUrlByIdAsync(urlInfo.Id);
            return urlInfo.Url;
        }

        public async Task<UrlStatisticInfo[]> GetUrlStatisticAsync()
        {
            var urlInfo = await _repository.GetAllUrlsInfoAsync();
            return urlInfo.Select(s => new UrlStatisticInfo
            {
                Url = s.Url,
                UrlShort = _serviceName + s.ShortUrl,
                Followed = s.FollowedAt.Count
            }).ToArray();
        }

        public async Task<UrlStatisticInfo[]> GetUserUrlStatisticAsync(Guid userId)
        {
            var urlInfo = await _repository.GetUrlsInfoByUserIdAsync(userId);
            return urlInfo.Select(s => new UrlStatisticInfo
            {
                Url = s.Url,
                UrlShort = _serviceName + s.ShortUrl,
                Followed = s.FollowedAt.Count
            }).ToArray();
        }
    }
}