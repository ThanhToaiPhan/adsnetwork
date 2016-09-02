using System.Collections.Generic;
using Outsourcing.Data.Models;
using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Repository;

namespace Outsourcing.Service
{
    public interface IMaterialService
    {
        IEnumerable<Material> GetMaterials();
    }
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository materialRepository;
        private readonly IUnitOfWork unitOfWork;

        public MaterialService(IMaterialRepository materialRepository, IUnitOfWork unitOfWork)
        {
            this.materialRepository = materialRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Material> GetMaterials()
        {
            var products = materialRepository.GetAll();
            return products;
        }
    }
}
