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
        private readonly IBookRepository _bookRepository;

        public ClienteRepository(BookstoreContext context, IBookRepository bookRepository) : base(context)
        {
            _bookRepository = bookRepository;
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
                
                var sqlUpdate = $@"
                                UPDATE Cliente
                                SET 
                                   Nome = 'teste Elton 2020'
                                   ,Email = 'cris120@gmail.com'
                                   ,Telefone = '1147013218'
                                WHERE Id = 13";

                var sqlSelect = $@"SELECT
                                          Id
                                         ,Nome
                                         ,Email
                                         ,Telefone
                                         ,DataCriacao
                                        FROM dbo.Cliente;";

                // Insert
                using (var connection = new  SqlConnection("Data Source=LAPTOP-LRI8BP6O;User ID=sad; password=12345678; Initial Catalog=Bookstore;Integrated Security=True"))
                {
                    connection.Open();
                    var affectedRows = connection.Execute(sql,commandTimeout:0, commandType: CommandType.Text);
                }

                var dadosBook = await _bookRepository.FindBooks("Robert C. Martin");

                // Update
                using (var connection = new SqlConnection("Data Source=LAPTOP-LRI8BP6O;User ID=sad; password=12345678; Initial Catalog=Bookstore;Integrated Security=True"))
                {
                    connection.Open();
                    var affectedRows = connection.Execute(sqlUpdate, commandTimeout: 0, commandType: CommandType.Text);
                }

                // Select
                using (var connection = new SqlConnection("Data Source=LAPTOP-LRI8BP6O;User ID=sad; password=12345678; Initial Catalog=Bookstore;Integrated Security=True"))
                {
                    connection.Open();
                    var retorno = connection.Query(sqlSelect, commandTimeout: 0, commandType: CommandType.Text);
                }

                transaction.Complete();
            }

            //return await Db.Cliente
            //    .Where(c => EF.Functions.Like(c.Nome, $"{nome}%"))
            //    .ToListAsync();
            return default;
        }

        public async Task<Cliente> GetByEmail(string email)
        {
            return await Db.Cliente
                .FirstOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}