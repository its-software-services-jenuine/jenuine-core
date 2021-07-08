using Xunit;
using Moq;
using MongoDB.Driver;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Database
{
    public class MongoDatabaseTest
    {
        [Fact]
        public void CreateMongoDatabaseTest()
        {
            var dbMock = new Mock<IMongoDatabase>();
            var db = dbMock.Object;

            var cli = new Mock<IMongoClient>();
            cli.Setup(x => x.GetDatabase(It.IsAny<string>(), It.IsAny<MongoDatabaseSettings>())).Returns(db);

            var mongoDb = new MongoDatabase(cli.Object);

            mongoDb.GetOrganizeDb("mocked_org");
            mongoDb.GetCollectionGlobal<MProduct>("mocked_coll_name");
        }
    }
}
