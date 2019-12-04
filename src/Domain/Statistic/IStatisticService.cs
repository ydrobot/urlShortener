using System.Threading.Tasks;
using Model;

namespace Domain.Statistic
{
    public interface IStatisticService
    {
        Task<UrlStatisticInfo[]> GetUrlStatisticAsync();
        Task<UrlStatisticInfo[]> GetUserUrlStatisticAsync();
    }
}