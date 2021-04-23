using System;
using System.Threading.Tasks;
using VirtualMind.Core.Enums;

namespace VirtualMind.Infrastructure.IRepository
{
    public interface ICurrencyBuyValidationRepository
    {
        Task<bool> ValidateCurrencyBuyAmount(Guid UserId, Currency currentCurrency);


    }
}
