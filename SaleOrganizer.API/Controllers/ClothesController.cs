using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleOrganizer.Application.Clothes;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;

namespace SaleOrganizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        public readonly IMediator _mediator;
        public ClothesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<ActionResult<List<Cloth>>> Get()
        {
            return await _mediator.Send(new Get.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cloth>> Get(int id)
        {
            return await _mediator.Send(new GetById.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new Delete.Command { Id = id });
        }
    }
}
