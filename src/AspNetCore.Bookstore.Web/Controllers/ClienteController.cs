using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Bookstore.Domain;
using AspNetCore.Bookstore.Domain.Commands.Cliente;
using AspNetCore.Bookstore.Domain.Entities;
using AspNetCore.Bookstore.Domain.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace AspNetCore.Bookstore.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IMediator mediator, IClienteRepository clienteRepository, IMapper mapper)
        {
            _mediator = mediator;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            var response = await _clienteRepository.GetAll();
            return View(response);
        }

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            
            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateClienteCommand request)
        {
            var result = await _mediator.Send(request);
            return ResultResponse(request, result);
        }
    

        // GET: ClienteController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteRepository.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            var command = _mapper.Map<UpdateClienteCommand>(cliente);
            return View(command);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateClienteCommand request)
        {
            var result = await _mediator.Send(request);
            return ResultResponse(request, result);
        }

        // GET: ClienteController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Cliente cliente)
        {
            var request = new DeleteClienteCommand(cliente.Id);
            var result = await _mediator.Send(request);
            return ResultResponse(request, result);
        }

        private ActionResult ResultResponse(ClienteCommand request, Result result)
        {
            if (result.HasErrors)
            {
                result.Errors.ToList().ForEach(err => ModelState.AddModelError(String.Empty, err));
                return View(request);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
