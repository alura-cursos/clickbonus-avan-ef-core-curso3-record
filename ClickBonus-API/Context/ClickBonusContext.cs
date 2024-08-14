using System;
using System.Collections.Generic;
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

    public virtual DbSet<Oferta> Ofertas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Oferta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ofertas__3214EC0795CD1321");

            entity.Property(e => e.DataCriacao).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
