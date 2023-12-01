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
using System.Security.Cryptography;
using Trevisharp.Security.Jwt;

[ApiController]
[Route("produto")]
public class ProductController : ControllerBase
{
    [HttpPost("cadastro")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Create(
        [FromBody]ProductData produto,
        [FromServices]IProductService service)
    {
        var errors = new List<string>();
        if (produto is null || produto.Nome is null)
            errors.Add("É necessário informar um nome.");
        if (produto.Descricao is null)
            errors.Add("É necessário informar uma descrição");
        if (produto.Preco <=0)
            errors.Add("É necessário informar um preço");
        
        if (errors.Count > 0)
            return BadRequest(errors);
        
        await service.Create(produto);
        return Ok();
    }
}