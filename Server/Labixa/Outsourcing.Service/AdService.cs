using System.Collections.Generic;
using Outsourcing.Data.Models;
using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Repository;

namespace Outsourcing.Service
{
    public interface IAdService
    {
        IEnumerable<Ad> GetAds();
    }
    public class AdService : IAdService
    {
        private readonly IAdRepository adRepository;
        private readonly IUnitOfWork unitOfWork;

        public AdService(IAdRepository adRepository, IUnitOfWork unitOfWork)
        {
            this.adRepository = adRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Ad> GetAds()
        {
            var products = adRepository.GetAll();
            return products;
        }
    }
}
