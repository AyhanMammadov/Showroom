using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Repositories.EFCoreRepository.Configurations;
public class LoyalCardsConfiguration : IEntityTypeConfiguration<UserLoyalCards>
{
    public void Configure(EntityTypeBuilder<UserLoyalCards> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.PhoneNumber)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(50);
    }
}

