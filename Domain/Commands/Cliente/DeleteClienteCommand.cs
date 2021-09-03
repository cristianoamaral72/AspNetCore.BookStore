using AspNetCore.Bookstore.Domain.Validations;

namespace AspNetCore.Bookstore.Domain.Commands.Cliente
{
    public class DeleteClienteCommand : ClienteCommand
    {
        protected DeleteClienteCommand() { }
        public DeleteClienteCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            var validation = new ClienteValidation();
            validation.ValidateID();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}