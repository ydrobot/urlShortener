using System;
using System.Threading.Tasks;
using Model.DalModel;

namespace Dal.Repositories
{
    public interface IUrlRepository
    {
        Task<Guid> CreateShortUrlAsync(CreateShortUrlInfo info);
        Task<UrlInfo[]> GetAllUrlsInfoAsync();
        Task<UrlInfo[]> GetUrlsInfoByUserIdAsync(Guid userId);
        Task<UrlInfo> GetUrlInfoByShortUrlAsync(Guid shortUrl);
        Task FollowUrlByIdAsync(Guid shortUrl);
    }
}