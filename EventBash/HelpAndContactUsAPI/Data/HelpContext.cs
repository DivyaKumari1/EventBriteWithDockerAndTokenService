using HelpAndContactUsAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpAndContactUsAPI.Data
{
    public class HelpContext : DbContext
    {
        public HelpContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Help> Helps { get; set; } //Helps(plural) denotes the table Help(singular) denotes a row in a table
        public DbSet<ContactUS> ContactUs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Help>(ConfigureHelp);
            modelBuilder.Entity<ContactUS>(ConfigureContactUS);
        }

        private void ConfigureContactUS(EntityTypeBuilder<ContactUS> builder)
        {
            builder.ToTable("ContactUS");
            builder.Property(c => c.Id)
            .IsRequired()
            .ForSqlServerUseSequenceHiLo("Contact_US_hilo");

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.EmailId)
               .IsRequired()
               .HasMaxLength(50);

        }


        private void ConfigureHelp(EntityTypeBuilder<Help> builder)
        {
            builder.ToTable("Helps");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("help_hilo");

            builder.Property(c => c.Query)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Answer)
                .IsRequired()
                .HasMaxLength(500);
        }
    }

    
}
