using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EXERCICE4.Models;

public partial class StudentsDbContext : DbContext
{
    public StudentsDbContext()
    {
    }

    public StudentsDbContext(DbContextOptions<StudentsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Etudiant> Etudiants { get; set; }

    public virtual DbSet<Filiere> Filieres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=studentsDB;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Etudiant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Etudiant__3214EC07A6D3FBE8");

            entity.HasOne(d => d.Filiere).WithMany(p => p.Etudiants)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Etudiant_Filiere");
        });

        modelBuilder.Entity<Filiere>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Filiere__3214EC07E065F1E2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
