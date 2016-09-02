using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Data.Repository
{
    public class ProductScheduleAttributeMappingRepository : RepositoryBase<ProductScheduleAttributeMapping>, IProductScheduleAttributeMappingRepository
    {
        public ProductScheduleAttributeMappingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IProductScheduleAttributeMappingRepository : IRepository<ProductScheduleAttributeMapping>
    {

    }
}
