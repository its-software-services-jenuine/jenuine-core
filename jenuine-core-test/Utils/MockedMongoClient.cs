using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;
using System.Threading;
using System.Threading.Tasks;

namespace Its.Jenuiue.Core.Utils
{
    public class MockedMongoClient : MongoClientBase
    {
        public IMongoDatabase Database { get; set; }

        public override MongoClientSettings Settings { get; }
        public override ICluster Cluster { get; }

        public override Task DropDatabaseAsync(string name, CancellationToken cancellationToken = default)
        {
            return null;
        }

        public override IMongoDatabase GetDatabase(string name, MongoDatabaseSettings settings = null)
        {
            return Database;
        }

        public override Task<IAsyncCursor<BsonDocument>> ListDatabasesAsync(CancellationToken cancellationToken = default)
        {
            return null;
        }
    }
}