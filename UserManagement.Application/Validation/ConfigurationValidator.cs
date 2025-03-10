using Microsoft.Extensions.Configuration;
using UserManagement.Application.Constants;
using UserManagement.Common.Validation;

namespace UserManagement.Application.Validation
{
    public static class ConfigurationValidator
    {
        public static ValidationResult ValidateRepositoryType(IConfiguration configuration)
        {
            string repositoryType;
            try
            {
                repositoryType = configuration[UserRepositoryTypes.ConfigKey];
            }
            catch(Exception ex)
            {
                return ValidationResult.Failure(ex.Message);
            }

            if (string.IsNullOrEmpty(repositoryType) || !UserRepositoryTypes.All.Contains(repositoryType))
            {
                return ValidationResult.Failure(
                    $"Invalid RepositoryType in configuration. Allowed values: {string.Join(", ", UserRepositoryTypes.All)}"
                );
            }

            return ValidationResult.Success();
        }
    }
}
