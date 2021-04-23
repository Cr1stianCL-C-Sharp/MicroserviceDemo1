using System.Threading.Tasks;
using VirtualMind.Core.Entities;

namespace VirtualMind.Infrastructure.IRepository
{
    public interface ICurrencyRepository
    {
        Task<CurrencyEntity> GetCurrencyQuoteUSD(string url);

        Task<CurrencyEntity> GetCurrencyQuoteReal(string url);

    }
}
