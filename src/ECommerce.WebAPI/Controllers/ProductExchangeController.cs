using Microsoft.AspNetCore.Mvc;
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
        [SwaggerOperation("Get all exchange information")]
        public ActionResult<IEnumerable<object>> GetAll()
        {
            var relations = _service.GetAllExchangeInformation();
            return Ok(relations);
        }
    }
}
