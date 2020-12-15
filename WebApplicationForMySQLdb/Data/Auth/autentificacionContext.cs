using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationForMySQLdb.Data.Auth
{
    public partial class autentificacionContext : DbContext
    {
        public autentificacionContext()
        {
        }

        public autentificacionContext(DbContextOptions<autentificacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogHistory> AspNetUserLogHistory { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        //public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=autentificacion;user=root;password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Name).HasColumnType("varchar(256)");

                entity.Property(e => e.NormalizedName).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogHistory>(entity =>
            {
                entity.HasKey(e => new { e.IdAspNetUserLogHistory, e.UserId });

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_AspNetUserLogHistory_AspNetUsers_UserId_idx");

                entity.Property(e => e.IdAspNetUserLogHistory)
                    .HasColumnName("idAspNetUserLogHistory")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.Action).HasColumnType("mediumtext");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Time).HasColumnType("time");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogHistory)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(255)");

                entity.Property(e => e.ProviderKey).HasColumnType("varchar(255)");

                entity.Property(e => e.ProviderDisplayName).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.RoleId).HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Email).HasColumnType("varchar(256)");

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail).HasColumnType("varchar(256)");

                entity.Property(e => e.NormalizedUserName).HasColumnType("varchar(256)");

                entity.Property(e => e.PasswordHash).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumber).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.SecurityStamp).HasColumnType("longtext");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(255)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");

                entity.Property(e => e.Value).HasColumnType("longtext");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            //modelBuilder.Entity<EfmigrationsHistory>(entity =>
            //{
            //    entity.HasKey(e => e.MigrationId);

            //    entity.ToTable("__EFMigrationsHistory");

            //    entity.Property(e => e.MigrationId).HasColumnType("varchar(95)");

            //    entity.Property(e => e.ProductVersion)
            //        .IsRequired()
            //        .HasColumnType("varchar(32)");
            //});
        }
    }
}
