using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;

namespace Outsourcing.Data.Repository
{
    class OrderAttributeMappingRepository : RepositoryBase<OrderAttributeMapping>, IOrderAttributeMappingRepository
    {
        public OrderAttributeMappingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IOrderAttributeMappingRepository : IRepository<OrderAttributeMapping>
    {

    }
}
