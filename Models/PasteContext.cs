using Microsoft.EntityFrameworkCore;

namespace Colle.Models;

public class PasteContext : DbContext
{
    public PasteContext(DbContextOptions<PasteContext> options) : base(options) {}
}