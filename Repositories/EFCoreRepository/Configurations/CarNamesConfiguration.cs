﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Repositories.EFCoreRepository.Configurations;
public class CarNamesConfiguration : IEntityTypeConfiguration<CarsName>
{
    public void Configure(EntityTypeBuilder<CarsName> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(15);
    }
}

