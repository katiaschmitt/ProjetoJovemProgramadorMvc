﻿using JovemProgramadorMVC2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMVC2.Data.Mapeamento
{
    public class AlunoMapeamento : IEntityTypeConfiguration<AlunoModel>
    {
        public void Configure(EntityTypeBuilder<AlunoModel> builder)
        {
            builder.ToTable("Alunos");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome).HasColumnType("varchar(50)");
            builder.Property(t => t.Idade).HasColumnType("int");
            builder.Property(t => t.Contato).HasColumnType("varchar(15)");
            builder.Property(t => t.Email).HasColumnType("varchar(50)");
            builder.Property(t => t.Cep).HasColumnType("varchar(10)");
            builder.Property(t => t.Operacao).HasColumnType("varchar(10)");


        }
    }
}
