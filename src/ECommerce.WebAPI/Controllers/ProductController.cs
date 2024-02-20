using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var products = _service.GetAll();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] uint id)
        {
            var product = _service.Get(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add([FromForm] ProductRequest request)
        {
            if (_service.Add(request)) return Ok(request);
            return BadRequest();
        }
    }
}
