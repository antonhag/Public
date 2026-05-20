using Microsoft.EntityFrameworkCore;
using Public.Domain.Entities;

namespace Public.Infrastructure.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }

    public DbSet<ContentBlock> ContentBlocks { get; set; } = null!;
    public DbSet<MenuItem> MenuItems { get; set; } = null!;
    public DbSet<Page> Pages { get; set; } = null!;
}