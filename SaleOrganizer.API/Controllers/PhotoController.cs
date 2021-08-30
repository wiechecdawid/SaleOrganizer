using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaleOrganizer.Application.Photos;
using SaleOrganizer.Domain;

namespace SaleOrganizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController: ControllerBase
    {
        private readonly IMediator _mediator;

        public PhotoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Photo>> Add([FromQuery]int clothId, [FromForm]Add.Command command)
        {
            command.ClothId = clothId;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(string id) => await _mediator.Send(new Delete.Command{ Id = id });
    }
}