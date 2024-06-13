using Domain.Entities;
using Infrastructure.Repositories;

namespace Tests
{
    public class UserRepositoryTests
    {
        private readonly UserRepository _repository;

        public UserRepositoryTests()
        {
            _repository = new UserRepository();
        }

        [Fact]
        public void CreateUser_UserCanBeRetrieved()
        {
            var user = new User { Id = Guid.NewGuid(), Email = "test@example.com", Name = "Test User", Password = "Password123" };

            _repository.CreateUser(user);

            var retrievedUser = _repository.GetUser(user.Email);

            Assert.NotNull(retrievedUser);
            Assert.Equal(user.Email, retrievedUser.Email);
            Assert.Equal(user.Name, retrievedUser.Name);
        }

        [Fact]
        public void GetUser_NonExistentUser_ReturnsNull()
        {
            var retrievedUser = _repository.GetUser("nonexistent@example.com");

            Assert.Null(retrievedUser);
        }
    }
}
