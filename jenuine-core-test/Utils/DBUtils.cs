using System.Collections.Generic;
using Moq;
using MongoDB.Driver;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Utils
{
    public static class DBUtils
    {
        public static IDatabase CreateMockedMongoDb<T>()
        {
            //var a = new MongoCollectionBase<T>();
            //var b = new MongoIndexManagerBase<T>();
            //var c = new MongoDatabaseBase();
            //var d = new MongoClientBase();

            var dbMocked = new MockedMongoDatabase();
            dbMocked.SetCollection<T>(new MockedMongoCollection<T>());

            var clientMocked = new MockedMongoClient();
            clientMocked.Database = dbMocked;

            var m = new MongoDatabase(clientMocked);

            return m;
        }
    }
}
