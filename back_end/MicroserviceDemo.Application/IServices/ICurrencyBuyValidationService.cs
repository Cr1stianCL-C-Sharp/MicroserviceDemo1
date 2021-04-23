using System;
using System.Threading.Tasks;
using VirtualMind.Core.Enums;

namespace VirtualMind.Application.IServices
{
    public interface ICurrencyBuyValidationService
    {

        Task<bool> ValCurrencyBuyAmount(Guid userId, Currency currency);
    }
}
