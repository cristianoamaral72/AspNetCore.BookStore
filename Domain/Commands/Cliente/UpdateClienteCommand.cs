namespace AspNetCore.Bookstore.Domain.Commands.Cliente
{
    public class UpdateClienteCommand: ClienteCommand
    {
        public UpdateClienteCommand() { }
        
        public UpdateClienteCommand(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}