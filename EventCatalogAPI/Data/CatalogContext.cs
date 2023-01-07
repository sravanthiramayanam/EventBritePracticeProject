using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
       public CatalogContext(DbContextOptions options):base(options)
       {

       }
       public DbSet<Category> Categories{ get; set;}
       public DbSet<EventOrganizer> EventOrganizers{ get; set;} 
       public DbSet<Event> Events{ get; set;}
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(e =>
            {
                e.Property(c => c.Id)
                 .IsRequired()
                 .ValueGeneratedOnAdd();

                e.Property(c => c.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            });

            modelBuilder.Entity<EventOrganizer>(e =>
            {
                e.Property(e => e.Id)
                 .IsRequired()
                 .ValueGeneratedOnAdd();

                e.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            });

            modelBuilder.Entity<Event>(e =>
            {
                e.Property(t => t.Id)
                 .IsRequired()
                 .ValueGeneratedOnAdd();

                e.Property(t => t.Name)
                  .IsRequired()
                  .HasMaxLength(100);
                
                e.Property(t => t.Description)
                  .HasMaxLength(500);

                e.Property(t => t.Price)
                 .IsRequired();

                e.Property(t => t.LocationAddress)
                  .HasMaxLength(100);
               
                e.Property(t => t.City)
                  .HasMaxLength(50);

                e.Property(t => t.State)
                  .HasMaxLength(50);

                e.HasOne(c => c.Category)
                  .WithMany()
                  .HasForeignKey(c => c.CategoryId);

                //e.HasOne(e => e.EventOrganizer)
                //  .WithMany()
                //  .HasForeignKey(e => e.OrganizerId);
                e.HasOne(e => e.EventOrganizer)
                  .WithMany()
                  .HasForeignKey(e => e.OrganizerId);


            });

        }
    }
}
