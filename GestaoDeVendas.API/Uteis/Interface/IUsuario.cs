using GestaoDeVendas.Dominio.Dados;

namespace GestaoDeVendas.API.Uteis.Interface;

public interface IUsuario
{
    Task<IEnumerable<Usuario>> GetUsuarios();
    Task<Usuario>GetNomeUsuario(string nome);

    Task<Usuario>GetUsuario(int id);
    Task<Usuario>GetPerfil(string nome);
}
