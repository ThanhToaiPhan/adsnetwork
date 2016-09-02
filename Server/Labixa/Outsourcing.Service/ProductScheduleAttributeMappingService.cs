using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outsourcing.Core.Common;
using Outsourcing.Data.Models;
using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Repository;
using Outsourcing.Service.Properties;

namespace Outsourcing.Service
{
    public interface IProductScheduleAttributeMappingService
    {

        IEnumerable<ProductScheduleAttributeMapping> GetProductScheduleAttributeMappings();
        ProductScheduleAttributeMapping GetProductScheduleAttributeMappingById(int productScheduleAttributeMappingId);
        void CreateProductScheduleAttributeMapping(ProductScheduleAttributeMapping productScheduleAttributeMapping);
        void EditProductScheduleAttributeMapping(ProductScheduleAttributeMapping productScheduleAttributeMappingToEdit);
        void DeleteProductScheduleAttributeMapping(int productScheduleAttributeMappingId);
        void SaveProductScheduleAttributeMapping();
        IEnumerable<ValidationResult> CanAddProductScheduleAttributeMapping(ProductScheduleAttributeMapping productScheduleAttributeMapping);

    }
    public class ProductScheduleAttributeMappingService : IProductScheduleAttributeMappingService
    {
        #region Field
        private readonly IProductScheduleAttributeMappingRepository productScheduleAttributeMappingRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ProductScheduleAttributeMappingService(IProductScheduleAttributeMappingRepository productScheduleAttributeMappingRepository, IUnitOfWork unitOfWork)
        {
            this.productScheduleAttributeMappingRepository = productScheduleAttributeMappingRepository;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region BaseMethod

        public IEnumerable<ProductScheduleAttributeMapping> GetProductScheduleAttributeMappings()
        {
            var productScheduleAttributeMappings = productScheduleAttributeMappingRepository.GetAll();
            return productScheduleAttributeMappings;
        }

        public ProductScheduleAttributeMapping GetProductScheduleAttributeMappingById(int productScheduleAttributeMappingId)
        {
            var productScheduleAttributeMapping = productScheduleAttributeMappingRepository.GetById(productScheduleAttributeMappingId);
            return productScheduleAttributeMapping;
        }

        public void CreateProductScheduleAttributeMapping(ProductScheduleAttributeMapping productScheduleAttributeMapping)
        {
            productScheduleAttributeMappingRepository.Add(productScheduleAttributeMapping);
            SaveProductScheduleAttributeMapping();
        }

        public void EditProductScheduleAttributeMapping(ProductScheduleAttributeMapping productScheduleAttributeMappingToEdit)
        {
            productScheduleAttributeMappingRepository.Update(productScheduleAttributeMappingToEdit);
            SaveProductScheduleAttributeMapping();
        }

        public void DeleteProductScheduleAttributeMapping(int productScheduleAttributeMappingId)
        {
            //Get productScheduleAttributeMapping by id.
            var productScheduleAttributeMapping = productScheduleAttributeMappingRepository.GetById(productScheduleAttributeMappingId);
            if (productScheduleAttributeMapping != null)
            {
                productScheduleAttributeMappingRepository.Delete(productScheduleAttributeMapping);
                SaveProductScheduleAttributeMapping();
            }
        }

        public void SaveProductScheduleAttributeMapping()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<ValidationResult> CanAddProductScheduleAttributeMapping(ProductScheduleAttributeMapping productScheduleAttributeMapping)
        {
        
            //    yield return new ValidationResult("ProductScheduleAttributeMapping", "ErrorString");
            return null;
        }

        #endregion
    }
}
