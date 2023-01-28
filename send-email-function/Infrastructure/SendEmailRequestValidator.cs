using FluentValidation;
using send_email_function.Domain;

namespace send_email_function.Infrastructure
{
    public class SendEmailRequestValidator : AbstractValidator<SendEmailRequest>
    {
        public SendEmailRequestValidator()
        {
            RuleFor(x => x.Recipient)
                .NotEmpty()
                .WithMessage("Recipient must not be empty")
                .NotNull()
                .WithMessage("Recipient must not be null")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .WithMessage("Recipient is in an invalid format");

            RuleFor(x => x.Subject)
                .NotEmpty()
                .WithMessage("Subject must not be empty")
                .NotNull()
                .WithMessage("Subject must not be null")
                .MinimumLength(5)
                .MaximumLength(70);

            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage("Message must not be empty")
                .NotNull()
                .WithMessage("Message must not be null")
                .MaximumLength(20000);

            When(x => x.CCs != null, () =>
            {
                RuleForEach(x => x.CCs)
                    .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                    .WithMessage("Recipient not be in correct format");
            });

        }
    }
}
