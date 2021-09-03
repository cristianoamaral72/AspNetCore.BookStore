using AspNetCore.Bookstore.Domain.Validations;

namespace AspNetCore.Bookstore.Domain.Commands.Book
{
    public class DeleteBookCommand : BookCommand
    {
        protected DeleteBookCommand() { }

        public DeleteBookCommand(int id)
        {
            ID = id;
        }
            

        public override bool IsValid()
        {
            var validation = new BookValidation();
            validation.ValidateID();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}