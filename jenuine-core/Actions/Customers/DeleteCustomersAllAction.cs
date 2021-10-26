using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Customers
{
    public class DeleteCustomersAllAction : BaseActionDeleteAll
    {
        public DeleteCustomersAllAction(IDatabase conn, string orgId)
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
