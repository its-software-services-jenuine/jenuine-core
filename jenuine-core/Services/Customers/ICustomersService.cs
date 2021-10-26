using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Models.Global;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Services.Customers
{
    public interface ICustomersService
    {
        public void SetOrgId(string id);
        public MCustomer AddCustomer(MCustomer param);
        public List<MCustomer> GetCustomer(MCustomer param, QueryParam queryParam);
        public MCustomer GetCustomerById(MCustomer param);
        public long GetCustomerCount();         
        public MCustomer DeleteCustomerById(MCustomer param);
        public MCustomer UpdateCustomer(MCustomer param);
        public int DeleteCustomerAll();
    }
}
