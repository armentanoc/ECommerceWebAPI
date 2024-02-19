using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class ECommerceController : Controller
    {
        private readonly IProductService _service;

        public ECommerceController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var products = _service.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Add(ProductRequest request)
        {
            if (_service.Add(request)) return Ok(request);
            return BadRequest();
        }
    }
}
