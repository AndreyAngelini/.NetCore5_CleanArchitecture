﻿using CleanArch.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(300).IsRequired();
            builder.HasData(
                new Category(1, "Material Escolar"),
                new Category(2, "Eletrônicos"),
                new Category(3, "Acessórios")
                );
        }
    }
}
