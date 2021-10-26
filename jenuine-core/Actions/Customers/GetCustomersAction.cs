using Its.Jenuiue.Core.Actions;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;

using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Customers
{
    public class GetCustomersAction : BaseActionQuery
    {
        public GetCustomersAction(IDatabase conn, string orgId)
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
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = FilterDefinition<T>.Empty;
            return filter;
        }
        
    }
        
}

