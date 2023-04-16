using Microsoft.EntityFrameworkCore;

namespace Colle.Models;

public class ColleContext : DbContext
{
    public ColleContext(DbContextOptions<ColleContext> options) : base(options) { }

    public DbSet<Paste> Pastes => Set<Paste>();
}
