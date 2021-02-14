using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleOrganizer.Domain;
using SaleOrganizer.Application.Offerings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleOrganizer.Application.DTOs;

namespace SaleOrganizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<OfferingDto>>> Get() => await _mediator.Send(new Get.Query());

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferingDto>> Get(int id) => await _mediator.Send(new GetById.Query { Id = id });

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command) => await _mediator.Send(command);

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<Unit> Delete(int id) => await _mediator.Send(new Delete.Command { Id = id });
    }
}
