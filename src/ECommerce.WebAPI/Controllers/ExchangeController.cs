using Microsoft.AspNetCore.Mvc;
using ECommerce.ViewModels;
using ECommerce.Domain.Models;
using ECommerce.Application.Interfaces;

namespace ECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/exchanges")]
    public class ExchangeController : Controller
    {
        private readonly IExchangeService _service;

        public ExchangeController(IExchangeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Exchange>> GetAll()
        {
            var exchanges = _service.GetAll();
            return Ok(exchanges);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<IEnumerable<Exchange>> Get([FromRoute] uint id)
        {
            var exchanges = _service.Get(id);
            return Ok(exchanges);
        }

        [HttpPost]
        public IActionResult Add([FromForm] ExchangeRequest exchangeRequest)
        {
            var exchange = _service.Add(exchangeRequest);
            return Ok(exchange);
        }
    }
}
