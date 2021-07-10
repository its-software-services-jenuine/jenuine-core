using System;
using Xunit;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Utils;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.Products
{
    public class ProductActionsTest
    {
        [Fact]
        public void ProductScenarioActionTest()
        {
            string orgId = "ProductScenarioActionTest";

            var db = DBUtils.CreateMockedMongoDb<MProduct>();

            var addAct = new AddProductAction(db, orgId);
            var p1 = new MProduct() { ProductId = "0001" };
            var m = addAct.Apply<MProduct>(p1);
            Assert.NotEqual("", m.Id);

            var countAct = new GetProductCountAction(db, orgId);
            var count = countAct.Apply<MProduct>(new MProduct());

            Assert.Equal(1, count);

            var p2 = new MProduct() { ProductId = "0002" };
            p2 = addAct.Apply<MProduct>(p2);

            count = countAct.Apply<MProduct>(new MProduct());
            Assert.Equal(2, count);

            var queryAct = new GetProductsAction(db, orgId);
            var list = queryAct.Apply<MProduct>(new MProduct(), new QueryParam());
            Assert.Equal(2, list.Count);

            var delAct = new DeleteProductByIdAction(db, orgId);
            delAct.Apply<MProduct>(p2.Id);

            count = countAct.Apply<MProduct>(new MProduct());
            Assert.Equal(1, count); 

            var getByIdAct = new GetProductByIdAction(db, orgId);
            var p3 = getByIdAct.Apply<MProduct>(p1);
            Assert.Equal(p1.ProductId, p3.ProductId); 
        }

        [Fact]
        public void UpdateProductByIdActionTest()
        {
            string orgId = "UpdateProductByIdActionTest";

            var db = DBUtils.CreateMockedMongoDb<MProduct>();

            var addAct = new AddProductAction(db, orgId);
            var p1 = new MProduct() 
            { 
                ProductId = "UpdateProductByIdActionTestId",
                ProductName = "UpdateProductByIdActionTestName" 
            };
            var m = addAct.Apply<MProduct>(p1);
            m.ProductName = "UpdatedProductName";

            var updateByIdAct = new UpdateProductByIdAction(db, orgId);
            updateByIdAct.Apply<MProduct>(m);

            var getByIdAct = new GetProductByIdAction(db, orgId);
            var u = getByIdAct.Apply<MProduct>(m);

            Assert.Equal("UpdatedProductName", u.ProductName);
        }

        [Fact]
        public void GetProductByIdNothingActionTest()
        {
            string orgId = "GetProductByIdNothingActionTest";
            var db = DBUtils.CreateMockedMongoDb<MProduct>();

            var getByIdAct = new GetProductByIdAction(db, orgId);
            var p = getByIdAct.Apply<MProduct>(new MProduct());
            Assert.Null(p);

            var countAct = new GetProductCountAction(db, orgId);
            var count = countAct.Apply<MProduct>(new MProduct());
            Assert.Equal(0, count);

            var queryAct = new GetProductsAction(db, orgId);
            var list = queryAct.Apply<MProduct>(new MProduct(), new QueryParam());
            Assert.Empty(list);
        }


        [Fact]
        public void AddDuplicateProductsTest()
        {
            string orgId = "AddDuplicateProductsTest";
            var db = DBUtils.CreateMockedMongoDb<MProduct>();

            var addAct = new AddProductAction(db, orgId);
            var p1 = new MProduct() 
            { 
                ProductId = "UpdateProductByIdActionTestId",
                ProductName = "UpdateProductByIdActionTestName" 
            };
            var m = addAct.Apply<MProduct>(p1);

            Assert.Throws<MongoDB.Driver.MongoWriteException>(() => {
                addAct.Apply<MProduct>(m);
            });
        }
    }
}
