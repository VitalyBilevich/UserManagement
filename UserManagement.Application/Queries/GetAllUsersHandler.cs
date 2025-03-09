using MediatR;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Models.DTOs;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Queries;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    private readonly IUserRepositoryFactory _userRepositoryFactory;
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepositoryFactory userRepositoryFactory)
    {
        _userRepositoryFactory = userRepositoryFactory;
        _userRepository = _userRepositoryFactory.Create("InMemoryCache");
    }

    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(user => new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            DateOfBirth = user.DateOfBirth,
            Age = user.Age
        }).ToList();
    }
}
