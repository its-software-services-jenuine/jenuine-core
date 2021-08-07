using System;
using Xunit;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Utils;
using Its.Jenuiue.Core.Models.Organization;


namespace Its.Jenuiue.Core.Services.Assets
{
    public class AssetServiceTest
    {
        private IDatabase mydatabase;
        [Fact]
        public void SetOrgidTest()
        {
            AssetsService myser = new AssetsService(mydatabase);
            string id = "blank";
            myser.SetOrgId(id);
        }
        
        [Fact]
        public void AssetServiceScenarioTest()
        {
            string orgId = "AssetServiceScenarioTest";

            var db = DBUtils.CreateMockedMongoDb<MAsset>();

            var svc = new AssetsService(db);
            svc.SetOrgId(orgId);

            var q = new QueryParam()
            {
                Limit = 0,
                Offset = 0
            };

            var p = new MAsset();
            svc.GetAssets(p, q);
            svc.GetAssetById(new MAsset());
            svc.GetAssetsCount();
            
            var lbl = new Label()
            {
                Name = "name",
                Value = "value"
            };

            var m = svc.AddAsset(new MAsset());
            m.Labels.Add(lbl);
            svc.UpdateAsset(m);
            svc.UpdateAssetRegisterFlag(m);
            svc.DeleteAsset(m);
        }
    }
}
