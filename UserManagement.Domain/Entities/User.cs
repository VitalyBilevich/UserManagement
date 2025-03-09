namespace UserManagement.Domain.Entities
{
    public class User
    {
        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;

                bool hasBirthdayPassedThisYear = today >= DateOfBirth.AddYears(age);
                if (!hasBirthdayPassedThisYear)
                {
                    age--;
                }

                return age;
            }
        }

        public static User Create(string id, string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            // This is a business rule. It is simple and fits into the user entity. A more complex or general rule should be in the domain service to handle the logic.
            if (DateTime.Today.AddYears(-18) < dateOfBirth)
                throw new ArgumentException("User must be at least 18 years old.");

            return new User
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                DateOfBirth = dateOfBirth
            };
        }
    }
}
