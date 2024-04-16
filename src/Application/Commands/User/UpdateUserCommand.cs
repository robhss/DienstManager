using Application.Common.Interfaces;
using MediatR;

namespace Application.Commands.User;

public record UpdateUserCommand : IRequest
{
    public Guid UserId { get; init; }
    public string? Username { get; init; }
    public string? Password { get; set; }
    public string? Email { get; init; }
    public string? Name { get; init; }
    public string? SurName { get; init; }
    
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private IApplicationDbContext _dbContext;

    public UpdateUserCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        var user = await _dbContext.Users.FindAsync(new object?[] { request.UserId } , cancellationToken);
        
        //todo: update User
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}