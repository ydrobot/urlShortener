using System;

namespace Model.DalModel
{
    public class CreateShortUrlInfo
    {
        public Guid UserId { get; set; }
        public string Url { get; set; }
    }
}