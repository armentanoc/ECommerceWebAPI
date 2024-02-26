using Microsoft.AspNetCore.Mvc;
using ECommerce.Domain.Models;
using ECommerce.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/productExchange")]
    public class ProductExchangeController : Controller
    {
        private readonly IProductExchangeService _service;

        public ProductExchangeController(IProductExchangeService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation("Get all product-exchange relations")]
        public ActionResult<IEnumerable<ProductExchange>> GetAll()
        {
            var relations = _service.GetAll();
            return Ok(relations);
        }
    }
}
