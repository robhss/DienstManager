using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Service> Services { get; }
    DbSet<ServiceParticipation> ServiceParticipations { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}