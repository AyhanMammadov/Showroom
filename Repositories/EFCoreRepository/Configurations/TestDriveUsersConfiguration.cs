using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Repositories.EFCoreRepository.Configurations;
public class TestDriveUsersConfiguration : IEntityTypeConfiguration<TestDriveUsers>
{
    public void Configure(EntityTypeBuilder<TestDriveUsers> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(c => c.Surname)
            .HasMaxLength(15)
            .HasDefaultValue("Unknown");

        builder.Property(c => c.Email)
            .HasMaxLength (30).HasDefaultValue("Unknown");

        builder.Property(c => c.Phone)
            .IsRequired().HasMaxLength(15);
    }
}

