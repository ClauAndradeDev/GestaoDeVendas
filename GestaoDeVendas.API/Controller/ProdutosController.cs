using GestaoDeVendas.API.Mapeamento;
using GestaoDeVendas.API.Uteis.Interface;
using GestaoDeVendas.Dominio.Dados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeVendas.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProduto _produto;

    public ProdutosController(IProduto produto)
    {
        _produto = produto;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
    {
        try
        {
            var produtos = await _produto.GetProdutos();
            var produtosDados = produtos.ConverterProduto();
            return Ok(produtosDados);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                               "Erro ao acessar o banco de dados - error: " + ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Produto>>GetProduto(int id)
    {
        try
        {
            var produto = await _produto.GetProduto(id);
            if(produto == null)
            {
                return NotFound("Produto não localizado");
            }
            return Ok(produto);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                   "Erro ao acessar o banco de dados - error: " + ex.Message);
        }
    }
}
