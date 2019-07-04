using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wishlist.Bo.Interfaces;

namespace Wishlist.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public sealed class UsersController : ControllerBase
    {
        private readonly IUserBo _userBo;

        public UsersController(IUserBo userBo)
        {
            _userBo = userBo;
        }

        [HttpGet()]
        public async Task<IActionResult> List(int pageSize, int page)
        {
            try
            {
                var res = await _userBo.List(pageSize, page);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Model.Signature.UserSignature user)
        {
            try
            {
                await _userBo.Create(user);
                return Created(nameof(Create), user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}