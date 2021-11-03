using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Models.Global;
using Its.Jenuiue.Core.Actions.Organizes;
using Its.Jenuiue.Core.Actions.Customers;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Services.Customers
{
    public class CustomersService : ICustomersService
    {
        private readonly IDatabase database;
        private string orgId = "";

        public CustomersService(IDatabase db)
        {
            database = db;
        }
        public void SetOrgId(string org)
        {
            orgId = org;
        }


        public List<MCustomer> GetCustomer(MCustomer param, QueryParam queryParam)
        {
            var act = new GetCustomersAction(database, orgId);            
            var results = act.Apply<MCustomer>(param, queryParam);

            return results;
        }

        public MCustomer AddCustomer(MCustomer param)
        {
            var act = new AddCustomersAction(database, orgId);
            var result = act.Apply<MCustomer>(param);


            return result;
        }

        public MCustomer GetCustomerById(MCustomer param)
        {
            var act = new GetCustomersByIdAction(database, orgId);            
            var customers = act.Apply<MCustomer>(param);

            return customers;            
        }

        public long GetCustomerCount()
        {
            var m = new MCustomer();

            var act = new GetCustomersCountAction(database, orgId);
            var cnt = act.Apply<MCustomer>(m);

            return cnt;
        }
        public MCustomer UpdateCustomer(MCustomer param)
        {
            var act = new UpdateCustomersByIdAction(database, orgId);
            var result = act.Apply<MCustomer>(param);

            return result;
        }

        

        public MCustomer DeleteCustomerById(MCustomer param)
        {
            var act = new DeleteCustomersByIdAction(database, orgId);
            var result = act.Apply<MCustomer>(param.Id);

            return result;
        }
        public int DeleteCustomerAll()
        {
            var act = new DeleteCustomersAllAction(database,orgId);
            var result = act.Apply<MCustomer>();
            return result;
        }
    }
}
