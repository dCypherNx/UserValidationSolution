using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Observers.Implementation;

namespace Infrastructure.Repositories
{
    public class UserRepository : UserObservable, IUserRepository
    {
        private readonly Dictionary<string, User> _users = new();

        public User GetUser(string email)
        {
            _users.TryGetValue(email, out var user);
            return user;
        }

        public void CreateUser(User user)
        {
            _users[user.Email] = user;
            Notify(this, EventArgs.Empty);
        }
    }
}
