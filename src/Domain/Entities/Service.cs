using System.Diagnostics.Contracts;
using Domain.Common;

namespace Domain.Entities;

public class Service : BaseEntity
{
    public DateTime? Date { get; set; }
    public string? Topic { get; set; }
    
    public List<ServiceParticipation>? Participations { get; set; }
}