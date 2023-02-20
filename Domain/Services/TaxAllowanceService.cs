using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface ITaxAllowanceService
    {
        TaxAllowance GetTaxAllowance(int id);
        List<TaxAllowanceDto> GetALl();
        TaxAllowance CreateTaxAllowance(TaxAllowanceDto TaxAllowanceDto);
        List<TaxAllowance> GetTaxAllowanceByName(string Name);

    }
    public class TaxAllowanceService : ITaxAllowanceService
    {
        private readonly ITaxAllowanceRepository _TaxAllowanceRepository;

        public TaxAllowanceService(ITaxAllowanceRepository TaxAllowanceRepository)
        {
            _TaxAllowanceRepository = TaxAllowanceRepository;    
        }
        
       
        public TaxAllowance GetTaxAllowance(int id)
        {
            return _TaxAllowanceRepository.GetTaxAllowance(id);
        }

        public List<TaxAllowance> GetTaxAllowanceByName(string Name)
        {
            return _TaxAllowanceRepository.GetTaxAllowanceByName(Name);
        }

        public TaxAllowance CreateTaxAllowance(TaxAllowanceDto TaxAllowanceDto)
        {
            return _TaxAllowanceRepository.CreateTaxAllowance(TaxAllowanceDto);
        }
        public List<TaxAllowanceDto> GetALl()
        {
            return _TaxAllowanceRepository.GetAll().Select(_TaxAllowanceRepository.ToTaxAllowanceDto).ToList();
        }

    }
}