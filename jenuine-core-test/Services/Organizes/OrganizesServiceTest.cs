
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

            var svc = new OrganizesService(db);
            svc.SetOrgId(orgId);

            var q = new QueryParam()
            {
                Limit = 0,
                Offset = 0
            };

            var p = new MOrganize();
            svc.GetOrganize(p, q);
            svc.GetOrganizeById(new MOrganize());
            svc.GetOrganizeCount();
            
            var lbl = new Label()
            {
                Name = "name",
                Value = "value"
            };

            var m = svc.AddOrganize(new MOrganize());
            m.Labels.Add(lbl);
            svc.UpdateOrganize(m);

            svc.DeleteOrganizeById(m);
            svc.DeleteOrganizeAll();
        }
    }
}

