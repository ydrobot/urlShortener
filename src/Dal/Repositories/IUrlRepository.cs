using System;
using System.Threading.Tasks;
using Model.DalModel;

namespace Dal.Repositories
{
    public interface IUrlRepository
    {
        Task<string> CreateShortUrlAsync(CreateShortUrlInfo info);
        Task<UrlInfo[]> GetAllUrlsInfoAsync();
        Task<UrlInfo[]> GetUrlsInfoByUserIdAsync(Guid userId);
        Task<UrlInfo> GetUrlInfoByShortUrlAsync(string shortUrl);
        Task FollowUrlByIdAsync(int id);
        Task<int> GetMaxIdAsync();
    }
}