using MediatR;
using UserManagement.Application.Models.DTOs;

namespace UserManagement.Application.Queries 
{
    public record GetUserByIdQuery(string Id) : IRequest<UserDto>;

}