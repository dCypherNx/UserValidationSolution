using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserValidator
    {
        bool Validate(User user);
    }
}
