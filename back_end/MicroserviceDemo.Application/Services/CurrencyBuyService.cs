using AutoMapper;
using System.Net;
using System.Threading.Tasks;
using VirtualMind.Application.Dtos;
using VirtualMind.Application.IServices;
using VirtualMind.Core.Entities;
using VirtualMind.Core.Enums;
using VirtualMind.Core.Exceptions;
using VirtualMind.Infrastructure.IRepository;

namespace VirtualMind.Application.Services
{
    public class CurrencyBuyService : ICurrencyBuyService
    {


        public ICurrencyBuyRepository BuyRepository { get; set; }
        public ICurrencyBuyValidationService CurrencyBuyValidationService { get; set; }

        public ICurrencyService CurrencyService { get; set; }


        private readonly IMapper _mapper;

        public CurrencyBuyService(IMapper mapper, ICurrencyBuyRepository buyRepository, ICurrencyBuyValidationService currencyBuyValidationService, ICurrencyService currencyService)
        {
            _mapper = mapper;
            BuyRepository = buyRepository;
            CurrencyBuyValidationService = currencyBuyValidationService;
            CurrencyService = currencyService;
        }

        /*
           Por ejemplo, dado el monto 1000 y la moneda “dolar”, se registrará en la base de datos una compra con un valor resultado de 
           1000/{cotización dolar del dia} dólares.
         */

        public async Task<CurrencyBuyEntity> CurrencyBuyTransaction(CurrencyBuyDto buyDto)
        {
            var mappedDto = _mapper.Map<CurrencyBuyEntity>(buyDto);
            var validated = await CurrencyBuyValidationService.ValCurrencyBuyAmount(mappedDto.UserId, mappedDto.CurrencyType);

            if (validated)
            {

                switch (mappedDto.CurrencyType)
                {
                    case Currency.USD:
                        var urlUSD = "";
                        CurrencyDto todayUSD = await CurrencyService.ObtainCurrencyQuote(urlUSD, Currency.USD);
                        decimal transactionAmount = mappedDto.CurrencyLocalAmount / todayUSD.Observed;
                        mappedDto.TransactionAmount = transactionAmount;
                        return await BuyRepository.SaveCurrencyBuy(mappedDto);
                    case Currency.BRL:
                        var urlBRL = "";
                        CurrencyDto todayBRL = await CurrencyService.ObtainCurrencyQuote(urlBRL, Currency.BRL);
                        decimal transactionAmountBRL = mappedDto.CurrencyLocalAmount / todayBRL.Observed;
                        mappedDto.TransactionAmount = transactionAmountBRL;
                        return await BuyRepository.SaveCurrencyBuy(mappedDto);
                    default:
                        return mappedDto;
                }
            }
            else
            {
                throw new BussinessException(HttpStatusCode.PreconditionFailed, BussinessMessages.APP_EXCEPTION_CURRENCY_001, ExceptionCode.WARNING);
            }
        }

    }
}
