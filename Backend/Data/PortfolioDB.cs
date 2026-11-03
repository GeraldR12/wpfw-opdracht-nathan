using Microsoft.EntityFrameworkCore;

public class PortfolioDB : DbContext
{
    public PortfolioDB(DbContextOptions<PortfolioDB> options) : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; } = null!;
    
    public DbSet<Blogpost> Blogposts { get; set; } = null!;
}