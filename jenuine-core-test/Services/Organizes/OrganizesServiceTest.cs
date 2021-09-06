using Xunit;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Utils;
using Its.Jenuiue.Core.Models.Global;
using Its.Jenuiue.Core.Services.Organizes;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Services.Products
{
    public class OrganizesServiceTest
    {
        [Fact]
        public void OrganizesScenarioTest()
        {
            string orgId = "OrganizesScenarioTest";

            var db = DBUtils.CreateMockedMongoDb<MOrganize>();

            var svc = new ProductsService(db);
            svc.SetOrgId(orgId);

            var q = new QueryParam()
            {
                Limit = 0,
                Offset = 0
            };

            var p = new MProduct();
            svc.GetProducts(p, q);
            svc.GetProductById(new MProduct());
            svc.GetProductsCount();
            
            var lbl = new Label()
            {
                Name = "name",
                Value = "value"
            };

            var m = svc.AddProduct(new MProduct());
            m.Labels.Add(lbl);
            svc.UpdateProduct(m);

            svc.DeleteProduct(m);
        }
    }
}
