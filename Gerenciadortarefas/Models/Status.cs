﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Gerenciadortarefas.Models;

[Table("status")]
public partial class Status
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("descricao")]
    [StringLength(50)]
    [Unicode(false)]
    public string Descricao { get; set; }

    [InverseProperty("IdStatusNavigation")]
    public virtual ICollection<Tarefas> Tarefas { get; set; } = new List<Tarefas>();

  
}