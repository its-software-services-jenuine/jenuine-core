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
/*
        [Fact]
        public void GetAssetsTest()
        {
            var myassets = new AssetsService(mydatabase);
            var mas = new MAsset();
            var que = new QueryParam()
            {
                Offset = 0,
                Limit = 0

            };
            var mylist = myassets.GetAssets(mas,que);
        }
        */
        /*
        [Fact]
        public void AddAssetTest()
        {
            var assets = new AssetsService(mydatabase);
            var masset = new MAsset()
            {
                PinNo = "00101",
                SerialNo = "4CE0460D0G"

            };
            var result = assets.AddAsset(masset);
            
        }
        */
        
        

    }
}
