using FluentValidation;
using Poc.Net.Mongo.Domain.Documents;

namespace Poc.Net.Mongo.Domain.Validators
{
    public class ClientDocumentValidator : AbstractValidator<Client>
    {
        public ClientDocumentValidator()
        {
            RuleFor(x => x.Document)
                .NotEmpty()
                .MinimumLength(11)
                .MaximumLength(14)
                .WithMessage("Invalid document lenght for client");

            RuleFor(x => x.Document)
                .Must(ValidDocument)
                .WithMessage("Invalid document!");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Client's name must be informed!");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("Client's birth date must be informed!");
        }

        private bool ValidDocument(string document)
        {
            if(document.Length == 11)
                return true;
            else if(document.Length == 14)
                return true;

            return false;
        }
    }
}
