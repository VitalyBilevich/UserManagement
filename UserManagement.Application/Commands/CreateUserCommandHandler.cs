using MediatR;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Models.DTOs;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserRepositoryFactory _userRepositoryFactory;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepositoryFactory userRepositoryFactory)
    {
        _userRepositoryFactory = userRepositoryFactory;
        _userRepository = _userRepositoryFactory.Create("InMemoryCache");
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.ExistsByEmailAsync(request.Email))
            throw new Exception("Email must be unique.");

        var user = User.Create(request.id, request.FirstName, request.LastName, request.Email, request.DateOfBirth);
        await _userRepository.AddAsync(user);

        return new UserDto { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, DateOfBirth = user.DateOfBirth, Age = user.Age };
    }
}