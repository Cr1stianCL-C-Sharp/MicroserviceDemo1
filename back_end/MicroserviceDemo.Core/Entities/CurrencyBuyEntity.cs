using System;
using VirtualMind.Core.Enums;

namespace VirtualMind.Core.Entities
{
    public class CurrencyBuyEntity
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public Currency CurrencyType { get; set; }

        public decimal CurrencyLocalAmount { get; set; }

        public decimal CurrencyForeignAmount { get; set; }


        public decimal TransactionAmount { get; set; }

        public DateTime TransactionDate { get; set; }

    }
}
