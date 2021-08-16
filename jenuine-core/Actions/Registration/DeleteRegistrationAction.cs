using Its.Jenuiue.Core.Actions;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Services.Registration
{
    public class DeleteRegistrationAction : BaseActionDeleteById
    {
        public DeleteRegistrationAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "registration";
        }                     
    }
}
