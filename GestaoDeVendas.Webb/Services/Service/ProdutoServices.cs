using GestaoDeVendas.Dominio.Dados;
using GestaoDeVendas.Web.Services.Layout;
using System.Net.Http.Json;
using System.Net;

namespace GestaoDeVendas.Web.Services.Service;

public class ProdutoServices :IProdutoService
{
    public HttpClient _httpClient;
    public ILogger<ProdutoServices> _logger;

    public ProdutoServices(HttpClient httpClient, ILogger<ProdutoServices> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    public async Task<Produto> GetProduto(int id)
    {
        var response = await _httpClient.GetAsync("api/Produtos/{id:int}");
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return (Produto)Enumerable.Empty<Produto>();
            }
            return await response.Content.ReadFromJsonAsync<Produto>();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http Status Code - {response.StatusCode} Message = {message}");
        }
    }

    public async Task<IEnumerable<Produto>> GetProdutos()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/Produtos");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<Produto>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<Produto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code - {response.StatusCode} Message = {message}");
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}
