using GestaoDeVendas.Dominio.Dados;

namespace GestaoDeVendas.Web.Services.Layout;

public interface IProdutoService
{
    Task<IEnumerable<Produto>> GetProdutos();
    Task<Produto>GetProduto(int id);
}
