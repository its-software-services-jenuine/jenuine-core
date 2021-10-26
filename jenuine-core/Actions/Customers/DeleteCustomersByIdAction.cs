using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Customers
{
    public class DeleteCustomersByIdAction : BaseActionDeleteById
    {
        public DeleteCustomersByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override bool UseGlobalDb()
        {
            return true;
        }
        
        protected override string GetCollectionName()
        {
            return "customers";
        }                     
    }
}
