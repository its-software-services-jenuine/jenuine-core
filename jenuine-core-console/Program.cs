using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Services.Products;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Models;

namespace jenuine_core_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = Environment.GetEnvironmentVariable("ConnectionString");

            var conn = new MongoClient(connStr);
            var db = new MongoDatabase(conn);

            var svc = new ProductsService(db);
            svc.SetOrgId("console-test");
/*
            var prd = new MProduct()
            {
                ProductId = "0002",
                ProductName = "Test-add-core-001",
                Description = "This is test add from console"
            };
            svc.AddProduct(prd);
*/
            var products = svc.GetProducts(new MProduct(), new QueryParam());
            products.ForEach(m => Console.WriteLine(m.ToJson(new JsonWriterSettings { Indent = true })));
        }
    }
}
