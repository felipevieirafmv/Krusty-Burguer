namespace back.Controllers;

using DTO;
using Back.Services;
using Trevisharp.Security.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Threading.Tasks;
using System.Collections.Generic;

[ApiController]
[Route("promocao")]
public class PromoController : ControllerBase
{
    [HttpPost("cadastro")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Create(
        [FromBody]PromoObj obj,
        [FromServices]IPromoService service,
        [FromServices]CryptoService crypto)
    {
        var errors = new List<string>();
        var promo = obj.data;
        // var jwtEmObj = crypto.Validate<Payload>(obj.Jwt.Replace("\"", ""));

        await service.Create(promo);
        return Ok();
    }
}