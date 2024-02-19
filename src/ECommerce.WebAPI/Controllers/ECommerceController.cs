using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
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
    }
}
