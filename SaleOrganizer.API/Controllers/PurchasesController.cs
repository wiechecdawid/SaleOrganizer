using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleOrganizer.Application.DTOs;
using SaleOrganizer.Application.Purchases;
using SaleOrganizer.Domain;
//using SaleOrganizer.Application.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOrganizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PurchasesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PurchaseDto>>> Get() => await _mediator.Send(new Get.Query());

        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseDto>> Get(int id) => await _mediator.Send(new GetById.Query { Id = id });

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command) => await _mediator.Send(command);

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id) => await _mediator.Send(new Delete.Command { Id = id });

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}
