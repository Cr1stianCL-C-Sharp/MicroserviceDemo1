using AutoMapper;
using System.Threading.Tasks;
using VirtualMind.Application.Dtos;
using VirtualMind.Application.IServices;
using VirtualMind.Core.Enums;
using VirtualMind.Infrastructure.IRepository;

namespace VirtualMind.Application.Services
{
    public class CurrencyService : ICurrencyService
    {

        public ICurrencyRepository CurrencyRepository { get; set; }

        private readonly IMapper _mapper;


        public CurrencyService(ICurrencyRepository currencyRepository, IMapper mapper)
        {
            CurrencyRepository = currencyRepository;
            _mapper = mapper;
        }


        public async Task<CurrencyDto> ObtainCurrencyQuote(string url, Currency currency)
        {
            switch (currency)
            {
                case Currency.USD:
                    return await ObtainCurrencyQuoteUSD(url);
                case Currency.BRL:
                    return await ObtainCurrencyQuoteReal(url);
                default:
                    return new CurrencyDto();
            }
        }

        private async Task<CurrencyDto> ObtainCurrencyQuoteUSD(string url)
        {
            var currenty = await CurrencyRepository.GetCurrencyQuoteUSD(url);
            var mapper = _mapper.Map<CurrencyDto>(currenty);
            return mapper;
        }

        private async Task<CurrencyDto> ObtainCurrencyQuoteReal(string url)
        {
            var currenty = await CurrencyRepository.GetCurrencyQuoteReal(url);
            return _mapper.Map<CurrencyDto>(currenty);
        }



    }
}
