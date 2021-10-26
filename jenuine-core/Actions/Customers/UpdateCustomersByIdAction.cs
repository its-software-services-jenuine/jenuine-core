using System.Collections.Generic;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Customers
{
    public class UpdateCustomersByIdAction : BaseActionUpdateById
    {
        public UpdateCustomersByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "customers";
        }

        protected override bool UseGlobalDb()
        {
            return true;
        }
        
        protected override List<string>GetUpdateFields()
        {
            var fields = new List<string>() 
            {
                "CustomersId",
                "CustomersName",
                "Description"
            };

            return fields;
        }
    }
}
