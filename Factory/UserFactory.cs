using Domain.Entities;

namespace Factory
{
    public static class UserFactory
    {
        public static User CreateUser(string name, string email, string password)
        {
            return new User { Id = Guid.NewGuid(), Name = name, Email = email, Password = password };
        }
    }
}
