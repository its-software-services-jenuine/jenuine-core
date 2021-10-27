
using Xunit;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Utils;
using Its.Jenuiue.Core.Models.Global;
using Its.Jenuiue.Core.Services.Organizes;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Services.Customers
{
    public class CustomersServiceTest
    {
        [Fact]
        public void CustomersScenarioTest()
        {
            string orgId = "CustomersScenarioTest";

            var db = DBUtils.CreateMockedMongoDb<MCustomer>();

            var svc = new CustomersService(db);
            svc.SetOrgId(orgId);

            var q = new QueryParam()
            {
                Limit = 0,
                Offset = 0
            };

            var p = new MCustomer();
            svc.GetCustomer(p, q);
            svc.GetCustomerById(new MCustomer());
            svc.GetCustomerCount();
            
            var lbl = new Label()
            {
                Name = "name",
                Value = "value"
            };

            var m = svc.AddCustomer(new MCustomer());
            m.Labels.Add(lbl);           
            svc.UpdateCustomer(m);
            svc.DeleteCustomerById(m);
            svc.DeleteCustomerAll();
        }
    }
}

