using MyMicro.Domain.Entities;
using MyMicro.Domain.Interfaces;

namespace MyMicro.Application.UseCases;
public class CreateUserUseCase
{
    private readonly IUserRepository _userRepository;

    public CreateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Execute(string name, string email)
    {
        var user = new User(name, email);
        await _userRepository.Save(user);
        return user;
    }
}
