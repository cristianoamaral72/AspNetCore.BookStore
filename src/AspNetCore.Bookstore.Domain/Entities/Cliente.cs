using System;

namespace AspNetCore.Bookstore.Domain.Entities
{
    public class Cliente
    {
        public Cliente(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DataCriacao = DateTime.Now;
        }
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}