using Domain.Entities;
using Infrastructure.Observers.Implementation;

namespace Infrastructure.Singleton
{
    public class UserManager : UserObservable
    {
        private static readonly Lazy<UserManager> _instance = new(() => new UserManager());
        private User _currentUser;

        private UserManager() { }

        public static UserManager Instance => _instance.Value;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                Notify(this, EventArgs.Empty);
            }
        }
    }
}
