using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Domain;

namespace UserAPI.Data
{
    public class UserContext:DbContext
    {

        public UserContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Permissions> UserPermissions { get; set; }
        public DbSet<UserInformation> UserInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permissions>(ConfigurePermissions);
            modelBuilder.Entity<UserInformation>(ConfigureUserInformation);

        }

        private void ConfigureUserInformation(EntityTypeBuilder<UserInformation> builder)
        {
            builder.ToTable("UserInformation");
            builder.Property(c => c.Id).IsRequired().ForSqlServerUseSequenceHiLo("user_id_hilo");
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(100);

            builder.Property(c => c.UserName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Password).IsRequired().HasMaxLength(100);

            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(10);
            builder.Property(c => c.Organization).HasMaxLength(100);

            builder.Property(c => c.BillingAddress).HasMaxLength(500);
            builder.Property(c => c.CreditCardNumber).HasMaxLength(15);
            builder.Property(c => c.CVV).HasMaxLength(5);
            // foregin key to permission table
            builder.HasOne(c => c.Permission).WithMany().HasForeignKey(c => c.PermissionId);
        }

        private void ConfigurePermissions(EntityTypeBuilder<Permissions> builder)
        {
            builder.ToTable("Permission");
            builder.Property(c => c.Id).IsRequired().ForSqlServerUseSequenceHiLo("permission_id_hilo");
            builder.Property(c => c.Type).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(500);
        }
    }
}
