using AutoMapper;
using AspNetCore.Bookstore.Domain.Entities;
using AspNetCore.Bookstore.Domain.Commands;
using AspNetCore.Bookstore.Domain.Commands.Book;
using AspNetCore.Bookstore.Domain.Commands.Cliente;

namespace AspNetCore.Bookstore.Application.AutoMapper.Profiles
{
    public class EntityToCommandProfile : Profile
    {
        public EntityToCommandProfile()
        {
            CreateMap<Book, CreateBookCommand>()
                .ReverseMap();

            CreateMap<Book, UpdateBookCommand>()
                .ReverseMap();


            CreateMap<Cliente, CreateClienteCommand>()
                .ReverseMap();

            CreateMap<Cliente, UpdateClienteCommand>()
                .ReverseMap();
        }
    }
}