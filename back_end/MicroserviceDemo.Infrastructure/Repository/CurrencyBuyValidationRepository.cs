using System;
using System.Linq;
using System.Threading.Tasks;
using VirtualMind.Core.Context;
using VirtualMind.Core.Enums;
using VirtualMind.Core.Exceptions;
using VirtualMind.Infrastructure.IRepository;

namespace VirtualMind.Infrastructure.Repository
{
    public class CurrencyBuyValidationRepository : ICurrencyBuyValidationRepository
    {
        private readonly VirtualMindAPPDbContext context;


        public CurrencyBuyValidationRepository(VirtualMindAPPDbContext context)
        {
            this.context = context;
        }

        public CurrencyBuyValidationRepository() : this(new VirtualMindAPPDbContext())
        { }


        public async Task<bool> ValidateCurrencyBuyAmount(Guid UserId, Currency currentCurrency)
        {

            try
            {
                /*
                 Se necesita validar los montos a comprar. Para el dólar, el límite es 200. Para el real,
                   el límite es 300. Todos los límites son en la moneda extranjera, por usuario y por mes.                 
                 */

                var today = DateTime.Now;
                var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
                var lastDayOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

                var sum = this.context.CurrencyBuy.Where(user => user.UserId == UserId
                                                                 && user.CurrencyType == currentCurrency
                                                                 && user.TransactionDate >= firstDayOfMonth
                                                                 && user.TransactionDate <= lastDayOfMonth)
                    .Select(c => c.CurrencyForeignAmount).Sum();

                switch (currentCurrency)
                {
                    case Currency.USD:
                        return sum < 200;
                    case Currency.BRL:
                        return sum < 300;
                    default:
                        return false;
                }


            }
            catch (Exception e)
            {
                throw new ApplicationException(GenericMessages.DATA_APP_EXCEPTION);
            }

        }

    }
}
