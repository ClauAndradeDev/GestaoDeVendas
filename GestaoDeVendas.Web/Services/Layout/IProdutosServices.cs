using GestaoDeVendas.Dominio.Dados;

namespace GestaoDeVendas.Web.Services.Layout;

public interface IProdutosServices
{
    Task<IEnumerable<Produto>> GetProdutos();
    Task<Produto> GetProduto(int id);

}
