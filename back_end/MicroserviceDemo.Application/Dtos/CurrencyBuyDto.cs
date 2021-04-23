using System;
using VirtualMind.Core.Enums;

namespace VirtualMind.Application.Dtos
{
    public class CurrencyBuyDto
    {
        public Guid UserId { get; set; }

        public Currency CurrencyType { get; set; }

        public decimal CurrencyLocalAmount { get; set; }

    }
}
