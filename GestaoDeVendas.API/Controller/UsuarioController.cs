using GestaoDeVendas.API.Mapeamento;
using GestaoDeVendas.API.Uteis.Interface;
using GestaoDeVendas.Dominio.Dados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace GestaoDeVendas.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuario _usuario;

    public UsuarioController(IUsuario usuario)
    {
        _usuario = usuario;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        try
        {
            var usuarios = await _usuario.GetUsuarios();
            var usuariosDados = usuarios.ConverterUsuario();
            return Ok(usuariosDados);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                               "Erro ao acessar o banco de dados - error: " + ex.Message);
        }

    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        try
        {
            var usuario = await _usuario.GetUsuario(id);
            if (usuario is null)
            {
                return NotFound("Usuário não localizado");
            }
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                   "Erro ao acessar o banco de dados - error: " + ex.Message);
        }
    }

    [HttpGet("{nomeUsuario}")]
    public async Task<ActionResult<Usuario>> GetNomeUsuario(string nomeUsuario)
    {
        try
        {
            var usuario = await _usuario.GetNomeUsuario(nomeUsuario);
            if (usuario is null)
            {
                return NotFound("Usuário não localizado");
            }
            return Ok(usuario);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                   "Erro ao acessar o banco de dados - error: " + ex.Message);
        }
    }

    [HttpGet("Usuario/{perfil}")]
    public async Task<ActionResult<Usuario>> GetPerfil (string perfil)
    {
        try
        {
            var usuario = await _usuario.GetPerfil(perfil);
            if (usuario is null)
            {
                return NotFound("Usuário não localizado");
            }
            return Ok(usuario);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                   "Erro ao acessar o banco de dados - error: " + ex.Message);
        }
    }

}


