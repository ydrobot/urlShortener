using System;
using System.Threading.Tasks;
using Api.Configuration.Model;
using Dal.Repositories;
using Domain.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Model.DalModel;

namespace Domain.Url
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _repository;
        private readonly string _serviceName;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public UrlService(IOptions<ServiceSettings> options, IUrlRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _serviceName = options.Value.ServiceName;
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> CreateShortUrlAsync(string url)
        {
            var maxId = await _repository.GetMaxIdAsync() + 1;
            var shortUrl = await _repository.CreateShortUrlAsync(new CreateShortUrlInfo
            {
                Id = maxId,
                Url = url,
                UserId = _httpContextAccessor.HttpContext.GetURLSH(),
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
    }
}