using System.Collections.Generic;
using Outsourcing.Data.Models;
using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Repository;
using System.Linq;

namespace Outsourcing.Service
{
    public interface ICodeService
    {
        IEnumerable<Code> GetCodes();
    }
    public class CodeService : ICodeService
    {
        private readonly ICodeRepository codeRepository;
        private readonly IUnitOfWork unitOfWork;

        public CodeService(ICodeRepository codeRepository, IUnitOfWork unitOfWork)
        {
            this.codeRepository = codeRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Code> GetCodes()
        {
            var codes = codeRepository.GetAll();
            return codes;
        }
    }
}
