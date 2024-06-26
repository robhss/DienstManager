using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Service> Services { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}