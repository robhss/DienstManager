using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class ServiceParticipationConfiguration : IEntityTypeConfiguration<ServiceParticipation>
{
    public void Configure(EntityTypeBuilder<ServiceParticipation> builder)
    {
        builder
            .HasOne(sp => sp.User)
            .WithMany(u => u.Participations)
            .HasForeignKey(sp => sp.UserId);

        builder
            .HasOne(sp => sp.Service)
            .WithMany(s => s.Participations)
            .HasForeignKey(sp => sp.ServiceId);
    }
}