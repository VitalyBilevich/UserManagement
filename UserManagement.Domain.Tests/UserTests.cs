using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Tests
{
    public class UserTests
    {
        [Fact]
        public void Create_AdultAge_ReturnsCorrectAge()
        {           
            var birthDate = new DateTime(2005, 5, 5);
            User user = User.Create(null, null, null, null, birthDate);
            var expectedAge = DateTime.Today.Year - birthDate.Year;           
            if (birthDate.Date > DateTime.Today.AddYears(-expectedAge))
            {
                expectedAge--;
            }
        
            Assert.Equal(expectedAge, user.Age);
        }

        [Fact]
        public void Create_FirstName_ReturnsCorrectFirstName()
        {
            var expectedFirstName = "Nick";
            User user = User.Create(null, expectedFirstName, null, null, new DateTime());
            
            Assert.Equal(expectedFirstName, user.FirstName);
        }

        [Fact]
        public void Create_UnderAge_ThrowsArgumentException()
        {            
            var birthDate = DateTime.Today.AddYears(-17);
            
            Assert.Throws<ArgumentException>(() =>
            {
                User.Create(null, null, null, null, birthDate);
            });
        }
    }

}