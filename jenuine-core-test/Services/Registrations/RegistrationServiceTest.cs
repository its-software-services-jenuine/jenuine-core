using Xunit;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Utils;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Services.Registration
{
    public class RegistrationServiceTest
    {
        [Fact]
        public void RegistrationServiceScenarioTest()
        {
            string orgId = "RegistrationServiceScenarioTest";

            var db = DBUtils.CreateMockedMongoDb<MRegistration>();

            var svc = new RegistrationService(db);
            svc.SetOrgId(orgId);

            var q = new QueryParam()
            {
                Limit = 0,
                Offset = 0
            };

            var p = new MRegistration();
            svc.GetRegistration(p, q);
            svc.GetRegistrationById(new MRegistration());
            svc.GetRegistrationCount();
            
            var lbl = new Label()
            {
                Name = "name",
                Value = "value"
            };

            var m = svc.AddRegistration(new MRegistration());
            m.Labels.Add(lbl);
            svc.DeleteRegistrationById(m);
        }
    }
}
