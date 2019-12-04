using System.Threading.Tasks;
using Api.Configuration.Model;
using Dal.Repositories;
using Domain.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Model;

namespace Domain.Statistic
{
    public class StatisticService : IStatisticService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlRepository _repository;
        private readonly string _serviceName;

        public StatisticService(IHttpContextAccessor httpContextAccessor, IUrlRepository repository, IOptions<ServiceSettings> options)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
            _serviceName = options.Value.ServiceName;
        }

        public async Task<UrlStatisticInfo[]> GetUrlStatisticAsync()
        {
            var urlInfo = await _repository.GetAllUrlsInfoAsync();
            return urlInfo.ToUrlStatisticInfos(_serviceName);
        }

        public async Task<UrlStatisticInfo[]> GetUserUrlStatisticAsync()
        {
            var urlInfo = await _repository.GetUrlsInfoByUserIdAsync(_httpContextAccessor.HttpContext.GetURLSH());
            return urlInfo.ToUrlStatisticInfos(_serviceName);
        }
    }
}