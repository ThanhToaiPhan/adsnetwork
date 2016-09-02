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
    public interface IOrderAttributeService
    {

        IEnumerable<OrderAttribute> GetOrderAttributes();
        OrderAttribute GetOrderAttributeById(int orderAttributeId);
        void CreateOrderAttribute(OrderAttribute orderAttribute);
        void EditOrderAttribute(OrderAttribute orderAttributeToEdit);
        void DeleteOrderAttribute(int orderAttributeId);
        void SaveOrderAttribute();
        IEnumerable<ValidationResult> CanAddOrderAttribute(OrderAttribute orderAttribute);

    }
    public class OrderAttributeService : IOrderAttributeService
    {
        #region Field
        private readonly IOrderAttributeRepository orderAttributeRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public OrderAttributeService(IOrderAttributeRepository orderAttributeRepository, IUnitOfWork unitOfWork)
        {
            this.orderAttributeRepository = orderAttributeRepository;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region BaseMethod

        public IEnumerable<OrderAttribute> GetOrderAttributes()
        {
            var orderAttributes = orderAttributeRepository.GetAll();
            return orderAttributes;
        }

        public OrderAttribute GetOrderAttributeById(int orderAttributeId)
        {
            var orderAttribute = orderAttributeRepository.GetById(orderAttributeId);
            return orderAttribute;
        }

        public void CreateOrderAttribute(OrderAttribute orderAttribute)
        {
            orderAttributeRepository.Add(orderAttribute);
            SaveOrderAttribute();
        }

        public void EditOrderAttribute(OrderAttribute orderAttributeToEdit)
        {
            orderAttributeRepository.Update(orderAttributeToEdit);
            SaveOrderAttribute();
        }

        public void DeleteOrderAttribute(int orderAttributeId)
        {
            //Get orderAttribute by id.
            var orderAttribute = orderAttributeRepository.GetById(orderAttributeId);
            if (orderAttribute != null)
            {
                orderAttributeRepository.Delete(orderAttribute);
                SaveOrderAttribute();
            }
        }

        public void SaveOrderAttribute()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<ValidationResult> CanAddOrderAttribute(OrderAttribute orderAttribute)
        {
        
            //    yield return new ValidationResult("OrderAttribute", "ErrorString");
            return null;
        }

        #endregion
    }
}
