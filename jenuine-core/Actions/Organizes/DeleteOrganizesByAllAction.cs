using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Organizes
{
    public class DeleteOrganizesAllAction : BaseActionDeleteAll
    {
        public DeleteOrganizesAllAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override bool UseGlobalDb()
        {
            return true;
        }
        
        
        protected override string GetCollectionName()
        {
            return "organizes";
        }                     
    }
}
