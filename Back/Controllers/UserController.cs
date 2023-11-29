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
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost("login")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Login(
        [FromBody]UserDataLogin user,
        [FromServices]IUserService service,
        [FromServices]ISecurityService security,
        [FromServices]CryptoService crypto)
    {
        var loggedUser = await service.GetByLogin(user.Login);

        if (loggedUser == null)
            return Unauthorized("Usuário não existe.");
        
        var password = await security.HashPassword(
            user.Password, loggedUser.Salt
        );
        var realPassword = loggedUser.Senha;
        if (password != realPassword)
            return Unauthorized("Senha incorreta.");
        
        var jwt = crypto.GetToken(new {
            id = loggedUser.Id,
            Adm = loggedUser.Adm
        });

        return Ok(new{ jwt, loggedUser.Adm, loggedUser.Nome});
    }

    [HttpPost("cadastro")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Create(
        [FromBody]UserDataCadastro user,
        [FromServices]IUserService service)
    {
        var errors = new List<string>();
        if (user is null || user.Login is null)
            errors.Add("É necessário informar um login.");
        if (user.Login.Length < 5)
            errors.Add("O Login deve conter no mínimo 5 caracteres");
        
        if (errors.Count > 0)
            return BadRequest(errors);
        
        await service.Create(user);
        return Ok();
        
    }
}
