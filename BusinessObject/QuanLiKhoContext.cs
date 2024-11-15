using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject;

public partial class QuanLiKhoContext : DbContext
{
    public QuanLiKhoContext()
    {
    }

    public QuanLiKhoContext(DbContextOptions<QuanLiKhoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<InputInfo> InputInfos { get; set; }

    public virtual DbSet<Objectss> Objectsses { get; set; }

    public virtual DbSet<OutputInfo> OutputInfos { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=QuanLiKho;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8ECDC337E");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InputInfo>(entity =>
        {
            entity.HasKey(e => e.InputInfoId).HasName("PK__InputInf__A1D955BFD46EAD36");

            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Object).WithMany(p => p.InputInfos)
                .HasForeignKey(d => d.ObjectId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__InputInfo__Objec__5165187F");
        });

        modelBuilder.Entity<Objectss>(entity =>
        {
            entity.HasKey(e => e.ObjectId).HasName("PK__Objectss__9A619291A6D94065");

            entity.ToTable("Objectss");

            entity.Property(e => e.ObjectName).HasMaxLength(255);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Objectsses)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Objectss__Suppli__4E88ABD4");

            entity.HasOne(d => d.Unit).WithMany(p => p.Objectsses)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Objectss__UnitId__4D94879B");
        });

        modelBuilder.Entity<OutputInfo>(entity =>
        {
            entity.HasKey(e => e.OutputInfoId).HasName("PK__OutputIn__3DDF6BF600137323");

            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__OutputInf__Custo__5629CD9C");

            entity.HasOne(d => d.InputInfo).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.InputInfoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__OutputInf__Input__5812160E");

            entity.HasOne(d => d.Object).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.ObjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__Objec__571DF1D5");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE666B4F712DC44");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.SupplierName).HasMaxLength(255);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__Units__44F5ECB59CD795C1");

            entity.Property(e => e.UnitName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
