using System.Collections.Generic;
using System.Threading.Tasks;
using DominoApplication.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DominoApplication.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "api-version-16" };
        }

        
        [HttpPost("game")]
        public async Task Game(CreateGameCommand value)
        {
            Created("", await mediator.Send(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
