using System;
using System.Threading.Tasks;
using VirtualMind.Application.IServices;
using VirtualMind.Core.Enums;
using VirtualMind.Infrastructure.IRepository;
using VirtualMind.Infrastructure.Repository;

namespace VirtualMind.Application.Services
{
    public class CurrencyBuyValidationService : ICurrencyBuyValidationService
    {

        public ICurrencyBuyValidationRepository BuyValidationRepository { get; set; }


        public CurrencyBuyValidationService(ICurrencyBuyValidationRepository buyValidationRepository)
        {
            BuyValidationRepository = buyValidationRepository;
        }

        public CurrencyBuyValidationService() : this(new CurrencyBuyValidationRepository())
        { }


        public async Task<bool> ValCurrencyBuyAmount(Guid userId, Currency currency)
        {
            return await BuyValidationRepository.ValidateCurrencyBuyAmount(userId, currency);
        }
    }
}
