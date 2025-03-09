using MediatR;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Models.DTOs;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Queries;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUserRepositoryFactory _userRepositoryFactory;
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepositoryFactory userRepositoryFactory)
    {
        _userRepositoryFactory = userRepositoryFactory;
        _userRepository = _userRepositoryFactory.Create("InMemoryCache");
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