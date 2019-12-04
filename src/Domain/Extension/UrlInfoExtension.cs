using System.Collections.Generic;
using System.Linq;
using Model;
using Model.DalModel;

namespace Domain.Extension
{
    public static class UrlInfoExtension
    {
        public static UrlStatisticInfo[] ToUrlStatisticInfos(this IEnumerable<UrlInfo> infos, string serviceName)
        {
            return infos.Select(s => new UrlStatisticInfo
            {
                Url = s.Url,
                UrlShort = serviceName + s.ShortUrl,
                Followed = s.FollowedAt.Count
            }).ToArray();
        }
    }
}