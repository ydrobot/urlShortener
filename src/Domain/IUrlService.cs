using System;
using System.Threading.Tasks;
using Model;

namespace Domain
{
    public interface IUrlService
    {
        Task<string> CreateShortUrlAsync(string url);
        Task<string> GetUrlByShortAsync(string shortUrl);
        Task<UrlStatisticInfo[]> GetUrlStatisticAsync();
        Task<UrlStatisticInfo[]> GetUserUrlStatisticAsync();
    }
}