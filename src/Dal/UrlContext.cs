using Api.Configuration.Model;
using Microsoft.Extensions.Options;
using Model.DalModel;
using MongoDB.Driver;

namespace Dal
{
    public class UrlContext
    {
        private readonly IMongoDatabase _database;

        public UrlContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<UrlInfo> Urls => _database.GetCollection<UrlInfo>("Urls");
    }
}