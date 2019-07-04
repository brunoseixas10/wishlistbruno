using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wishlist.Bo.Interfaces;

namespace Wishlist.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public sealed class ProductsController : ControllerBase
    {
        private readonly IProductBo _productBo;

        public ProductsController(IProductBo productBo)
        {
            _productBo = productBo;
        }

        [HttpGet()]
        public async Task<IActionResult> List(int pageSize, int page)
        {
            try
            {
                var res = await _productBo.List(pageSize, page);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Model.Signature.ProductSignature product)
        {
            try
            {
                await _productBo.Create(product);
                return Created(nameof(Create), product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}