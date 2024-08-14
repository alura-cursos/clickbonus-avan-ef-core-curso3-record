using ClickBonus_API.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ClickBonus_API.Context;

public partial class ClickBonusContext : DbContext
{
    public ClickBonusContext()
    {
    }

    public ClickBonusContext(DbContextOptions<ClickBonusContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

   
}
