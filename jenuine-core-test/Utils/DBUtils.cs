using Moq;
using MongoDB.Driver;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Utils
{
    public static class DBUtils
    {
        public static IDatabase CreateMockedMongoDb<T>()
        {
            var idmmMocked = new Mock<IMongoIndexManager<T>>();

            var collMocked = new Mock<IMongoCollection<T>>();
            collMocked.Setup(x => x.Indexes).Returns(idmmMocked.Object);

            var dbMock = new Mock<IMongoDatabase>();
            dbMock.Setup( x => x.GetCollection<T>(It.IsAny<string>(), It.IsAny<MongoCollectionSettings>()))
                .Returns(collMocked.Object);

            var cli = new Mock<IMongoClient>();
            cli.Setup(x => x.GetDatabase(It.IsAny<string>(), It.IsAny<MongoDatabaseSettings>())).Returns(dbMock.Object);

            var m = new MongoDatabase(cli.Object);

            return m;
        }
    }
}
