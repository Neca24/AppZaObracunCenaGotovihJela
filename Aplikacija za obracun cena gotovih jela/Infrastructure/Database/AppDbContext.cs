using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { }

        public DbSet<Artikal> Artikli => Set<Artikal>();
        public DbSet<Jelo> Jela => Set<Jelo>();
        public DbSet<Receptura> Recepture => Set<Receptura>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artikal>()
                .Property(e => e.JedinicaMere)
                .HasConversion<string>();

            modelBuilder.Entity<Artikal>()
                .Property(a => a.Cena)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Artikal>()
                .Property(a => a.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Receptura>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Receptura>()
                .HasIndex(r => new { r.IdJelo, r.IdArtikal })
                .IsUnique();

            modelBuilder.Entity<Receptura>()
                .HasOne(e => e.Jelo)
                .WithMany(j => j.recepture)
                .HasForeignKey(e => e.IdJelo)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Receptura>()
                .HasOne(e => e.Artikal)
                .WithMany(a => a.recepture)
                .HasForeignKey(e => e.IdArtikal)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Receptura>()
                .Property(r => r.Kolicina)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Jelo>()
                .Property(e => e.JedinicaMere)
                .HasConversion<string>();

            modelBuilder.Entity<Jelo>()
                .Property(j => j.Kolicina)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Jelo>()
                .Property(j => j.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Jelo>()
                .Property(j => j.Opis)
                .IsRequired(false);
        }
    }
}
