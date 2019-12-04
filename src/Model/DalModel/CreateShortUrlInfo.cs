using System;

namespace Model.DalModel
{
    public class CreateShortUrlInfo
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
    }
}