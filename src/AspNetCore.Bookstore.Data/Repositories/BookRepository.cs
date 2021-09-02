using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Bookstore.Data.Context;
using AspNetCore.Bookstore.Domain.Entities;
using AspNetCore.Bookstore.Domain.Interfaces.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Bookstore.Data.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(BookstoreContext context) : base(context) { }

        public async Task<IEnumerable<Book>> FindBooksByAuthor(string author) =>
            await Db.Books
                .Where(b => EF.Functions.Like(b.Author, $"%{author}%"))
                .ToListAsync();

        public async Task<IList<Book>> FindBooks(string author)
        {
            using (var conn = new SqlConnection("Data Source=LAPTOP-LRI8BP6O;User ID=sad; password=12345678; Initial Catalog=Bookstore;Integrated Security=True"))
            {
                await conn.OpenAsync();
                var sqlSelect = $@"Select * From Book where Author = '{author}'";
                return conn.Query<Book>(sqlSelect, commandTimeout: 0, commandType:CommandType.Text).ToList(); 
            }
        }

        public async Task<Book> GetByTitle(string title) =>
            await Db.Books
                .FirstOrDefaultAsync(b => b.Title.Equals(title));
    }
}