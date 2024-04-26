using Application.Common.Interfaces;
using Domain.Events.User;
using MediatR;

namespace Application.Commands.User;

public record UpdateUserCommand : IRequest
{
    public Guid UserId { get; init; }
    public string? Username { get; init; }
    public string? Password { get; init; }
    public string? Email { get; init; }
    public string? Name { get; init; }
    public string? Surname { get; init; }
    
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateUserCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        var entity = await _dbContext.Users.FindAsync(new object?[] { request.UserId } , cancellationToken);

        if (entity != null)
        {
            entity.AddDomainEvent(new UserUpdatedEvent(entity));
            if (request.Username != null) entity.Username = request.Username;
            if (request.Password != null) entity.Password = request.Password;
            if (request.Email != null) entity.Email = request.Email;
            if (request.Name != null) entity.Name = request.Name;
            if (request.Surname != null) entity.Surname = request.Surname;
        }
        
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}