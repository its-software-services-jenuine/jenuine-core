using Mongo2Go;
using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
namespace Its.Jenuiue.Core.Utils
{
    public static class DBUtils
    {
        private static MongoDbRunner runner = MongoDbRunner.Start(
            binariesSearchPatternOverride : "/usr/bin/*",
            binariesSearchDirectory : "");

        private static MongoClient client = new MongoClient(runner.ConnectionString);

        public static IDatabase CreateMockedMongoDb<T>()
        {
            var m = new MongoDatabase(client);
            return m;
        }
    }
}
