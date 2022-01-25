using FluentValidation;
using GetirBank.Dto;
using GetirBank.Exception;

namespace GetirBank.Validators
{
    public class TransactionQueryRequestValidator : ValidatorBase<TransactionQueryRequest>
    {
        public TransactionQueryRequestValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.AccountId)
                .NotEmpty()
                .WithState(_ => ErrorCodes.AccountIdMissing);
            RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithState(_ => ErrorCodes.StartDateMissing);
            RuleFor(x => x.EndDate)
                .NotEmpty()
                .WithState(_ => ErrorCodes.EndDateMissing);
        }
    }
}