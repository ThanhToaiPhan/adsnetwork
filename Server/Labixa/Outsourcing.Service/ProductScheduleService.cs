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
    public interface IProductScheduleService
    {
        IEnumerable<ProductSchedule> GetProductSchedules();
        IEnumerable<ProductSchedule> GetProductSchedulesOfProduct(int productId);
        ProductSchedule GetProductScheduleById(int productScheduleId);
        IEnumerable<ProductSchedule> GetSimilarProductSchedule(ProductSchedule obj);
        void CreateProductSchedule(ProductSchedule obj);
        void EditProductSchedule(ProductSchedule obj);
        void DeleteProductSchedule(int id);

        void SaveChange();
    }
    public class ProductScheduleService : IProductScheduleService
    {
        #region Field
        private readonly IProductScheduleRepository productScheduleRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ProductScheduleService(IProductScheduleRepository productScheduleRepository, IUnitOfWork unitOfWork)
        {
            this.productScheduleRepository = productScheduleRepository;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region [base Method]
        public IEnumerable<ProductSchedule> GetProductSchedules()
        {
            var list = productScheduleRepository.GetAll().Where(p => !p.IsDeleted).OrderByDescending(p => p.ProductId).ToList();
            return list;
        }

        public IEnumerable<ProductSchedule> GetProductSchedulesOfProduct(int productId)
        {
            var list = productScheduleRepository.GetAll().Where(p => p.ProductId == productId).ToList();
            return list;
        }

        public ProductSchedule GetProductScheduleById(int productScheduleId)
        {
            try
            {
                var item = productScheduleRepository.GetById(productScheduleId);
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void CreateProductSchedule(ProductSchedule obj)
        {
            try
            {
                productScheduleRepository.Add(obj);
                SaveChange();

            }
            catch (Exception)
            {

            }
        }

        public void EditProductSchedule(ProductSchedule obj)
        {
            try
            {
                var item = productScheduleRepository.Get(p => p.Id == obj.Id);
                item.MaxQuantity = obj.MaxQuantity;
                item.IsDeleted = obj.IsDeleted;
                item.IsAvailable = obj.IsAvailable;
                productScheduleRepository.Update(item);
                SaveChange();
            }
            catch (Exception)
            {

            }
        }   

        public void SaveChange()
        {
            try
            {
                unitOfWork.Commit();
            }
            catch (Exception)
            {

            }
        }
        #endregion


        public void DeleteProductSchedule(int id)
        {
            var item = productScheduleRepository.Get(p => p.Id == id);
            item.IsDeleted = true;
            productScheduleRepository.Update(item);
            SaveChange();
        }

        public IEnumerable<ProductSchedule> GetSimilarProductSchedule(ProductSchedule obj)
        {
            var listProductSchedule = GetProductSchedulesOfProduct(obj.ProductId);
            return listProductSchedule;
        }
    }
}
