using Xunit;
using Moq;
using MongoDB.Driver;
using Its.Jenuiue.Core.Actions;
using Its.Jenuiue.Core.Utils;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.Products
{
    public class AddProductActionTest
    {
        [Fact]
        public void AddProductActionCreateTest()
        {
            var db = DBUtils.CreateMockedMongoDb<MProduct>();

            var act = new AddProductAction(db, "mocked_orgid");
            string collName = act.GetDocumentCollectionName();

            var m = act.Apply<MProduct>(new MProduct());

            Assert.Equal("products", collName);
            Assert.NotEqual("", m.Id);
        }
    }
}
