using FluentValidation;
using GetirBank.Dto;
using GetirBank.Exception;

namespace GetirBank.Validators
{
    public class LoginRequestValidator : ValidatorBase<LoginRequest>
    {
        public LoginRequestValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.EmailId)
                .EmailAddress()
                .NotEmpty()
                .WithState(_ => ErrorCodes.EmailMissing);
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithState(_ => ErrorCodes.PasswordMissing);
        }
    }
}