using GestaoDeVendas.API.Contexto;
using GestaoDeVendas.API.Uteis.Interface;
using GestaoDeVendas.Dominio.Dados;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeVendas.API.Uteis.Repositorio;

public class UsuarioRepositorio : IUsuario
{
    private readonly AppDbContexto _contexto;

    public UsuarioRepositorio(AppDbContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<Usuario> GetNomeUsuario(string? nome)
    {
        var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(x => x.NomeUsuario == nome);
        return usuario;
    }

    public async Task<Usuario> GetPerfil(string? perfil)
    {
        var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(x => x.Perfil == perfil);
        return usuario;
    }

    public async Task<Usuario> GetUsuario(int id)
    {
        var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        return usuario;
    }

    public async Task<IEnumerable<Usuario>> GetUsuarios()
    {
        var usuarios = await _contexto.Usuarios.ToListAsync();
        return usuarios;
    }
}
