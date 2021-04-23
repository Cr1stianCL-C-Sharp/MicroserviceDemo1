using FluentValidation;
using VirtualMind.Application.Dtos;

namespace VirtualMind.API.Validations
{
    public class CurrencyValidator : AbstractValidator<CurrencyDto>
    {
        public CurrencyValidator()
        {
            RuleFor(m => m.Informal).NotEmpty();
            RuleFor(m => m.Observed).NotEmpty();
            RuleFor(m => m.Information).NotEmpty();
        }

    }
}
