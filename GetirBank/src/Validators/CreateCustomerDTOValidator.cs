using FluentValidation;
using GetirBank.Dto;
using GetirBank.Exception;

namespace GetirBank.Validators
{
    public class CreateCustomerDtoValidator : ValidatorBase<CreateCustomerDTO>
    {
        public CreateCustomerDtoValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithState(_ => ErrorCodes.FirstNameMissing);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithState(_ => ErrorCodes.LastNameMissing);

            RuleFor(x => x.EmailId)
                .NotEmpty()
                .EmailAddress()
                .WithState(_ => ErrorCodes.EmailMissing);
            
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithState(_ => ErrorCodes.PasswordMissing);
        }
    }
}