using Microsoft.AspNetCore.Mvc;
using ECommerce.Domain.Models;
using ECommerce.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/productSale")]
    public class ProductSaleController : Controller
    {
        private readonly IProductSaleService _service;

        public ProductSaleController(IProductSaleService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation("Get all product-exchange relations")]
        public ActionResult<IEnumerable<ProductSale>> GetAll()
        {
            var relations = _service.GetAll();
            return Ok(relations);
        }
    }
}
