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
    public interface IOrderAttributeMappingService
    {

        IEnumerable<OrderAttributeMapping> GetOrderAttributeMappings();
        OrderAttributeMapping GetOrderAttributeMappingById(int orderAttributeMappingId);
        void CreateOrderAttributeMapping(OrderAttributeMapping orderAttributeMapping);
        void EditOrderAttributeMapping(OrderAttributeMapping orderAttributeMappingToEdit);
        void DeleteOrderAttributeMapping(int orderAttributeMappingId);
        void SaveOrderAttributeMapping();
        IEnumerable<ValidationResult> CanAddOrderAttributeMapping(OrderAttributeMapping orderAttributeMapping);

    }
    public class OrderAttributeMappingService : IOrderAttributeMappingService
    {
        #region Field
        private readonly IOrderAttributeMappingRepository orderAttributeMappingRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public OrderAttributeMappingService(IOrderAttributeMappingRepository orderAttributeMappingRepository, IUnitOfWork unitOfWork)
        {
            this.orderAttributeMappingRepository = orderAttributeMappingRepository;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region BaseMethod

        public IEnumerable<OrderAttributeMapping> GetOrderAttributeMappings()
        {
            var orderAttributeMappings = orderAttributeMappingRepository.GetAll();
            return orderAttributeMappings;
        }

        public OrderAttributeMapping GetOrderAttributeMappingById(int orderAttributeMappingId)
        {
            var orderAttributeMapping = orderAttributeMappingRepository.GetById(orderAttributeMappingId);
            return orderAttributeMapping;
        }

        public void CreateOrderAttributeMapping(OrderAttributeMapping orderAttributeMapping)
        {
            orderAttributeMappingRepository.Add(orderAttributeMapping);
            SaveOrderAttributeMapping();
        }

        public void EditOrderAttributeMapping(OrderAttributeMapping orderAttributeMappingToEdit)
        {
            orderAttributeMappingRepository.Update(orderAttributeMappingToEdit);
            SaveOrderAttributeMapping();
        }

        public void DeleteOrderAttributeMapping(int orderAttributeMappingId)
        {
            //Get orderAttributeMapping by id.
            var orderAttributeMapping = orderAttributeMappingRepository.GetById(orderAttributeMappingId);
            if (orderAttributeMapping != null)
            {
                orderAttributeMappingRepository.Delete(orderAttributeMapping);
                SaveOrderAttributeMapping();
            }
        }

        public void SaveOrderAttributeMapping()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<ValidationResult> CanAddOrderAttributeMapping(OrderAttributeMapping orderAttributeMapping)
        {
        
            //    yield return new ValidationResult("OrderAttributeMapping", "ErrorString");
            return null;
        }

        #endregion
    }
}
