using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Actions.Assets;
using Its.Jenuiue.Core.Services.Products;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Services.Registration;

namespace jenuine_core_console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var connStr = Environment.GetEnvironmentVariable("ConnectionString");

            var conn = new MongoClient(connStr);
            var db = new MongoDatabase(conn);
/*
            var svc = new ProductsService(db);
            svc.SetOrgId("console-test");

            var products = svc.GetProducts(new MProduct(), new QueryParam());
            //Console.WriteLine(products.ToJson(new JsonWriterSettings { Indent = true }));

            var prd = new MProduct()
            {
                ProductId = DateTime.Now.TimeOfDay.ToString(),
                ProductName = "Aut Test product name"
            };
*/
/*
            string orgId = "TestOrgID-test1";
            var addAct = new AddAssetAction(db, orgId);
            var p1 = new MAsset() 
            { 
                AssetId = "UpdateAssetByIdActionTestId",
                AssetName = "UpdateAssetByIdActionTestName" 
            };
            var m = addAct.Apply<MAsset>(p1);
            m.AssetName = "UpdatedAssetName";
Console.WriteLine("DEBUG0 new generated id={0}, name={1}", m.Id, m.AssetName);
            var updateByIdAct = new UpdateAssetByIdAction(db, orgId);
            updateByIdAct.Apply<MAsset>(m);

            var getByIdAct = new GetAssetByIdAction(db, orgId);
            var u = getByIdAct.Apply<MAsset>(m);
Console.WriteLine("DEBUG1 get id={0}, name={1}", u.Id, u.AssetName);
            //Console.WriteLine(u.AssetName);
            */
            var svc = new RegistrationService(db);           
            var mregistration = new MRegistration()
            {
                RegistrationId = DateTime.Now.ToString(),
            };
                        
            svc.SetOrgId("TestRegistration");
            //var sd = svc.AddRegistration(mregistration);
            var getregistration = svc.GetRegistration(new MRegistration(), new QueryParam());
            //var getregisid = svc.GetRegistrationById(mregistration);           
            //Console.WriteLine(getregisid.ToJson(new JsonWriterSettings { Indent = true }));
            Console.WriteLine(getregistration.ToJson(new JsonWriterSettings { Indent = true }));
            svc.DeleteRegistration(mregistration);
            
            //Console.WriteLine(deleteregis.ToJson(new JsonWriterSettings { Indent = true }));
            //Console.WriteLine(sd.ToJson(new JsonWriterSettings { Indent = true }));
            // Console.WriteLine(newsvc.ToJson(new JsonWriterSettings { Indent = true }));
            //var getregistration = svc.GetRegistration(new MRegistration(), new QueryParam());
            

             
            //svc.AddProduct(prd);

            //var cnt = svc.GetProductsCount();
            //Console.WriteLine("Product count is [{0}]", cnt);

            //prd = svc.GetProductById(new MProduct() { Id = "60fff755965eef8f32270865" } );
            //Console.WriteLine(prd.ToJson(new JsonWriterSettings { Indent = true }));
        }
    }
}
