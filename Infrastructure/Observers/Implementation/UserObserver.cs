using Infrastructure.Observers.Interfaces;

namespace Infrastructure.Observers.Implementation
{
    public class UserObserver : IUserObserver
    {
        public void Update(object sender, EventArgs args)
        {
            Console.WriteLine("O estado do usuário mudou!");
        }
    }
}