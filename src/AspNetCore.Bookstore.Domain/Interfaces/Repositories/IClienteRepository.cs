using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.Bookstore.Domain.Entities;

namespace AspNetCore.Bookstore.Domain.Interfaces.Repositories
{
    public interface IClienteRepository: IRepositoryBase<Cliente>
    {
        Task<IEnumerable<Cliente>> FindClientesByNome(string nome);
        Task<Cliente> GetByEmail(string email);
    }
}