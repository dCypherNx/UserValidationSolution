using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserValidator : IUserValidator
    {
        public bool Validate(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Password))
            {
                return false;
            }

            if (!user.Email.Contains("@"))
            {
                return false;
            }

            return true;
        }
    }
}
