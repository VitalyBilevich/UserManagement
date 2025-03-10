using MediatR;
using Microsoft.Extensions.Configuration;
using UserManagement.Application.Constants;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Models.DTOs;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Queries;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUserRepositoryFactory _userRepositoryFactory;
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepositoryFactory userRepositoryFactory, IConfiguration configuration)
    {
        _userRepositoryFactory = userRepositoryFactory;
        var repositoryType = configuration[UserRepositoryTypes.ConfigKey] ?? UserRepositoryTypes.InMemoryCache;
        _userRepository = _userRepositoryFactory.Create(repositoryType);
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user == null) {
            return new UserDto();
        }
        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            DateOfBirth = user.DateOfBirth,
            Age = user.Age
        };
    }
}