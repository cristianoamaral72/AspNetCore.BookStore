using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AspNetCore.Bookstore.Data.Context;
using AspNetCore.Bookstore.Domain.Entities;
using AspNetCore.Bookstore.Domain.Interfaces.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
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
            using (var transaction = new TransactionScope())
            {
                var sql = $@"
                            INSERT INTO dbo.Cliente
                            (
                              Nome
                             ,Email
                             ,Telefone
                             ,DataCriacao
                            )
                            VALUES
                            (
                              'teste' -- Nome - varchar(250) NOT NULL
                             ,'cris12@gmail.com' -- Email - varchar(150) NOT NULL
                             ,'1147013217' -- Telefone - varchar(11)
                             ,GETDATE() -- 'YYYY-MM-DD hh:mm:ss[.nnnnnnn]'-- DataCriacao - datetime2 NOT NULL
                            );";

                var sqlSelect = $@"SELECT
                                          Id
                                         ,Nome
                                         ,Email
                                         ,Telefone
                                         ,DataCriacao
                                        FROM dbo.Cliente;";

                using (var connection = new  SqlConnection(""))
                {
                    connection.Open();

                    var affectedRows = connection.Execute(sql,commandTimeout:0, commandType: CommandType.Text);

                    var retorno = connection.Query(sqlSelect, commandTimeout: 0, commandType: CommandType.Text);
                }

                transaction.Complete();
            }

            return await Db.Cliente
                .Where(c => EF.Functions.Like(c.Nome, $"{nome}%"))
                .ToListAsync();
        }

        public async Task<Cliente> GetByEmail(string email)
        {
            return await Db.Cliente
                .FirstOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}