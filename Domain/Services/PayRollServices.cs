using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IPayRollService
    {
        PayRoll GetPayRoll(int id);
        List<PayRollDto> GetALl();
        PayRoll CreatePayRoll(PayRollDto PayRollDto);
        List<PayRoll> GetPayRollByIdAndMonth(string EmpId, string Month);

    }
    public class PayRollService : IPayRollService
    {
        private readonly IPayRollRepository _PayRollRepository;

        public PayRollService(IPayRollRepository PayRollRepository)
        {
            _PayRollRepository = PayRollRepository;    
        }
        
       
        public PayRoll GetPayRoll(int id)
        {
            return _PayRollRepository.GetPayRoll(id);
        }

        public List<PayRoll> GetPayRollByIdAndMonth(string EmpId, string Month)
        {
            return _PayRollRepository.GetPayRollByIdAndMonth(EmpId,Month);
        }
        public PayRoll CreatePayRoll(PayRollDto PayRollDto)
        {
            return _PayRollRepository.CreatePayRoll(PayRollDto);
        }
        public List<PayRollDto> GetALl()
        {
            return _PayRollRepository.GetAll().Select(_PayRollRepository.ToPayRollDto).ToList();
        }

    }
}