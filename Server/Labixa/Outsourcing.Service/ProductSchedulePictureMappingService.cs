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
    public interface IProductSchedulePictureMappingService
    {

        IEnumerable<ProductSchedulePictureMapping> GetProductSchedulePictureMappings();
        ProductSchedulePictureMapping GetProductSchedulePictureMappingById(int productSchedulePictureMappingId);
        void CreateProductSchedulePictureMapping(ProductSchedulePictureMapping productSchedulePictureMapping);
        void EditProductSchedulePictureMapping(ProductSchedulePictureMapping productSchedulePictureMappingToEdit);
        void DeleteProductSchedulePictureMapping(int productSchedulePictureMappingId);
        void SaveProductSchedulePictureMapping();
        IEnumerable<ValidationResult> CanAddProductSchedulePictureMapping(ProductSchedulePictureMapping productSchedulePictureMapping);

    }
    public class ProductSchedulePictureMappingService : IProductSchedulePictureMappingService
    {
        #region Field
        private readonly IProductSchedulePictureMappingRepository productSchedulePictureMappingRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ProductSchedulePictureMappingService(IProductSchedulePictureMappingRepository productSchedulePictureMappingRepository, IUnitOfWork unitOfWork)
        {
            this.productSchedulePictureMappingRepository = productSchedulePictureMappingRepository;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region BaseMethod

        public IEnumerable<ProductSchedulePictureMapping> GetProductSchedulePictureMappings()
        {
            var productSchedulePictureMappings = productSchedulePictureMappingRepository.GetAll();
            return productSchedulePictureMappings;
        }

        public ProductSchedulePictureMapping GetProductSchedulePictureMappingById(int productSchedulePictureMappingId)
        {
            var productSchedulePictureMapping = productSchedulePictureMappingRepository.GetById(productSchedulePictureMappingId);
            return productSchedulePictureMapping;
        }

        public void CreateProductSchedulePictureMapping(ProductSchedulePictureMapping productSchedulePictureMapping)
        {
            productSchedulePictureMappingRepository.Add(productSchedulePictureMapping);
            SaveProductSchedulePictureMapping();
        }

        public void EditProductSchedulePictureMapping(ProductSchedulePictureMapping productSchedulePictureMappingToEdit)
        {
            productSchedulePictureMappingRepository.Update(productSchedulePictureMappingToEdit);
            SaveProductSchedulePictureMapping();
        }

        public void DeleteProductSchedulePictureMapping(int productSchedulePictureMappingId)
        {
            //Get productSchedulePictureMapping by id.
            var productSchedulePictureMapping = productSchedulePictureMappingRepository.GetById(productSchedulePictureMappingId);
            if (productSchedulePictureMapping != null)
            {
                productSchedulePictureMappingRepository.Delete(productSchedulePictureMapping);
                SaveProductSchedulePictureMapping();
            }
        }

        public void SaveProductSchedulePictureMapping()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<ValidationResult> CanAddProductSchedulePictureMapping(ProductSchedulePictureMapping productSchedulePictureMapping)
        {
        
            //    yield return new ValidationResult("ProductSchedulePictureMapping", "ErrorString");
            return null;
        }

        #endregion
    }
}
