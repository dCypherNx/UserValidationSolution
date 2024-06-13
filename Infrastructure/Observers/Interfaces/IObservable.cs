namespace Infrastructure.Observers.Interfaces
{
    public interface IObservable
    {
        void Attach(IUserObserver observer);
        void Detach(IUserObserver observer);
    }
}
