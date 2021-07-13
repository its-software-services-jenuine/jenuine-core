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
    public static class Program
    {
        public static void Main(string[] args)
        {
            var connStr = Environment.GetEnvironmentVariable("ConnectionString");

            var conn = new MongoClient(connStr);
            var db = new MongoDatabase(conn);

            var svc = new ProductsService(db);
            svc.SetOrgId("console-test");

            var products = svc.GetProducts(new MProduct(), new QueryParam());
            Console.WriteLine(products.ToJson(new JsonWriterSettings { Indent = true }));
        }
    }
}
