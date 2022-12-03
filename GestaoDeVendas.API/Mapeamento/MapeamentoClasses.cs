
using GestaoDeVendas.Dominio.Dados;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace GestaoDeVendas.API.Mapeamento;

public static class MapeamentoClasses
{
    public static IEnumerable<Produto> ConverterProduto(this IEnumerable<Produto> produtos)
    {
        return (from produto in produtos
                select new Produto
                {
                    Id = produto.Id,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade
                }).ToList();
    }

    public static IEnumerable<Usuario> ConverterUsuario(this IEnumerable<Usuario> usuarios)
    {
        return (from usuario in usuarios
                select new Usuario
                {
                    Id = usuario.Id,
                    //Nome= usario.Nome,
                    NomeUsuario = usuario.NomeUsuario,
                    Senha = usuario.Senha,
                    ConfirmaSenha = usuario.ConfirmaSenha,
                    Perfil = usuario.Perfil
                }).ToList();
    }
}
