using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Bookstore.Data.Context;
using AspNetCore.Bookstore.Domain.Entities;
using AspNetCore.Bookstore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Bookstore.Data.Repositories
{
    public class ClienteRepository: RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(BookstoreContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cliente>> FindClientesByNome(string nome)
        {
            return await db.Cliente
                .Where(c => EF.Functions.Like(c.Nome, $"{nome}%"))
                .ToListAsync();
        }

        public async Task<Cliente> GetByEmail(string email)
        {
            return await db.Cliente
                .FirstOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}