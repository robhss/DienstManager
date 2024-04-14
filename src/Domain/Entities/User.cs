using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    
    public List<ServiceParticipation>? Participations { get; set; }
}
