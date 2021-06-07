using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCore.Bookstore.Domain.Interfaces.Repositories;
using AspNetCore.Bookstore.Domain.Notifications;
using MediatR;

namespace AspNetCore.Bookstore.Domain.Commands.Cliente
{
    public class HandlerCliente : IRequestHandler<CreateClienteCommand, Result>,
        IRequestHandler<UpdateClienteCommand, Result>,
        IRequestHandler<DeleteClienteCommand, Result>
    {

        private readonly IMediator _mediator;
        private readonly IClienteRepository _clienteRepository;

        public HandlerCliente(IMediator mediator, IClienteRepository clienteRepository)
        {
            _mediator = mediator;
            _clienteRepository = clienteRepository;
        }

        public async Task<Result> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
            {
                if (await _clienteRepository.GetById(request.Id) == null)
                {
                    await _clienteRepository.Add(new Entities.Cliente(
                        request.Nome, request.Email, request.Telefone));
                }
                else
                {
                    var message = "O ID do Cliente já exiiste.";
                    await _mediator.Publish(new Notification(message), cancellationToken);
                    result.AddError(message);
                }
            }
            else
            {
                await _mediator.Publish(new Notification(request.ValidationResult));
                result.AddErrors(GetErrors(request));
            }

            return result;
        }

        public async Task<Result> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
            {
                var cliente = await _clienteRepository.GetById(request.Id);

                if (cliente != null)
                {
                    cliente.Nome = request.Nome;
                    cliente.Email = request.Email;
                    cliente.Telefone = request.Telefone;
                    await _clienteRepository.Update(cliente);
                }
                else
                {
                    var message = "O Cliente não foi encontrado no sistema.";
                    await _mediator.Publish(new Notification(message), cancellationToken);
                    result.AddError(message);
                }
            }
            else
            {
                await _mediator.Publish(new Notification(request.ValidationResult));
                result.AddErrors(GetErrors(request));
            }

            return result;
        }

        public async Task<Result> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
            {
                var cliente = await _clienteRepository.GetById(request.Id);

                if (cliente != null)
                {
                    await _clienteRepository.Remove(cliente);
                }
                else
                {
                    var message = "O Cliente não foi encontrado no sistema.";
                    await _mediator.Publish(new Notification(message), cancellationToken);
                    result.AddError(message);
                }
            }
            else
            {
                await _mediator.Publish(new Notification(request.ValidationResult));
                result.AddErrors(GetErrors(request));
            }

            return result;
        }

        private IEnumerable<string> GetErrors(ClienteCommand request)
        {
            return request.ValidationResult.Errors.Select(err => err.ErrorMessage);
        }
    }
}