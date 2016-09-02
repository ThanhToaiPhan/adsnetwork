using System.Collections.Generic;
using Outsourcing.Data.Models;
using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Repository;

namespace Outsourcing.Service
{
    public interface IDomainService
    {
        IEnumerable<Domain> GetDomains();
    }
    public class DomainService : IDomainService
    {
        private readonly IDomainRepository domainRepository;
        private readonly IUnitOfWork unitOfWork;

        public DomainService(IDomainRepository domainRepository, IUnitOfWork unitOfWork)
        {
            this.domainRepository = domainRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Domain> GetDomains()
        {
            var products = domainRepository.GetAll();
            return products;
        }
    }
}
