using FluentValidation;
using GetirBank.Dto;
using GetirBank.Exception;

namespace GetirBank.Validators
{
    public class CreateAccountRequestValidator : ValidatorBase<CreateAccountRequest>
    {
        public CreateAccountRequestValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.AccountType)
                .NotEmpty()
                .WithState(_ => ErrorCodes.AccountTypeMissing);
            RuleFor(x => x.Balance)
                .NotEmpty()
                .WithState(_ => ErrorCodes.AccountBalanceMising);
        }
    }
}