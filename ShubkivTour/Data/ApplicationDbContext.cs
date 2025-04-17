using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShubkivTour.Models.Entity;

namespace ShubkivTour.Data
{
    public class ApplicationDbContext : IdentityDbContext<Client>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<Client> Clients => Set<Client>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Guide> Guides => Set<Guide>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<TourProgram> TourPrograms => Set<TourProgram>();
        public DbSet<Day> Days => Set<Day>();
        public DbSet<Tour> Tours => Set<Tour>();
        public DbSet<TourClients> TourClients => Set<TourClients>();
        public DbSet<TourGuides> TourGuides => Set<TourGuides>();

        public DbSet<EventImage> EventImages => Set<EventImage>();
        public DbSet<TourImage> TourImages => Set<TourImage>();


		public DbSet<Brand> Brands => Set<Brand>();
		public DbSet<CategoryProduct> CategoryProducts => Set<CategoryProduct>();
		public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<SubCategory> SubCategories => Set<SubCategory>();
        public DbSet<Product> Products => Set<Product>();
        //public DbSet<Review> Reviews => Set<Review>();
        //public DbSet<SubCategory> SubCategories => Set<SubCategory>();


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TourGuides>()
                .HasOne(tg => tg.Tour)
                .WithMany(t => t.TourGuides)
                .HasForeignKey(tg => tg.TourId);

            modelBuilder.Entity<TourGuides>()
                .HasOne(tg => tg.Guide)
                .WithMany(g => g.TourGuides)
                .HasForeignKey(tg => tg.GuideId);

            //зв'язок між Tour та Client через проміжну
            modelBuilder.Entity<TourClients>()
    .HasKey(tc => tc.Id);

            modelBuilder.Entity<TourClients>()
                .HasOne(tc => tc.Tour)
                .WithMany(t => t.TourClients)
                .HasForeignKey(tc => tc.TourId);

            modelBuilder.Entity<TourClients>()
                .HasOne(tc => tc.Client)
                .WithMany(g => g.TourClients)
                .HasForeignKey(tc => tc.ClientId)
                        .HasPrincipalKey(c => c.Id);


            // Зв'язок між Day і Event
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Day)
                .WithMany(d => d.Events)
                .HasForeignKey(e => e.DayId);

            // Зв'язок між Day і TourProgram
            modelBuilder.Entity<Day>()
                .HasOne(d => d.TourProgram)
                .WithMany(tp => tp.Days)
                .HasForeignKey(d => d.TourProgramId);



            /*			modelBuilder.Entity<Tour>()
                .HasOne(t => t.TourProgram)
                .WithOne(tp => tp.Tour)
                .HasForeignKey<TourProgram>(tp => tp.TourId);*/


            /*//зв'язок між Day та Event через проміжну
			modelBuilder.Entity<DayEvents>()
				.HasKey(tg => new { tg.DayId, tg.EventId });

			modelBuilder.Entity<DayEvents>()
				.HasOne(tg => tg.Day)
				.WithMany(t => t.DayEvents)
				.HasForeignKey(tg => tg.DayId);

			modelBuilder.Entity<DayEvents>()
				.HasOne(tg => tg.Event)
				.WithMany(g => g.DayEvents)
				.HasForeignKey(tg => tg.EventId);*/

            /* //зв'язок між Tour та Location через проміжну
			 modelBuilder.Entity<TourLocations>()
				 .HasKey(tg => new { tg.TourId, tg.LocationId });

			 modelBuilder.Entity<TourLocations>()
				 .HasOne(tg => tg.Tour)
				 .WithMany(t => t.TourLocations)
				 .HasForeignKey(tg => tg.TourId);

			 modelBuilder.Entity<TourLocations>()
				 .HasOne(tg => tg.Location)
				 .WithMany(g => g.TourLocations)
				 .HasForeignKey(tg => tg.LocationId);*/




            /* //зв'язок між Tour та Location через проміжну
			 modelBuilder.Entity<TourEvents>()
				 .HasKey(tg => new { tg.TourId, tg.EntertainmentId });

			 modelBuilder.Entity<TourEvents>()
				 .HasOne(tg => tg.Tour)
				 .WithMany(t => t.TourEvents)
				 .HasForeignKey(tg => tg.TourId);

			 modelBuilder.Entity<TourEvents>()
				 .HasOne(tg => tg.Entertainment)
				 .WithMany(g => g.TourEvents)
				 .HasForeignKey(tg => tg.EntertainmentId);*/
        }
    }
}
