using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = productService.GetList();
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet("getlistbycategory")]
        public IActionResult GetListByCategory(int categoryId)
        {
            var result = productService.GetListByCategory(categoryId);
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = productService.GetById(id);
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }


        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = productService.Add(product);
            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(Product product)
        {
            var result = productService.Update(product);
            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Product product)
        {
            var result = productService.Delete(product);
            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("transaction")]
        public IActionResult Transaction(Product product)
        {
            var result = productService.Transaction(product);
            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }
    }
}
