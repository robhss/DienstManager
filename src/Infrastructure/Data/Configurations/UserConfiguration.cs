using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Username)
            .HasMaxLength(200);

        builder.Property(u => u.Email)
            .HasMaxLength(320);

        builder.Property(u => u.Name)
            .HasMaxLength(200);

        builder.Property(u => u.Surname)
            .HasMaxLength(200);

        builder.HasMany(u => u.ServiceParticipations)
            .WithMany(s => s.Participants);
    }
}