using AspNetCore.Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Bookstore.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Telefone)
                .HasColumnType("varchar(11)");

            builder.Property(x => x.DataCriacao)
                .HasColumnType("datetime2");

            //builder.HasData(
            //    new Cliente("Maria de Fatima", "maria@gmail.com", "11965183160"));

        }
    }
}