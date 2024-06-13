using Application.Services;
using Domain.Entities;

namespace Tests
{
    public class UserValidatorTests
    {
        private readonly UserValidator _validator;

        public UserValidatorTests()
        {
            _validator = new UserValidator();
        }

        [Fact]
        public void Validate_ValidUser_ReturnsTrue()
        {
            var user = new User { Email = "test@example.com", Name = "Test User", Password = "Password123" };

            var result = _validator.Validate(user);

            Assert.True(result);
        }

        [Fact]
        public void Validate_InvalidEmail_ReturnsFalse()
        {
            var user = new User { Email = "invalid-email", Name = "Test User", Password = "Password123" };

            var result = _validator.Validate(user);

            Assert.False(result);
        }

        [Fact]
        public void Validate_MissingName_ReturnsFalse()
        {
            var user = new User { Email = "test@example.com", Name = "", Password = "Password123" };

            var result = _validator.Validate(user);

            Assert.False(result);
        }

        [Fact]
        public void Validate_MissingPassword_ReturnsFalse()
        {
            var user = new User { Email = "test@example.com", Name = "Test User", Password = "" };

            var result = _validator.Validate(user);

            Assert.False(result);
        }
    }
}
