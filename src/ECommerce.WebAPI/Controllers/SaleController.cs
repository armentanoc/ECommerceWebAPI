using Microsoft.AspNetCore.Mvc;
using ECommerce.ViewModels;
using ECommerce.Domain.Models;
using ECommerce.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/sale")]
    public class SaleController : Controller
    {
        private readonly ISaleService _service;

        public SaleController(ISaleService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation("Get all sales")]
        public ActionResult<IEnumerable<Sale>> GetAll()
        {
            var sales = _service.GetAll();
            return Ok(sales);
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation("Get a sale by id")]
        public ActionResult<IEnumerable<Sale>> Get([FromRoute] uint id)
        {
            var sale = _service.Get(id);
            return Ok(sale);
        }

        [HttpPost]
        [SwaggerOperation("Create a new sale")]
        public IActionResult Add([FromBody] SaleRequest saleRequest)
        {
            if (_service.Add(saleRequest) is Sale sale) 
                return Ok(sale);
            return BadRequest(saleRequest);
        }
    }
}
