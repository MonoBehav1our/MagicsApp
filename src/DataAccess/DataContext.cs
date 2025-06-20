using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class DataContext : DbContext
{
    public DbSet<WizardEntity> WizardsSet { get; set; }

    public DbSet<MagicEntity> MagicsSet { get; set; }
}