using Microsoft.AspNetCore.Mvc;
using ECommerce.ViewModels;
using ECommerce.Domain.Models;
using ECommerce.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/exchange")]
    public class ExchangeController : Controller
    {
        private readonly IExchangeService _service;

        public ExchangeController(IExchangeService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation("Get all exchanges")]
        public ActionResult<IEnumerable<Exchange>> GetAll()
        {
            var exchanges = _service.GetAll();
            return Ok(exchanges);
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation("Get an exchange by id")]
        public ActionResult<IEnumerable<Exchange>> Get([FromRoute] uint id)
        {
            var exchanges = _service.Get(id);
            return Ok(exchanges);
        }

        [HttpPost]
        [SwaggerOperation("Create a new exchange")]
        public IActionResult Add([FromBody] ExchangeRequest exchangeRequest)
        {
            var exchange = _service.Add(exchangeRequest);
            return Ok(exchange);
        }
    }
}
