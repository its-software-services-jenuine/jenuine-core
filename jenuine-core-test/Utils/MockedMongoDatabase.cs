using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace Its.Jenuiue.Core.Utils
{
    public class MockedMongoDatabase : MongoDatabaseBase
    {
        public object Collection { get; set; }

        public override MongoDatabaseSettings Settings { get; }
        public override IMongoClient Client { get; }
        public override DatabaseNamespace DatabaseNamespace { get; }

        public override Task CreateCollectionAsync(string name, CreateCollectionOptions options = null, CancellationToken cancellationToken = default)
        {
            return null;
        }

        public override Task DropCollectionAsync(string name, CancellationToken cancellationToken = default)
        {
            return null;
        }

        public override IMongoCollection<TDocument> GetCollection<TDocument>(string name, MongoCollectionSettings settings = null)
        {
            return (IMongoCollection<TDocument>) Collection;
        }

        public void SetCollection<TDocument>(IMongoCollection<TDocument> coll)
        {
            Collection = coll;
        }

        public override Task<IAsyncCursor<BsonDocument>> ListCollectionsAsync(ListCollectionsOptions options = null, CancellationToken cancellationToken = default)
        {
            return null;
        }

        public override Task RenameCollectionAsync(string oldName, string newName, RenameCollectionOptions options = null, CancellationToken cancellationToken = default)
        {
            return null;
        }

        public override Task<TResult> RunCommandAsync<TResult>(Command<TResult> command, ReadPreference readPreference = null, CancellationToken cancellationToken = default)
        {
            return null;
        }        
    }
}