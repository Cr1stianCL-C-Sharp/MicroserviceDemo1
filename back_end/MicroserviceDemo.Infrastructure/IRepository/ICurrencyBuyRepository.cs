using System.Threading.Tasks;
using VirtualMind.Core.Entities;

namespace VirtualMind.Infrastructure.IRepository
{
    public interface ICurrencyBuyRepository
    {

        Task<CurrencyBuyEntity> SaveCurrencyBuy(CurrencyBuyEntity buyEntity);


    }
}
