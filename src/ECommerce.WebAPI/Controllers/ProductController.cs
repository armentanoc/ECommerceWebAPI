using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ECommerce.ViewModels.Requests;

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
        [SwaggerOperation("Get all products")]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var products = _service.GetAll();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation("Get a product by id")]
        public IActionResult Get([FromRoute] uint id)
        {
            var product = _service.Get(id);
            return Ok(product);
        }

        [HttpPost]
        [SwaggerOperation("Create a new product")]
        public IActionResult Add([FromBody] ProductRequest request)
        {
            if (_service.Add(request) is Product product) 
                return Ok(product);
            return BadRequest(request);
        }

        [HttpPut]
        [Route("{id}")]
        [SwaggerOperation("Update a product")]
        public IActionResult Update([FromBody] ProductRequest request, uint id)
        {
            if (_service.Update(request, id) is Product product)
                return Ok(product);
            return BadRequest(request);
        }

        [HttpGet]
        [Route("filter")]
        [SwaggerOperation("Filter a product by word in name")]
        public ActionResult<IEnumerable<Product>> FilterByName([FromQuery] string name)
        {
            var filteredProducts = _service.FilterByName(name);
            return Ok(filteredProducts);
        }

        [HttpDelete]
        [Route("{id}")]
        [SwaggerOperation("Delete a product")]
        public IActionResult Delete([FromRoute] uint id)
        {
            if (_service.Delete(id))
                return NoContent();
            return BadRequest();
        }
    }
}
