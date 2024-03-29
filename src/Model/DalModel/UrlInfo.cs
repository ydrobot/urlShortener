using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.DalModel
{
    public class UrlInfo
    {
        [BsonId]
        // standard BSonId generated by MongoDb
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public string ShortUrl { get; set; }

        public string Url { get; set; }

        [BsonDateTimeOptions] public DateTime CreatedAt { get; set; }

        [BsonDateTimeOptions] public List<DateTime> FollowedAt { get; set; }
    }
}