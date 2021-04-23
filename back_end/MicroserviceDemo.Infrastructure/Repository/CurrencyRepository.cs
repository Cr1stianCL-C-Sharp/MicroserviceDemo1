using System.Threading.Tasks;
using VirtualMind.Core.Context;
using VirtualMind.Core.Entities;
using VirtualMind.Infrastructure.ExtServices;
using VirtualMind.Infrastructure.IExtServices;
using VirtualMind.Infrastructure.IRepository;

namespace VirtualMind.Infrastructure.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {

        private VirtualMindAPPDbContext context;

        public ICurrencyAdapterService IAdapterService { get; set; }


        public CurrencyRepository(VirtualMindAPPDbContext context, ICurrencyAdapterService adapterService)
        {
            this.context = context;
            this.IAdapterService = adapterService;

        }


        public CurrencyRepository() : this(new VirtualMindAPPDbContext(), new CurrencyAdapterService())
        { }



        public async Task<CurrencyEntity> GetCurrencyQuoteUSD(string url)
        {
            return await IAdapterService.GetUpdatedUSDCurrency(url);
        }


        public async Task<CurrencyEntity> GetCurrencyQuoteReal(string url)
        {
            /* La cotización del real será la cuarta parte de la cotización del dólar. */
            var usdCurrency = await IAdapterService.GetUpdatedUSDCurrency(url);
            usdCurrency.Informal = usdCurrency.Informal / 4;
            usdCurrency.Observed = usdCurrency.Observed / 4;
            return usdCurrency;
        }
    }
}
