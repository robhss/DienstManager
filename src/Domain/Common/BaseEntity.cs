namespace Domain.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedOn { get; set; }
    public DateTime LastModified { get; set; }
}