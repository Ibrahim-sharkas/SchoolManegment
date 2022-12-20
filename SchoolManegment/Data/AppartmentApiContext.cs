using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolManegment.Data;

public partial class AppartmentApiContext : DbContext
{
    public AppartmentApiContext()
    {
    }

    public AppartmentApiContext(DbContextOptions<AppartmentApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appartment> Appartments { get; set; }

    public virtual DbSet<AppartmentNumber> AppartmentNumbers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=IBRAHIM\\SQLEXPRESS;Database=AppartmentAPI;Trusted_Connection=true;MultipleActiveResultSets=true;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appartment>(entity =>
        {
            entity.Property(e => e.Details).HasDefaultValueSql("(N'')");
            entity.Property(e => e.ImgUrl).HasDefaultValueSql("(N'')");
        });

        modelBuilder.Entity<AppartmentNumber>(entity =>
        {
            entity.HasKey(e => e.AppartmentNo);

            entity.HasIndex(e => e.AppartmentId, "IX_AppartmentNumbers_AppartmentID");

            entity.Property(e => e.AppartmentNo).ValueGeneratedNever();
            entity.Property(e => e.AppartmentId).HasColumnName("AppartmentID");

            entity.HasOne(d => d.Appartment).WithMany(p => p.AppartmentNumbers).HasForeignKey(d => d.AppartmentId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
