using GAP.Cqrs.Implementation.Command.UsuarioPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers.Seguridad
{
    public class RefreshTokensController : ApiControllerBase
    {
        private RefreshTokenFactory _factory;

        public RefreshTokensController()
        {
            _factory = new RefreshTokenFactory();
        }

      

        //[Authorize(Users = "Admin")]
        [AllowAnonymous]
        [Route("")]
        public async Task<IHttpActionResult> Delete(string tokenId)
        {
            var result = await _factory.RemoveRefreshToken(tokenId);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Token Id does not exist");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _factory.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
