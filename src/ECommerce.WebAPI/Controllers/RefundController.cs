using Microsoft.AspNetCore.Mvc;
using ECommerce.ViewModels;
using ECommerce.Domain.Models;
using ECommerce.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/refund")]
    public class RefundController : Controller
    {
        private readonly IRefundService _service;

        public RefundController(IRefundService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation("Get all refunds")]
        public ActionResult<IEnumerable<Refund>> GetAll()
        {
            var refund = _service.GetAll();
            return Ok(refund);
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation("Get a refund by id")]
        public ActionResult<IEnumerable<Refund>> Get([FromRoute] uint id)
        {
            var refund = _service.Get(id);
            return Ok(refund);
        }

        [HttpPost]
        [SwaggerOperation("Create a new refund")]
        public IActionResult Add([FromBody] RefundRequest request)
        {
            var refund = _service.Add(request);
            return Ok(refund);
        }
    }
}
