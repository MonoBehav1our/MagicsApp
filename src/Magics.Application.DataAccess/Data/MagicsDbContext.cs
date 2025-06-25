using Magics.Application.DataAccess.Magics.Entity;
using Magics.Application.DataAccess.Wizards.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Magics.Application.DataAccess.Data;

public class MagicsDbContext(IConfiguration config) : DbContext
{
    public DbSet<WizardEntity> wizards { get; set; }

    public DbSet<MagicEntity> magics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseNpgsql(config.GetConnectionString("Postgres"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MagicEntity>(entity =>
        {
            entity.ToTable("magics"); // Убедитесь, что имя таблицы указано!

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.WizardId).HasColumnName("wizard_id");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.ExperienceYears).HasColumnName("experience_years");
            entity.Property(e => e.DesiredSkill).HasColumnName("desired_skill");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
        });

        modelBuilder.Entity<WizardEntity>(entity =>
        {
            entity.ToTable("wizards");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.KnownMagicSkills).HasColumnName("known_magic_skills");
        });
    }
}