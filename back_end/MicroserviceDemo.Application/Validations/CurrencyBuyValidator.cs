using FluentValidation;
using VirtualMind.Application.Dtos;

namespace VirtualMind.Application.Validations
{
    public class CurrencyBuyValidator : AbstractValidator<CurrencyBuyDto>
    {

        public CurrencyBuyValidator()
        {
            RuleFor(m => m.UserId).NotEmpty().WithMessage($"{ValidatorMessages.NOT_EMPTY_MESSAGE}{"'UserId'"}");
            RuleFor(m => m.CurrencyType).IsInEnum().WithMessage($"{ValidatorMessages.NOT_IN_ENUM_MESSAGE}{"'CurrencyType'"}"); //--> Cualquier otra moneda solicitada deberá responderse con un error y mensaje apropiado.
            RuleFor(m => m.CurrencyLocalAmount).NotEmpty().WithMessage($"{ValidatorMessages.NOT_EMPTY_MESSAGE}{"'CurrencyLocalAmount'"}");
            //RuleFor(m => m.CurrencyForeignAmount).NotEmpty().WithMessage($"{ValidatorMessages.NOT_EMPTY_MESSAGE}{"'CurrencyForeignAmount'"}");
        }
    }
}
