using MyMicro.Domain.Entities;
using MyMicro.Domain.Interfaces;

namespace MyMicro.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>();

    public async Task Save(User user)
    {
        _users.Add(user);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await Task.FromResult(_users);
    }
}
