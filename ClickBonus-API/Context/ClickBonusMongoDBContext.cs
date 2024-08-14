using ClickBonus_API.Entidades;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace ClickBonus_API.Context;

public class ClickBonusMongoDBContext : DbContext
{
    public DbSet<Bonus> Bonuses { get; set; }
    public ClickBonusMongoDBContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Bonus>().ToCollection("bonus");
    }
}
