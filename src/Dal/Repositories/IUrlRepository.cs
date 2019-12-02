using System;
using System.Threading.Tasks;
using Model.DalModel;

namespace Dal.Repositories
{
    public interface IUrlRepository
    {
        Task<string> CreateShortUrlAsync(CreateShortUrlInfo info);
        Task<UrlInfo[]> GetAllUrlsInfoAsync();
        Task<string> GetUrlByIdAsync(string id);
        Task<UrlInfo[]> GetUrlsInfoByUserIdAsync(Guid userId);
        Task<UrlInfo> GetUrlInfoByIdAsync(string id);
        Task FollowUrlByIdAsync(string id);
    }
}