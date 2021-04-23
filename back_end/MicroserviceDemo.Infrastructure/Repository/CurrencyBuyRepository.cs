using System;
using System.Net;
using System.Threading.Tasks;
using VirtualMind.Core.Context;
using VirtualMind.Core.Entities;
using VirtualMind.Core.Exceptions;
using VirtualMind.Infrastructure.IRepository;

namespace VirtualMind.Infrastructure.Repository
{
    public class CurrencyBuyRepository : ICurrencyBuyRepository
    {

        private VirtualMindAPPDbContext context;


        public CurrencyBuyRepository(VirtualMindAPPDbContext context)
        {
            this.context = context;
        }

        public CurrencyBuyRepository() : this(new VirtualMindAPPDbContext())
        { }



        public async Task<CurrencyBuyEntity> SaveCurrencyBuy(CurrencyBuyEntity buyEntity)
        {
            try
            {
                buyEntity.TransactionDate = DateTime.Now;
                context.CurrencyBuy.Add(buyEntity);
                await context.SaveChangesAsync();
                return buyEntity;
            }
            catch (Exception e)
            {
                throw new BussinessException(HttpStatusCode.BadRequest, GenericMessages.DATA_APP_EXCEPTION, ExceptionCode.ERROR);
            }


        }
    }
}
