using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Poc.Net.Mongo.Api.Controllers.Client.v1.Models.Requests;
using Poc.Net.Mongo.Api.Controllers.Client.v1.Models.Responses;
using Poc.Net.Mongo.Domain.Interfaces.Services;

namespace Poc.Net.Mongo.Api.Controllers.Client.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _service;

        public ClientController(ILogger<ClientController> logger, IClientService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] ClientBaseFilter filter)
        {
            _logger.LogInformation($"Starting {nameof(ClientController)}-{nameof(Get)}");
            var response = await _service.GetClient(x => x.Document.ToLowerInvariant() == filter.Document.ToLowerInvariant());
            _logger.LogInformation($"Finishing {nameof(ClientController)}-{nameof(Get)}");
            return response is null ? NotFound() : Ok(response);
        }

        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClientResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] ClientFilter filter)
        {
            _logger.LogInformation($"Starting {nameof(ClientController)}-{nameof(GetAll)}");
            var response = await _service.GetAllClients(x => x.Name.ToLowerInvariant().Contains(filter.Name.ToLowerInvariant()) && x.Document.ToLowerInvariant().Contains(filter.Document.ToLowerInvariant()));
            _logger.LogInformation($"Finishing {nameof(ClientController)}-{nameof(GetAll)}");
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ClientRequest request)
        {
            _logger.LogInformation($"Starting {nameof(ClientController)}-{nameof(Post)}");
            await _service.AddClient(new(request.Name, request.Document, request.BirthDate));
            _logger.LogInformation($"Finishing {nameof(ClientController)}-{nameof(Post)}");
            return Created();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromQuery] string document)
        {
            _logger.LogInformation($"Starting {nameof(ClientController)}-{nameof(Delete)}");
            var response = await _service.RemoveClient(x => x.Document.ToLowerInvariant().Equals(document));
            _logger.LogInformation($"Finishing {nameof(ClientController)}-{nameof(Delete)}");
            return response ? Ok() : NotFound();
        }
    }
}
