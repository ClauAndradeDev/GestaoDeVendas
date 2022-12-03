using GestaoDeVendas.API.Contexto;
using GestaoDeVendas.API.Uteis.Interface;
using GestaoDeVendas.Dominio.Dados;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeVendas.API.Uteis.Repositorio;

public class ProdutoRepositorio : IProduto
{
    private readonly AppDbContexto _contexto;

    public ProdutoRepositorio(AppDbContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<Produto> GetProduto(int id)
    {
        var produto = await _contexto.Produtos.FirstOrDefaultAsync(x=>x.Id == id);
        return produto;
    }

    public async Task<IEnumerable<Produto>> GetProdutos()
    {
        var produtos = await _contexto.Produtos.ToListAsync();
        return produtos;
    }
}
