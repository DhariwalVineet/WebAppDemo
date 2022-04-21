using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private ProductRepository _ProductRepository;

        public ProductsController()
        {
            _ProductRepository = ProductRepository.Instance;

        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _ProductRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult FindProductById(int id)
        {
            var product = _ProductRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("{name}")]
        public IActionResult GetProductByName(string name)
        {
            var product = _ProductRepository.GetProductByName(name);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDto productDto)
        {
            var addedProduct = _ProductRepository.AddProduct(productDto);
            var uri = new Uri(Request.GetDisplayUrl().ToString() + addedProduct.Id);
            return Created(uri, addedProduct);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductDto productDto)
        {
            var addedProduct = _ProductRepository.UpdateProduct(productDto);

            return Ok(addedProduct);
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            var getProduct = _ProductRepository.GetProductById(productId);

            if (getProduct == null)
            {
                return NotFound();
            }

            _ProductRepository.DeleteProduct(productId);
            return Ok();
        }
    }

}