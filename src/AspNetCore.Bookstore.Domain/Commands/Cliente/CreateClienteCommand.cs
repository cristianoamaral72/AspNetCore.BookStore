using System;

namespace AspNetCore.Bookstore.Domain.Commands.Cliente
{
    public class CreateClienteCommand: ClienteCommand
    {

        public CreateClienteCommand() { }

        public CreateClienteCommand(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

    }
}