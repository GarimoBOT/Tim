using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DatabaseContext : IdentityDbContext<AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<AccreditationPattern> AccreditationPatterns { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<Accreditation> Accreditation { get; set; }
        public DbSet<UserAttachment> UserAttachment { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

             builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .IsRequired();

            builder.Entity<Accreditation>()
                .HasOne(a => a.User)
                .WithMany(a => a.Accreditations)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Accreditation>()
                .HasOne(a => a.Pattern)
                .WithMany(a => a.Accreditations)
                .HasForeignKey(a => a.PatternId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Application>()
                .HasOne(a => a.User)
                .WithMany(a => a.Applications)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Application>()
                .HasOne(a => a.Pattern)
                .WithMany(a => a.Applications)
                .HasForeignKey(a => a.PatternId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserAttachment>()
                .HasOne(a => a.Application)
                .WithMany(a => a.UserAttachments)
                .HasForeignKey(a => a.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}