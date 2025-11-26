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

            modelBuilder.Entity<Jelo>()
                .Property(e=>e.JedinicaMere)
                .HasConversion<string>();

            modelBuilder.Entity<Receptura>()
                .HasKey(e => new { e.IdArtikal, e.IdJelo });

            modelBuilder.Entity<Receptura>()
                .HasOne(e => e.Jelo)
                .WithMany(j => j.recepture)
                .HasForeignKey(e=>e.IdJelo)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Receptura>()
                .HasOne(e => e.Artikal)
                .WithMany(a => a.recepture)
                .HasForeignKey(e => e.IdArtikal)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Artikal>()
                .Property(a => a.Cena)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Artikal>()
                .Property(a => a.Kolicina)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Jelo>()
                .Property(j => j.Kolicina)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Receptura>()
                .Property(r => r.Kolicina)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Artikal>()
                .Property(a => a.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Jelo>()
                .Property(j => j.IsActive)
                .HasDefaultValue(true);
        }
    }
}
