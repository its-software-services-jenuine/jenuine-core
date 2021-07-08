using Xunit;
using Its.Jenuiue.Core.Utils;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.Products
{
    public class ProductActionTest
    {
        private string tableName = "products";
        private string orgId = "mocked_orgid";

        [Fact]
        public void AddProductActionTest()
        {
            var db = DBUtils.CreateMockedMongoDb<MProduct>();

            var act = new AddProductAction(db, orgId);
            string collName = act.GetDocumentCollectionName();
            var m = act.Apply<MProduct>(new MProduct());

            Assert.Equal(tableName, collName);
            Assert.NotEqual("", m.Id);
        }

        [Fact]
        public void DeleteProductByIdActionTest()
        {
            var db = DBUtils.CreateMockedMongoDb<MProduct>();

            var act = new DeleteProductByIdAction(db, orgId);
            string collName = act.GetDocumentCollectionName();
            var m = act.Apply<MProduct>("mocked_product_id");

            Assert.Equal(tableName, collName);
            //Assert.Null(m);
        }

        [Fact]
        public void GetProductsActionTest()
        {
            var db = DBUtils.CreateMockedMongoDb<MProduct>();

            var act = new GetProductsAction(db, orgId);
            string collName = act.GetDocumentCollectionName();
            var m = act.Apply<MProduct>(new MProduct(), new QueryParam());

            Assert.Equal(tableName, collName);
            Assert.Null(m);
        }        
    }
}
