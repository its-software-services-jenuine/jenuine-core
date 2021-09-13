using Its.Jenuiue.Core.Actions;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;

using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Organizes
{
    public class GetOrganizesAction : BaseActionQuery
    {
        public GetOrganizesAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        
        protected override string GetCollectionName()
        {
            return "organizes";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = FilterDefinition<T>.Empty;
            return filter;
        }
        
    }
        
}

