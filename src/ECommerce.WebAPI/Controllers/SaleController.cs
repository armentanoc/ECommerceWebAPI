using Microsoft.AspNetCore.Mvc;
using ECommerce.ViewModels;
using ECommerce.Domain.Models;
using ECommerce.Application.Interfaces;

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
        public ActionResult<IEnumerable<Sale>> GetAll()
        {
            var sales = _service.GetAll();
            return Ok(sales);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<IEnumerable<Sale>> Get([FromRoute] uint id)
        {
            var sale = _service.Get(id);
            return Ok(sale);
        }

        [HttpPost]
        public IActionResult Add([FromBody] SaleRequest saleRequest)
        {
            if (_service.Add(saleRequest) is Sale sale) 
                return Ok(sale);
            return BadRequest(saleRequest);
        }
    }
}
