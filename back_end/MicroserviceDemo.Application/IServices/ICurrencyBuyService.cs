using System.Threading.Tasks;
using VirtualMind.Application.Dtos;
using VirtualMind.Core.Entities;

namespace VirtualMind.Application.IServices
{
    public interface ICurrencyBuyService
    {

        Task<CurrencyBuyEntity> CurrencyBuyTransaction(CurrencyBuyDto buyDto);

    }
}
