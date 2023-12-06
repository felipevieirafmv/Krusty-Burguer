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
using System.Text.RegularExpressions;

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

        // validaCpf(user.Cpf);
        
        if (errors.Count > 0)
            return BadRequest(errors);
        
        await service.Create(user);
        return Ok();
        
    }
    
    // public bool validaCpf(string cpf)
    // {
    //     var soma1 = 0;
    //     var digi1 = 0;
    //     var soma2 = 0;
    //     var digi2 = 0;
    //     var verifica = true;
    //     var cpfLimpo = Regex.Replace(cpf, @"[^\d]", "");

    //     for(int i = 0; i < 10; i++)
    //     {
    //         if(cpfLimpo[i] != cpfLimpo[i + 1])
    //         {
    //             verifica = true;
    //             break;
    //         }
    //         else
    //             verifica = false;
    //     }

    //     if(cpfLimpo.Length == 11 && verifica == true)
    //     {
    //         for(int i = 0, j = 10; i < 9; i++, j--)
    //             soma1 += cpfLimpo[i] * j;
            
    //         Console.WriteLine(soma1);

    //         digi1 = 11 - (soma1 % 11);
    //         if(digi1 > 9)
    //             digi1 = 0;

    //         Console.WriteLine(digi1);
            
    //         for(int i = 0, j = 11; i < 10; i++, j--)
    //             soma2 += cpfLimpo[i] * j;
            
    //         digi2 = 11 - (soma2 % 11);
    //         if(digi2 > 9)
    //             digi2 = 0;
            
    //         if(digi1 == cpfLimpo[9] && digi2 == cpfLimpo[10])
    //             return true;
    //         else
    //             return false;
    //     }
    //     else
    //         return false;
    // }
}
