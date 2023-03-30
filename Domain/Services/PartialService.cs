using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IPartialService
    {
        Partial GetPartial(int id);
        List<PartialDto> GetALl();
        Partial CreatePartial(PartialDto PartialDto);
        List<Partial> GetPartialByName(string Name);

    }
    public class PartialService : IPartialService
    {
        private readonly IPartialRepository _PartialRepository;

        public PartialService(IPartialRepository PartialRepository)
        {
            _PartialRepository = PartialRepository;    
        }
        
       
        public Partial GetPartial(int id)
        {
            return _PartialRepository.GetPartial(id);
        }

        public List<Partial> GetPartialByName(string Name)
        {
            return _PartialRepository.GetPartialByName(Name);
        }
        public Partial CreatePartial(PartialDto PartialDto)
        {
            return _PartialRepository.CreatePartial(PartialDto);
        }
        public List<PartialDto> GetALl()
        {
            return _PartialRepository.GetAll().Select(_PartialRepository.ToPartialDto).ToList();
        }

    }
}