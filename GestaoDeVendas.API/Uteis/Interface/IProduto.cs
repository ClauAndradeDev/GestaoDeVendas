using GestaoDeVendas.Dominio.Dados;

namespace GestaoDeVendas.API.Uteis.Interface;

public interface IProduto
{
    Task<IEnumerable<Produto>> GetProdutos();
    Task<Produto>GetProduto(int id);
}
