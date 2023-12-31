﻿using ApplicationLayer.Abstract;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productmanager;
        public ProductController(IProductService productmanager, ILogger<ProductController> logger)
        {
            _productmanager = productmanager;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _productmanager.ProductGetList().ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Product> Get(short id)
        {
            if (id < 1)
                return BadRequest();

            if (_productmanager.ProductGetByID(id) == null)
                return NotFound();
            else
            {
                try
                {
                    _logger.LogInformation("Retrieving product data with ID {ProductId}.", id);
                    return _productmanager.ProductGetByID(id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error retrieving product data with ID {ProductId}.", id);
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Product employee)
        {
            _productmanager.ProductAdd(employee);
            _logger.LogInformation("Submitted product data {ProductId}", employee);
            return Ok(employee);

        }
        [HttpPut("{id}")]
        public ActionResult<List<Product>> Put(short id, Product employee)
        {
            _productmanager.ProductUpdate(employee);
            var updatedData = _productmanager.ProductGetList();
            _logger.LogInformation("Updated product data with ID {ProductId}.", id);
            return Ok(updatedData);
        }
        [HttpDelete("{id}")]
        public ActionResult<List<Product>> Delete(short id)
        {
            _productmanager.ProductDeleteByID(id);
            _logger.LogInformation("Deleted product data with ID {ProductId}.", id);
            return Ok();
        }


    }

}
