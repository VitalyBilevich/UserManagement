using MediatR;
using UserManagement.Application.Models.DTOs;

namespace UserManagement.Application.Commands
{
    public record CreateUserCommand(string id, string FirstName, string LastName, string Email, DateTime DateOfBirth) : IRequest<UserDto>;
}