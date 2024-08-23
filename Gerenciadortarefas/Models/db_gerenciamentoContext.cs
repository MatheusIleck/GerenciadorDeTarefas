﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gerenciadortarefas.Models;

public partial class db_gerenciamentoContext : DbContext
{
    public db_gerenciamentoContext(DbContextOptions<db_gerenciamentoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Funcionariogrupo> Funcionariogrupo { get; set; }

    public virtual DbSet<Funcionarios> Funcionarios { get; set; }

    public virtual DbSet<Grupos> Grupos { get; set; }

    public virtual DbSet<Status> Status { get; set; }

    public virtual DbSet<Tarefas> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionariogrupo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_funcionariogrupo_1");

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Funcionariogrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_funcionariogrupo_funcionarios");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Funcionariogrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_funcionariogrupo_grupos");
        });

        modelBuilder.Entity<Funcionarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Funcionarios");

            entity.Property(e => e.Nome).IsFixedLength();
            entity.Property(e => e.Senha).IsFixedLength();
        });

        modelBuilder.Entity<Grupos>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK_grupos_1");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tarefas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tarefas");

            entity.Property(e => e.DataInicial).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Tarefas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tarefas_grupos");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Tarefas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tarefas_tarefas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}