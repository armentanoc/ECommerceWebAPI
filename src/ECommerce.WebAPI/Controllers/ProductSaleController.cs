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
        [SwaggerOperation("Get complete sale information")]
        public ActionResult<IEnumerable<object>> GetAll()
        {
            var relations = _service.GetCompleteProductSaleInformation();
            return Ok(relations);
        }
    }
}
