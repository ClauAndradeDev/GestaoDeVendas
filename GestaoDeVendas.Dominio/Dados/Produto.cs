using System.ComponentModel.DataAnnotations;

namespace GestaoDeVendas.Dominio.Dados;

public class Produto
{
    [Key]
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}
