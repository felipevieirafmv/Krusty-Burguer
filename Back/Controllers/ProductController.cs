using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers;

using DTO;
using Back.Model;
using Back.Services;
using Trevisharp.Security.Jwt;
using System.Security.Principal;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

[ApiController]
[Route("produto")]
public class ProductController : ControllerBase
{
    [HttpPost("cadastro")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Create(
        [FromBody]ProductObj obj,
        [FromServices]IProductService service,
        [FromServices]CryptoService crypto)
    {
        var errors = new List<string>();
        var prod = obj.data;
        var jwtEmObj = crypto.Validate<Payload>(obj.Jwt.Replace("\"", ""));

        if (!jwtEmObj.Adm)
            errors.Add("Usuário não é um adm");
        else
        {
            if (prod is null || prod.Nome is null)
                errors.Add("É necessário informar um nome.");
            if (prod.Descricao is null)
                errors.Add("É necessário informar uma descrição.");
            if (prod.Preco <=0)
                errors.Add("É necessário informar um preço.");
            if (prod.Tipo is null)
                errors.Add("É necessário informar um tipo.");
        }
        
        
        if (errors.Count > 0)
            return BadRequest(errors);

        Console.WriteLine(jwtEmObj.Adm);

        await service.Create(prod);
        return Ok();
    }

    [HttpGet()]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Get(
        [FromServices]IProductService service)
        {
            var a = await service.GetProdutos();
            var errors = new List<string>();
            if (errors.Count > 0)
                return BadRequest(errors);

            return Ok(a);
        }
}