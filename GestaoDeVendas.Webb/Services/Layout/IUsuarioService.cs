using GestaoDeVendas.Dominio.Dados;

namespace GestaoDeVendas.Web.Services.Layout;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> GetUsuarios();
    Task<Usuario> GetNomeUsuario(string nomeUsuario);
    Task<Usuario> GetUsuario(int id);
    Task<Usuario> GetPerfil(string perfil);
}
