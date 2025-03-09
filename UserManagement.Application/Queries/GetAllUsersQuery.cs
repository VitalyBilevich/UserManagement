using MediatR;
using UserManagement.Application.Models.DTOs;

namespace UserManagement.Application.Queries
{
    public record GetAllUsersQuery() : IRequest<IEnumerable<UserDto>>;
}
