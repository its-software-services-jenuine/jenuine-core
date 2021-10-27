
using System;
using Xunit;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Utils;
using Its.Jenuiue.Core.Models.Global;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.Customers
{
    public class CustomersActionsTest
    {
        [Fact]
        public void CustomersScenarioActionTest()
        {
            string orgId = "CustomersScenarioActionTest";

            var db = DBUtils.CreateMockedMongoDb<MCustomer>();

            var delAll = new DeleteCustomersAllAction(db, orgId);
            delAll.Apply<MCustomer>();

            var addAct = new AddCustomersAction(db, orgId);
            var p1 = new MCustomer() { CustomerId = "0001" };
            var m = addAct.Apply<MCustomer>(p1);
            Assert.NotEqual("", m.Id);

            var countAct = new GetCustomersCountAction(db, orgId);
            var count = countAct.Apply<MCustomer>(new MCustomer());

            Assert.Equal(1, count);

            var p2 = new MCustomer() { CustomerId = "0002" };
            p2 = addAct.Apply<MCustomer>(p2);

            count = countAct.Apply<MCustomer>(new MCustomer());
            Assert.Equal(2, count);

            var queryAct = new GetCustomersAction(db, orgId);
            var list = queryAct.Apply<MCustomer>(new MCustomer(), new QueryParam());
            Assert.Equal(2, list.Count);

            var delAct = new DeleteCustomersByIdAction(db, orgId);
            delAct.Apply<MCustomer>(p2.Id);

            count = countAct.Apply<MCustomer>(new MCustomer());
            Assert.Equal(1, count); 

            var getByIdAct = new GetCustomersByIdAction(db, orgId);
            var p3 = getByIdAct.Apply<MCustomer>(p1);
            Assert.Equal(p1.CustomerId, p3.CustomerId); 
        }

        [Fact]
        public void UpdateCustomersByIdActionTest()
        {
            string orgId = "UpdateCustomersByIdActionTest";

            var db = DBUtils.CreateMockedMongoDb<MCustomer>();

            var delAll = new DeleteCustomersAllAction(db, orgId);
            delAll.Apply<MCustomer>();

            var addAct = new AddCustomersAction(db, orgId);
            var p1 = new MCustomer() 
            { 
                CustomerId = "UpdateCustomersByIdActionTestId",
                CustomerName = "UpdateCustomersByIdActionTestName",
               
                
            };
            var m = addAct.Apply<MCustomer>(p1);
            m.CustomerName = "UpdateCustomersName";

            var updateByIdAct = new UpdateCustomersByIdAction(db, orgId);
            updateByIdAct.Apply<MCustomer>(m);
      
            var getByIdAct = new GetCustomersByIdAction(db, orgId);
            var u = getByIdAct.Apply<MCustomer>(m);
            Assert.Equal("UpdateCustomersName", u.CustomerName);
           

        }

    
        [Fact]
        public void GetCustomersByIdNothingActionTest()
        {
            string orgId = "GetCustomersByIdNothingActionTest";
            var db = DBUtils.CreateMockedMongoDb<MCustomer>();

            var delAll = new DeleteCustomersAllAction(db, orgId);
            delAll.Apply<MCustomer>();

            var getByIdAct = new GetCustomersByIdAction(db, orgId);
            var p = getByIdAct.Apply<MCustomer>(new MCustomer());
            Assert.Null(p);

            var countAct = new GetCustomersCountAction(db, orgId);
            var count = countAct.Apply<MCustomer>(new MCustomer());
            Assert.Equal(0, count);

            var queryAct = new GetCustomersAction(db, orgId);
            var list = queryAct.Apply<MCustomer>(new MCustomer(), new QueryParam());
            Assert.Empty(list);
        }


        [Fact]
        public void AddDuplicateCustomersTest()
        {
            string orgId = "AddDuplicateCustomersTest";
            var db = DBUtils.CreateMockedMongoDb<MCustomer>();

            var delAll = new DeleteCustomersAllAction(db, orgId);
            delAll.Apply<MCustomer>();

            var addAct = new AddCustomersAction(db, orgId);
            var p1 = new MCustomer() 
            { 
                CustomerId = "AddDuplicateCustomersTestId",
                CustomerName = "AddDuplicateCustomersTestName" 
            };
            var m = addAct.Apply<MCustomer>(p1);

            Assert.Throws<MongoDB.Driver.MongoWriteException>(() => {
                addAct.Apply<MCustomer>(m);
            });
        }

        
        
    }
}


