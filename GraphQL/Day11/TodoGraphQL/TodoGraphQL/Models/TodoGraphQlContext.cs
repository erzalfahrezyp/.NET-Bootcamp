using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TodoGraphQL.Models;

public partial class TodoGraphQlContext : DbContext
{
    public TodoGraphQlContext()
    {
    }

    public TodoGraphQlContext(DbContextOptions<TodoGraphQlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoTable> TodoTables { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=EJIII\\SQLEXPRESS;Database=TodoGraphQL;uid=student;pwd=12345678;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoTable>(entity =>
        {
            entity.ToTable("TodoTable");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
