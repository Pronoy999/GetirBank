using FluentValidation;
using GetirBank.Dto;
using GetirBank.Exception;

namespace GetirBank.Validators
{
    public class TransactionRequestValidator : ValidatorBase<TransactionRequest>
    {
        public TransactionRequestValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.AccountId)
                .NotEmpty()
                .WithState(_ => ErrorCodes.AccountIdMissing);

            RuleFor(x => x.Balance)
                .NotEmpty()
                .WithState(_ => ErrorCodes.AccountBalanceMissing);
            RuleFor(x => x.TransactionType)
                .NotEmpty()
                .WithState(x => ErrorCodes.TransactionTypeMissing);
        }
    }
}