using System;
using Xunit;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Utils;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.Assets
{
    public class AssetActionsTest
    {
        /*
        [Fact]
        public void AssetScenarioActionTest()
        {
            string orgId = "AssetScenarioActionTest";

            var db = DBUtils.CreateMockedMongoDb<MAsset>();

            var addAct = new AddAssetAction(db, orgId);
            var p1 = new MAsset() { ProductId = "0001" };
            var m = addAct.Apply<MAsset>(p1);
            Assert.NotEqual("", m.Id);

            var countAct = new GetAssetCountAction(db, orgId);
            var count = countAct.Apply<MAsset>(new MAsset());

            Assert.Equal(1, count);

            var p2 = new MAsset() { ProductId = "0002" };
            p2 = addAct.Apply<MAsset>(p2);

            count = countAct.Apply<MAsset>(new MAsset());
            Assert.Equal(2, count);

            var queryAct = new GetAssetCountAction(db, orgId);
            var list = queryAct.Apply<MAsset>(new MAsset());           
            Assert.Equal(2, list);

            var delAct = new DeleteAssetByIdAction(db, orgId);
            delAct.Apply<MAsset>(p2.Id);

            count = countAct.Apply<MAsset>(new MAsset());
            Assert.Equal(1, count); 

            var getByIdAct = new GetAssetByIdAction(db, orgId);
            var p3 = getByIdAct.Apply<MAsset>(p1);
            Assert.Equal(p1.ProductId, p3.ProductId); 
        }
        
        [Fact]
        public void UpdateAssetsByIdActionTest()
        {
            string orgId = "UpdateAssetsByIdActionTest";

            var db = DBUtils.CreateMockedMongoDb<MAsset>();

            var addAct = new AddAssetAction(db, orgId);
            var p1 = new MAsset() 
            { 
                AssetId = "UpdateAssetsByIdActionTestId",
                AssetName = "UpdateAssetsByIdActionTestName" 
            };
            var m = addAct.Apply<MAsset>(p1);
            m.AssetName = "UpdatedAssetsName";

            var updateByIdAct = new UpdateAssetByIdAction(db, orgId);
            updateByIdAct.Apply<MAsset>(m);

            var getByIdAct = new GetAssetByIdAction(db, orgId);
            var u = getByIdAct.Apply<MAsset>(m);

            Assert.Equal("UpdatedAssetsName", u.AssetName);
        }
        

        [Fact]
        public void GetAssetByIdNothingActionTest()
        {
            string orgId = "GetAssetByIdNothingActionTest";
            var db = DBUtils.CreateMockedMongoDb<MAsset>();

            var getByIdAct = new GetAssetCountAction(db, orgId);
            var p = getByIdAct.Apply<MAsset>(new MAsset());
            Assert.Null(p);

            var countAct = new GetAssetCountAction(db, orgId);
            var count = countAct.Apply<MAsset>(new MAsset());
            Assert.Equal(0, count);

            var queryAct = new GetAssetCountAction(db, orgId);
            var list = queryAct.Apply<MAsset>(new MAsset());
            Assert.Empty(list.ToString());
        }
        [Fact]
        public void AddDuplicateAssetTest()
        {
            string orgId = "AddDuplicateAssetTest";
            var db = DBUtils.CreateMockedMongoDb<MAsset>();

            var addAct = new AddAssetAction(db, orgId);
            var p1 = new MAsset() 
            { 
                AssetId = "UpdateAssetByIdActionTestId",
                AssetName = "UpdateAssetByIdActionTestName" 
            };
            var m = addAct.Apply<MAsset>(p1);

            Assert.Throws<MongoDB.Driver.MongoWriteException>(() => {
                addAct.Apply<MAsset>(m);
            });
        }
        */
        
        
    }
}
