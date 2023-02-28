using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GeekForLess;

public partial class GeekForLessContext : DbContext
{
    public GeekForLessContext()
    {
    }

    public GeekForLessContext(DbContextOptions<GeekForLessContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Folder> Folders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=GeekForLess;Username=postgres;Password=santamaria25");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Folder>(entity =>
        {
            entity.HasKey(e => e.IdFolder).HasName("folders_pkey");

            entity.ToTable("folders");

            entity.Property(e => e.IdFolder).HasColumnName("id_folder");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.OwnerFolder).HasColumnName("owner_folder");

            entity.HasOne(d => d.OwnerFolderNavigation).WithMany(p => p.InverseOwnerFolderNavigation)
                .HasForeignKey(d => d.OwnerFolder)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("folders_owner_folder_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
