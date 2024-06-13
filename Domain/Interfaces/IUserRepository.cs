using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string email);
        void CreateUser(User user);
    }
}
