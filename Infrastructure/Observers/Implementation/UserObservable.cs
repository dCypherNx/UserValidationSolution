using Infrastructure.Observers.Interfaces;

namespace Infrastructure.Observers.Implementation
{
    public class UserObservable : IObservable
    {
        private readonly List<IUserObserver> _observers = new();

        public void Attach(IUserObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IUserObserver observer)
        {
            _observers.Remove(observer);
        }

        public IEnumerable<IUserObserver> GetObservers()
        {
            return _observers;
        }

        protected void Notify(object sender, EventArgs args)
        {
            foreach (var observer in _observers)
            {
                observer.Update(sender, args);
            }
        }
    }
}
