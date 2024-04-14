using Domain.Common.Interfaces;
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
    private IApplicationDbContext _dbContext;

    public CreateUserCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        
        //todo: encrypt password

        var user = new Domain.Entities.User
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
        _dbContext.Users.Add(user);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}