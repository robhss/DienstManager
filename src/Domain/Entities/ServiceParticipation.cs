namespace Domain.Entities;

public class ServiceParticipation
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid ServiceId { get; set; }
    public Service? Service { get; set; }
    
}