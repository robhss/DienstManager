using System.ComponentModel.Design;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using Application.Commands.User;
using Application.Common.Behaviors;
using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.FunctionalTests.Commands;

public class UserCommandTests : IDisposable, IAsyncDisposable
{
    private IMediator _mediator;
    private ApplicationDbContext _dbContext;
    
    public UserCommandTests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<IApplicationDbContext, ApplicationDbContext>( options => options
            .UseSqlServer("Server=127.0.0.1,1433;Database=DMTest;User Id=SA;Password=Coskom12;TrustServerCertificate=True"));
        serviceCollection.AddApplication();
        var serviceProvider = serviceCollection.BuildServiceProvider();

        _dbContext = serviceProvider.GetService<ApplicationDbContext>();
        _mediator = serviceProvider.GetService<IMediator>();
        
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }
    
    public void Dispose()
    {
        
        _dbContext.Dispose();
    }
    
    
    public async ValueTask DisposeAsync()
    {
        await _dbContext.DisposeAsync();
    }

    [Fact]
    public async Task CreateUserTest()
    {
        await _mediator.Send(new CreateUserCommand
        {
            Username = "Test",
            Password = "1234",
            Email = "test@test.com",
            Name = "max",
            Surname = "musterman"
        });
        Assert.NotNull(_dbContext.Users.First(u => u.Username == "Test"));
    }

    [Fact]
    public async Task UpdateUserTest()
    {
        var user = await _dbContext.Users.FirstAsync(u => u.Username == "Test");

        await _mediator.Send(new UpdateUserCommand
        {
            UserId = user.Id,
            Name = "harald",
        });

        var expected = new User
        {
            Username = "Test",
            Password = "1234",
            Email = "test@test.com",
            Name = "max",
            Surname = "musterman"
        };

        var result = await _dbContext.Users.FindAsync(user.Id);
        
        Assert.Equal(expected.Email, result.Email);
        Assert.Equal("harald", result.Name);
    }

}