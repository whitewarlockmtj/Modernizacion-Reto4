//IuserRepository
using MyMicro.Domain.Entities;

namespace MyMicro.Domain.Interfaces;

public interface IUserRepository
{
    Task Save(User user);
    Task<IEnumerable<User>> GetAll();
}
