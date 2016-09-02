using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
namespace Outsourcing.Data.Repository
{
    public class ProductSchedulePictureMappingRepository : RepositoryBase<ProductSchedulePictureMapping>, IProductSchedulePictureMappingRepository
    {
        public ProductSchedulePictureMappingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }        
        }
    public interface IProductSchedulePictureMappingRepository : IRepository<ProductSchedulePictureMapping>
    {
        
    }
}