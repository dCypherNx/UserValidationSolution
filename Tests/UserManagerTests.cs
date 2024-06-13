using Domain.Entities;
using Infrastructure.Singleton;

namespace Tests
{
    public class UserManagerTests
    {
        [Fact]
        public void Instance_ShouldReturnSameInstance()
        {
            // Arrange & Act
            var instance1 = UserManager.Instance;
            var instance2 = UserManager.Instance;

            // Assert
            Assert.Same(instance1, instance2);
        }

        [Fact]
        public void CurrentUser_ShouldBeSharedAcrossInstances()
        {
            // Arrange
            var instance1 = UserManager.Instance;
            var instance2 = UserManager.Instance;
            var user = new User { Id = Guid.NewGuid(), Name = "Test User", Email = "test@example.com", Password = "Password123" };

            // Act
            instance1.CurrentUser = user;

            // Assert
            Assert.Same(instance1.CurrentUser, instance2.CurrentUser);
            Assert.Equal(instance1.CurrentUser.Name, instance2.CurrentUser.Name);
            Assert.Equal(instance1.CurrentUser.Email, instance2.CurrentUser.Email);
        }
    }
}
