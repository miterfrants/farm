using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using Homo.AuthApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homo.FarmApi
{
    public partial class FarmDbContext : DbContext
    {
        public FarmDbContext() { }

        public FarmDbContext(DbContextOptions<FarmDbContext> options) : base(options) { }

        public virtual DbSet<Strawberry> Strawberry { get; set; }
        public virtual DbSet<StrawberryLog> StrawberryLog { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Strawberry>(entity =>
            {
                entity.HasIndex(p => new { p.CreatedAt });
                entity.HasIndex(p => new { p.Label });
            });

            modelBuilder.Entity<StrawberryLog>(entity =>
            {
                entity.HasIndex(p => new { p.CreatedAt });
                entity.HasIndex(p => new { p.TenderLeaves });
                entity.HasIndex(p => new { p.OldLeaves });
                entity.HasIndex(p => new { p.FlowerBud });
                entity.HasIndex(p => new { p.LeavesBud });
                entity.HasIndex(p => new { p.Flower });
                entity.HasIndex(p => new { p.Fruit });
                entity.HasIndex(p => new { p.IsRepotting });
                entity.HasIndex(p => new { p.IsPruning });
                entity.HasIndex(p => new { p.IsFertilize });
                entity.HasIndex(p => new { p.StrawberryId });
                entity.HasIndex(p => new { p.Stolon });

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}