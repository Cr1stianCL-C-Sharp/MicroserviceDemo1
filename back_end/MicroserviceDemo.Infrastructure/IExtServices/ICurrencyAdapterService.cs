using System.Threading.Tasks;
using VirtualMind.Core.Entities;

namespace VirtualMind.Infrastructure.IExtServices
{
    public interface ICurrencyAdapterService
    {
        Task<CurrencyEntity> GetUpdatedUSDCurrency(string url);
    }
}
