
using System;
using Xunit;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Utils;
using Its.Jenuiue.Core.Models.Global;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.Organizes
{
    public class OrganizesActionsTest
    {
        [Fact]
        public void OrganizesScenarioActionTest()
        {
            string orgId = "OrganizesScenarioActionTest";

            var db = DBUtils.CreateMockedMongoDb<MOrganize>();

            var addAct = new AddOrganizesAction(db, orgId);
            var p1 = new MOrganize() { OrganizeId = "0001" };
            var m = addAct.Apply<MOrganize>(p1);
            Assert.NotEqual("", m.Id);

            var countAct = new GetOrganizesCountAction(db, orgId);
            var count = countAct.Apply<MOrganize>(new MOrganize());

            Assert.Equal(1, count);

            var p2 = new MOrganize() { OrganizeId = "0002" };
            p2 = addAct.Apply<MOrganize>(p2);

            count = countAct.Apply<MOrganize>(new MOrganize());
            Assert.Equal(2, count);

            var queryAct = new GetOrganizesAction(db, orgId);
            var list = queryAct.Apply<MOrganize>(new MOrganize(), new QueryParam());
            Assert.Equal(2, list.Count);

            var delAct = new DeleteOrganizesByIdAction(db, orgId);
            delAct.Apply<MOrganize>(p2.Id);

            count = countAct.Apply<MOrganize>(new MOrganize());
            Assert.Equal(1, count); 

            var getByIdAct = new GetOrganizesByIdAction(db, orgId);
            var p3 = getByIdAct.Apply<MOrganize>(p1);
            Assert.Equal(p1.OrganizeId, p3.OrganizeId); 
        }

        [Fact]
        public void UpdateOrganizesByIdActionTest()
        {
            string orgId = "UpdateOrganizesByIdActionTest";

            var db = DBUtils.CreateMockedMongoDb<MOrganize>();

            var addAct = new AddOrganizesAction(db, orgId);
            var p1 = new MOrganize() 
            { 
                OrganizeId = "UpdateOrganizeByIdActionTestId",
                OrganizeName = "UpdateOrganizeByIdActionTestName" 
            };
            var m = addAct.Apply<MOrganize>(p1);
            m.OrganizeName = "UpdatedOrganizeName";

            var updateByIdAct = new UpdateOrganizesByIdAction(db, orgId);
            updateByIdAct.Apply<MOrganize>(m);

            var getByIdAct = new GetOrganizesByIdAction(db, orgId);
            var u = getByIdAct.Apply<MOrganize>(m);

            Assert.Equal("UpdatedOrganizeName", u.OrganizeName);
        }

        [Fact]
        public void GetOrganizesByIdNothingActionTest()
        {
            string orgId = "GetOrganizesByIdNothingActionTest";
            var db = DBUtils.CreateMockedMongoDb<MOrganize>();

            var getByIdAct = new GetOrganizesByIdAction(db, orgId);
            var p = getByIdAct.Apply<MOrganize>(new MOrganize());
            Assert.Null(p);

            var countAct = new GetOrganizesCountAction(db, orgId);
            var count = countAct.Apply<MOrganize>(new MOrganize());
            Assert.Equal(0, count);

            var queryAct = new GetOrganizesAction(db, orgId);
            var list = queryAct.Apply<MOrganize>(new MOrganize(), new QueryParam());
            Assert.Empty(list);
        }


        [Fact]
        public void AddDuplicateOrganizesTest()
        {
            string orgId = "AddDuplicateOrganizesTest";
            var db = DBUtils.CreateMockedMongoDb<MOrganize>();

            var addAct = new AddOrganizesAction(db, orgId);
            var p1 = new MOrganize() 
            { 
                OrganizeId = "AddDuplicateOrganizesTest",
                OrganizeName = "UpdateOrganizeByIdActionTestName" 
            };
            var m = addAct.Apply<MOrganize>(p1);

            Assert.Throws<MongoDB.Driver.MongoWriteException>(() => {
                addAct.Apply<MOrganize>(m);
            });
        }
        
    }
}


