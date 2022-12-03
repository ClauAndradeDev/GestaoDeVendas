using System.ComponentModel.DataAnnotations;
namespace GestaoDeVendas.Dominio.Dados;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    //public string? Nome { get; set; }

    [Required(ErrorMessage = "Informe o E-mail")]
    [EmailAddress(ErrorMessage = "Formato do E-mail inválido")]
    public string? NomeUsuario { get; set; }

    [Required(ErrorMessage = "Informe a senha")]
    public string? Senha { get; set; }
    public string? ConfirmaSenha { get; set; }

    public string? Perfil { get; set; }   
}
