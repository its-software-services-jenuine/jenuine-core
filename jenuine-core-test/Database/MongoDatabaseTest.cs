using Xunit;
using Moq;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Database
{
    public class MongoDatabaseTest
    {
        [Fact]
        public void Test1()
        {
            var dbMock = new Mock<IMongoDatabase>();
            var db = dbMock.Object;

            var cli = new Mock<IMongoClient>();
            cli.Setup(x => x.GetDatabase(It.IsAny<string>(), It.IsAny<MongoDatabaseSettings>())).Returns(db);

            var mongoDb = new MongoDatabase(cli.Object);
        }
    }
}
