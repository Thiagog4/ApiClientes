﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiClientes.Models
{
    public partial class Contatos
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("ClienteID")]
        public int ClienteId { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string Nome { get; set; }
        [StringLength(11)]
        [Unicode(false)]
        public string Celular { get; set; }

        [ForeignKey("ClienteId")]
        [InverseProperty("Contatos")]
        public virtual DadosClientes Cliente { get; set; }
    }
}