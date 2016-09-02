using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Data.Repository
{
    public class ProductScheduleRepository : RepositoryBase<ProductSchedule>, IProductScheduleRepository
    {
        public ProductScheduleRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IProductScheduleRepository : IRepository<ProductSchedule>
    {

    }
}
