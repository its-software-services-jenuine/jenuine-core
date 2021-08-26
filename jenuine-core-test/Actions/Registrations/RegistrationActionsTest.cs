using System;
using Xunit;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Utils;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.Registration
{
    public class RegistrationActionsTest
    {
        
        [Fact]
        public void RegistrationScenarioActionTest()
        {
            string orgId = "RegistrationScenarioActionTest";

            var db = DBUtils.CreateMockedMongoDb<MRegistration>();

            var addAct = new AddRegistrationAction(db, orgId);
            
            var p1 = new MRegistration() { RegistrationId = "0001" };
            var m = addAct.Apply<MRegistration>(p1);
            Assert.NotEqual("", m.Id);

            var countAct = new GetRegistrationCountAction(db, orgId);
            var count = countAct.Apply<MRegistration>(new MRegistration());

            Assert.Equal(1, count);

            var p2 = new MRegistration() { RegistrationId = "0002" };
            p2 = addAct.Apply<MRegistration>(p2);

            count = countAct.Apply<MRegistration>(new MRegistration());
            Assert.Equal(2, count);

            var queryAct = new GetRegistrationAction(db, orgId);
            var list = queryAct.Apply<MRegistration>(new MRegistration(), new QueryParam());
            Assert.Equal(2, list.Count);

            var delAct = new DeleteRegistrationByIdAction(db, orgId);
            delAct.Apply<MRegistration>(p2.Id);

            count = countAct.Apply<MRegistration>(new MRegistration());
            Assert.Equal(1, count); 

            var getByIdAct = new GetRegistrationByIdAction(db, orgId);
            var p3 = getByIdAct.Apply<MRegistration>(p1);
            Assert.Equal(p1.RegistrationId, p3.RegistrationId); 
        }


        [Fact]
        public void GetRegistrationByIdNothingActionTest()
        {
            string orgId = "GetRegistrationByIdNothingActionTest";
            var db = DBUtils.CreateMockedMongoDb<MRegistration>();

            var getByIdAct = new GetRegistrationByIdAction(db, orgId);
            var p = getByIdAct.Apply<MRegistration>(new MRegistration());
            Assert.Null(p);

            var countAct = new GetRegistrationCountAction(db, orgId);
            var count = countAct.Apply<MRegistration>(new MRegistration());
            Assert.Equal(0, count);

            var queryAct = new GetRegistrationAction(db, orgId);
            var list = queryAct.Apply<MRegistration>(new MRegistration(), new QueryParam());
            Assert.Empty(list);
        }


        [Fact]
        public void AddDuplicateRegistrationTest()
        {
            string orgId = "AddDuplicateRegistrationTest";
            var db = DBUtils.CreateMockedMongoDb<MRegistration>();

            var addAct = new AddRegistrationAction(db, orgId);
            var p1 = new MRegistration() 
            { 
                RegistrationId = "UpdateRegistrationByIdActionTestId",
                RegistrationName = "UpdateRegistrationByIdActionTestName" 
            };
            var m = addAct.Apply<MRegistration>(p1);

            Assert.Throws<MongoDB.Driver.MongoWriteException>(() => {
                addAct.Apply<MRegistration>(m);
            });
        }
        
    }
}
