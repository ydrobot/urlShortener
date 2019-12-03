using System;
using System.Threading.Tasks;
using Model;

namespace Domain
{
    public interface IUrlService
    {
        Task<string> CreateShortUrlAsync(string url, Guid userId);
        Task<string> GetUrlByShortAsync(Guid shortUrl);
        Task<UrlStatisticInfo[]> GetUrlStatisticAsync();
        Task<UrlStatisticInfo[]> GetUserUrlStatisticAsync(Guid userId);
    }
}