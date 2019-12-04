using System.Threading.Tasks;

namespace Domain.Url
{
    public interface IUrlService
    {
        Task<string> CreateShortUrlAsync(string url);
        Task<string> GetUrlByShortAsync(string shortUrl);
    }
}