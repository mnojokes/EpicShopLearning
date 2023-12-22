using EpicShop.API.Objects;
using Microsoft.EntityFrameworkCore;

namespace EpicShop.API.Contexts;

public class DataContext : DbContext
{
    public DbSet<ItemEntity> Items { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {}
}
