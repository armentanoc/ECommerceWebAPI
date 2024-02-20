using Microsoft.AspNetCore.Mvc;
using ECommerce.ViewModels;
using ECommerce.Domain.Models;
using ECommerce.Application.Interfaces;

namespace ECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/refunds")]
    public class RefundController : Controller
    {
        private readonly IRefundService _service;

        public RefundController(IRefundService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Refund>> GetAll()
        {
            var refund = _service.GetAll();
            return Ok(refund);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<IEnumerable<Refund>> Get([FromRoute] uint id)
        {
            var refund = _service.Get(id);
            return Ok(refund);
        }

        [HttpPost]
        public IActionResult Add([FromBody] RefundRequest request)
        {
            var refund = _service.Add(request);
            return Ok(refund);
        }
    }
}
