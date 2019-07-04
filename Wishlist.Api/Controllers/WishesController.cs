using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wishlist.Bo.Interfaces;

namespace Wishlist.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public sealed class WishesController : ControllerBase
    {
        private readonly IWishlistBo _wishlistBo;

        public WishesController(IWishlistBo wishlistBo)
        {
            _wishlistBo = wishlistBo;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> List(int userId, int pageSize, int page)
        {
            try
            {
                var res = await _wishlistBo.List(userId, pageSize, page);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Create(int userId, [FromBody] Model.Signature.WishlistSignature wishlist)
        {
            try
            {
                wishlist.UserId = userId;
                await _wishlistBo.Create(wishlist);
                return Created(nameof(Create), wishlist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{userId}/{productId}")]
        public async Task<IActionResult> Remove(int userId, int productId)
        {
            try
            {
                await _wishlistBo.Remove(userId, productId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}