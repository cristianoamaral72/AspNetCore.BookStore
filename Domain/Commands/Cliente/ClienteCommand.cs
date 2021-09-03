using AspNetCore.Bookstore.Domain.Interfaces.Commands;
using AspNetCore.Bookstore.Domain.Validations;
using FluentValidation.Results;
using MediatR;

namespace AspNetCore.Bookstore.Domain.Commands.Cliente
{
    public abstract class ClienteCommand : IRequest<Result>, ICommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            var validation = new ClienteValidation();

            validation.ValidateNome();
            validation.ValidateEmail();
            validation.ValidateTelefone();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}