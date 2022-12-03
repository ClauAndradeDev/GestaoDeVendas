using GestaoDeVendas.Dominio.Dados;
using GestaoDeVendas.Web.Services.Layout;
using System.Net.Http.Json;
using System.Net;

namespace GestaoDeVendas.Web.Services.Service;

public class UsuarioService: IUsuarioService
{

    public HttpClient _httpClient;
    public ILogger<UsuarioService> _logger;

    public UsuarioService(HttpClient httpClient, ILogger<UsuarioService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Usuario> GetNomeUsuario(string nomeUsuario)
    {
        var response = await _httpClient.GetAsync($"api/Usuario/{nomeUsuario}");
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return (Usuario)Enumerable.Empty<Usuario>();
            }
            return await response.Content.ReadFromJsonAsync<Usuario>();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http Status Code - {response.StatusCode} Message = {message}");
        }
    }

    public async Task<Usuario> GetPerfil(string perfil)
    {
        var response = await _httpClient.GetAsync($"api/Usuario/{perfil}");
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return (Usuario)Enumerable.Empty<Usuario>();
            }
            return await response.Content.ReadFromJsonAsync<Usuario>();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http Status Code - {response.StatusCode} Message = {message}");
        }
    }

    public async Task<Usuario> GetUsuario(int id)
    {
        var response = await _httpClient.GetAsync("api/Usuario/{id:int}");
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return (Usuario)Enumerable.Empty<Usuario>();
            }
            return await response.Content.ReadFromJsonAsync<Usuario>();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http Status Code - {response.StatusCode} Message = {message}");
        }
    }

    public async Task<IEnumerable<Usuario>> GetUsuarios()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/Usuario");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<Usuario>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<Usuario>>();
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
