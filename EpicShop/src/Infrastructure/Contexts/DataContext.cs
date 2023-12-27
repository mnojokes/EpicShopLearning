using EpicShop.Domain.Objects;
using Microsoft.EntityFrameworkCore;

namespace EpicShop.Infrastructure.Contexts;

public class DataContext : DbContext
{
    public DbSet<ItemEntity> Items { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {}
}
