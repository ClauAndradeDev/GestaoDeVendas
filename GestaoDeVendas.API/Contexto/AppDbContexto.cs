using GestaoDeVendas.Dominio.Dados;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeVendas.API.Contexto;

public class AppDbContexto: DbContext
{
    public AppDbContexto(DbContextOptions<AppDbContexto> options): base(options)
    {

    }

    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Usuario>? Usuarios { get; set; }
}
