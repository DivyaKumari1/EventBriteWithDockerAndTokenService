using EventCatalogAPI.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class EventContext : DbContext 
    {
        //add dependency injection and config file using class constructor

        public EventContext(DbContextOptions options) : base(options)
        {
            //this is empty but needs to be filled shortly.
        }
       

        public DbSet<EventCategory> EventCategories { get; set; } //DB Table EventCategories

        public DbSet<EventVenue> EventVenues { get; set; } // DB table EventVenues
        
        public DbSet<EventItem> EventItems { get; set; } //DB Table EventItems


        //defining relationship of tables using Entity Framework
        protected override void OnModelCreating(ModelBuilder modelBuilder )

        {
            modelBuilder.Entity<EventVenue>(ConfigureEventVenue);
            modelBuilder.Entity<EventCategory>(ConfigureEventCategory);
            modelBuilder.Entity<EventItem>(ConfigureEventItem); //Selvi -> updated ConfigureEventItems to ConfigureEventItem to make it more sensible 
        }

        /**
         * creating table  tableName :Events with a 
         * primary key : Id,
         * ForeginKey : EventVenue,EventCategory 
         */

        private void ConfigureEventItem(EntityTypeBuilder<EventItem> builder)
        {
            builder.ToTable("Events");//the actual name of the event catalog
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("events_hilo");

            builder.Property(c => c.EventName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.EventCost) 
                .IsRequired();

            //Here, are the relationships between Events and the venue and category
            builder.HasOne(c => c.EventCategory) //red will go away when Items is successfully entered
                .WithMany()
                .HasForeignKey(c => c.EventCategoryId);

            builder.HasOne(c => c.EventVenue) //red will go away when Items is successfully entered
                .WithMany()
                .HasForeignKey(c => c.EventVenueId);
        }
        
        private void ConfigureEventCategory(EntityTypeBuilder<EventCategory> builder)
        {
            builder.ToTable("EventCategories");

            builder.Property(c => c.Id)
                .IsRequired() //primary key
                .ForSqlServerUseSequenceHiLo("event_category_hilo"); //

            builder.Property(c => c.Category) //would be good to change type member to category.
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureEventVenue(EntityTypeBuilder<EventVenue> builder)
        {
            builder.ToTable("EventVenues");

            builder.Property(c => c.Id) //What to do with the properties
                .IsRequired() //required because Id is the primary key
                .ForSqlServerUseSequenceHiLo("event_venue_hilo");

            builder.Property(c => c.Venue)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
