﻿using Microsoft.AspNetCore.Identity;
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
		public DbSet<Event> Events => Set<Event>();
		public DbSet<Guide> Guides => Set<Guide>();
		public DbSet<Location> Locations => Set<Location>();
		public DbSet<TourProgram> TourPrograms => Set<TourProgram>();
		public DbSet<Day> Days => Set<Day>();
		public DbSet<Tour> Tours => Set<Tour>();
		public DbSet<TourClients> TourClients => Set<TourClients>();
		public DbSet<TourGuides> TourGuides => Set<TourGuides>();


		//public DbSet<TourEvents> TourEntertainments => Set<TourEvents>();
		//public DbSet<TourLocations> TourLocations => Set<TourLocations>();

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



			modelBuilder.Entity<Tour>()
	.HasOne(t => t.TourProgram)
	.WithOne(tp => tp.Tour)
	.HasForeignKey<TourProgram>(tp => tp.TourId);


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
