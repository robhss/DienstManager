using Application.Common.Interfaces;
using Domain.Events.User;
using MediatR;

namespace Application.Commands.User;

public record CreateUserCommand : IRequest
{
    public string Username { get; init; }
    public string Password { get; set; }
    public string Email { get; init; }
    public string? Name { get; init; }
    public string? SurName { get; init; }
    
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateUserCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        
        //todo: encrypt password

        var entity = new Domain.Entities.User
        {
            //Id = default,
            //CreatedOn = default,
            //LastModified = default,
            Username = request.Username,
            Password = request.Password,
            Email = request.Email,
            Name = request.Name,
            Surname = request.SurName,
            //Participations = null
        };

        entity.AddDomainEvent(new UserCreatedEvent(entity));
        
        _dbContext.Users.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}