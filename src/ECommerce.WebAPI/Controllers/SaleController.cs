﻿using Microsoft.AspNetCore.Mvc;
using ECommerce.ViewModels;
using ECommerce.Domain.Models;
using ECommerce.Application.Interfaces;

namespace ECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class SaleController : Controller
    {
        private readonly ISaleService _service;

        public SaleController(ISaleService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Sale>> GetAll()
        {
            var sales = _service.GetAll();
            return Ok(sales);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<IEnumerable<Sale>> Get([FromRoute] uint id)
        {
            var sale = _service.Get(id);
            return Ok(sale);
        }

        [HttpPost]
        public IActionResult Add([FromForm] SaleRequest saleRequest)
        {
            var sale = _service.Add(saleRequest);
            return Ok(sale);
        }
    }
}