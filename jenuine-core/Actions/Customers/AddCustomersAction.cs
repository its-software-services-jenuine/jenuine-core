using Its.Jenuiue.Core.Actions;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Global;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Customers
{
    public class AddCustomersAction : BaseActionAdd
    {
        private readonly string collName = "customers";   
        
        protected override bool UseGlobalDb()
        {
            return true;
        }
        
        
        public AddCustomersAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);

            IMongoCollection<MCustomer> coll = GetCollection<MCustomer>();
            var option = new CreateIndexOptions() 
            { 
                Unique = true
            };

            var pdIdField = new StringFieldDefinition<MCustomer>("CustomerId");
            var indexDefinition = new IndexKeysDefinitionBuilder<MCustomer>().Ascending(pdIdField);
            var idxModel = new CreateIndexModel<MCustomer>(indexDefinition, option);

            coll.Indexes.CreateOne(idxModel);
        }

        protected override string GetCollectionName()
        {
            return collName;
        }
    }
}
