using System.Threading.Tasks;
using VirtualMind.Application.Dtos;
using VirtualMind.Core.Enums;

namespace VirtualMind.Application.IServices
{
    public interface ICurrencyService
    {
        Task<CurrencyDto> ObtainCurrencyQuote(string url, Currency currency);

    }
}
