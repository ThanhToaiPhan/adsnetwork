using System.Collections.Generic;
using Outsourcing.Data.Models;
using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Repository;

namespace Outsourcing.Service
{
    public interface IAdMaterialMappingService
    {
        IEnumerable<AdMaterialMapping> GetAdMaterialMappings();
    }
    public class AdMaterialMappingService : IAdMaterialMappingService
    {
        private readonly IAdMaterialMappingRepository adMaterialMappingRepository;
        private readonly IUnitOfWork unitOfWork;

        public AdMaterialMappingService(IAdMaterialMappingRepository adMaterialMappingRepository, IUnitOfWork unitOfWork)
        {
            this.adMaterialMappingRepository = adMaterialMappingRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<AdMaterialMapping> GetAdMaterialMappings()
        {
            var products = adMaterialMappingRepository.GetAll();
            return products;
        }
    }
}
