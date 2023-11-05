using CatalogNavigator.DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace CatalogNavigator.DataLayer
{
    public class CatalogDB: DbContext
    {
        public DbSet<Catalog> Catalogs { get; set; }

        public CatalogDB(DbContextOptions<CatalogDB> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>()
                .HasMany(c => c.SubCatalogs)
                .WithOne()
                .HasForeignKey(c => c.ParentId);
        }
    }
}