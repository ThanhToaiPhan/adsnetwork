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
    public interface IProductScheduleAttributeService
    {

        IEnumerable<ProductScheduleAttribute> GetProductScheduleAttributes();
        ProductScheduleAttribute GetProductScheduleAttributeById(int productScheduleAttributeId);
        void CreateProductScheduleAttribute(ProductScheduleAttribute productScheduleAttribute);
        void EditProductScheduleAttribute(ProductScheduleAttribute productScheduleAttributeToEdit);
        void DeleteProductScheduleAttribute(int productScheduleAttributeId);
        void SaveProductScheduleAttribute();
        IEnumerable<ValidationResult> CanAddProductScheduleAttribute(ProductScheduleAttribute productScheduleAttribute);

    }
    public class ProductScheduleAttributeService : IProductScheduleAttributeService
    {
        #region Field
        private readonly IProductScheduleAttributeRepository productScheduleAttributeRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ProductScheduleAttributeService(IProductScheduleAttributeRepository productScheduleAttributeRepository, IUnitOfWork unitOfWork)
        {
            this.productScheduleAttributeRepository = productScheduleAttributeRepository;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region BaseMethod

        public IEnumerable<ProductScheduleAttribute> GetProductScheduleAttributes()
        {
            var productScheduleAttributes = productScheduleAttributeRepository.GetAll();
            return productScheduleAttributes;
        }

        public ProductScheduleAttribute GetProductScheduleAttributeById(int productScheduleAttributeId)
        {
            var productScheduleAttribute = productScheduleAttributeRepository.GetById(productScheduleAttributeId);
            return productScheduleAttribute;
        }

        public void CreateProductScheduleAttribute(ProductScheduleAttribute productScheduleAttribute)
        {
            productScheduleAttributeRepository.Add(productScheduleAttribute);
            SaveProductScheduleAttribute();
        }

        public void EditProductScheduleAttribute(ProductScheduleAttribute productScheduleAttributeToEdit)
        {
            productScheduleAttributeRepository.Update(productScheduleAttributeToEdit);
            SaveProductScheduleAttribute();
        }

        public void DeleteProductScheduleAttribute(int productScheduleAttributeId)
        {
            //Get productScheduleAttribute by id.
            var productScheduleAttribute = productScheduleAttributeRepository.GetById(productScheduleAttributeId);
            if (productScheduleAttribute != null)
            {
                productScheduleAttributeRepository.Delete(productScheduleAttribute);
                SaveProductScheduleAttribute();
            }
        }

        public void SaveProductScheduleAttribute()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<ValidationResult> CanAddProductScheduleAttribute(ProductScheduleAttribute productScheduleAttribute)
        {
        
            //    yield return new ValidationResult("ProductScheduleAttribute", "ErrorString");
            return null;
        }

        #endregion
    }
}
