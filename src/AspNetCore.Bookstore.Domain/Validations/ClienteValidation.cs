using AspNetCore.Bookstore.Domain.Commands.Cliente;
using FluentValidation;

namespace AspNetCore.Bookstore.Domain.Validations
{
    public class ClienteValidation : AbstractValidator<ClienteCommand>
    {
        public void ValidateID()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("O ID deve ser maior que zero");
        }

        public void ValidateNome()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O Nome não pode está vazio!")
                .MaximumLength(250).WithMessage("O Nome deve ter no máximo 250 caracteres");
        }

        public void ValidateEmail()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O Email não pode está vazio!")
                .MaximumLength(50).WithMessage("O Nome deve ter no máximo 50 caracteres");
        }

        public void ValidateTelefone()
        {
            RuleFor(p => p.Telefone)
                .NotEmpty().WithMessage("O Telefone não pode está vazio!")
                .MaximumLength(11).WithMessage("O Nome deve ter no máximo 11 caracteres");
        }
    }
}