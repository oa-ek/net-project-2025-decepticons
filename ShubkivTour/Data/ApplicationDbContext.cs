using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShubkivTour.Models.Entity;

namespace ShubkivTour.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Entertainment> Entertainments => Set<Entertainment>();
        public DbSet<Guide> Guides => Set<Guide>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Tour> Tours => Set<Tour>();
        public DbSet<TourClients> TourClients => Set<TourClients>();
        public DbSet<TourEntertainments> TourEntertainments => Set<TourEntertainments>();
        public DbSet<TourGuides> TourGuides => Set<TourGuides>();
        public DbSet<TourLocations> TourLocations => Set<TourLocations>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //зв'язок між Tour та Guide через проміжну
            modelBuilder.Entity<TourGuides>()
                .HasKey(tg => new { tg.TourId, tg.GuideId });

            modelBuilder.Entity<TourGuides>()
                .HasOne(tg => tg.Tour)
                .WithMany(t => t.TourGuides)
                .HasForeignKey(tg => tg.TourId);

            modelBuilder.Entity<TourGuides>()
                .HasOne(tg => tg.Guide)
                .WithMany(g => g.TourGuides)
                .HasForeignKey(tg => tg.GuideId);


            //зв'язок між Tour та Location через проміжну
            modelBuilder.Entity<TourLocations>()
                .HasKey(tg => new { tg.TourId, tg.LocationId });

            modelBuilder.Entity<TourLocations>()
                .HasOne(tg => tg.Tour)
                .WithMany(t => t.TourLocations)
                .HasForeignKey(tg => tg.TourId);

            modelBuilder.Entity<TourLocations>()
                .HasOne(tg => tg.Location)
                .WithMany(g => g.TourLocations)
                .HasForeignKey(tg => tg.LocationId);


            //зв'язок між Tour та Client через проміжну
            modelBuilder.Entity<TourClients>()
                .HasKey(tg => new { tg.TourId, tg.ClientId });

            modelBuilder.Entity<TourClients>()
                .HasOne(tg => tg.Tour)
                .WithMany(t => t.TourClients)
                .HasForeignKey(tg => tg.TourId);

            modelBuilder.Entity<TourClients>()
                .HasOne(tg => tg.Client)
                .WithMany(g => g.TourClients)
                .HasForeignKey(tg => tg.ClientId);


            //зв'язок між Tour та Location через проміжну
            modelBuilder.Entity<TourEntertainments>()
                .HasKey(tg => new { tg.TourId, tg.EntertainmentId });

            modelBuilder.Entity<TourEntertainments>()
                .HasOne(tg => tg.Tour)
                .WithMany(t => t.TourEntertainments)
                .HasForeignKey(tg => tg.TourId);

            modelBuilder.Entity<TourEntertainments>()
                .HasOne(tg => tg.Entertainment)
                .WithMany(g => g.TourEntertainments)
                .HasForeignKey(tg => tg.EntertainmentId);
        }
    }
}
