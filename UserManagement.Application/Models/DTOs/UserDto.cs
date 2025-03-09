namespace UserManagement.Application.Models.DTOs
{
    // UserDto is a Data Transfer Object (DTO) that is used to transfer data between the application and the API.
    // It doesn't contain any business logic like age calculation, which is done in the User entity.
    public class UserDto
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }
    }
}
