using Microsoft.AspNetCore.Mvc;
using MyMicro.Application.UseCases;
using MyMicro.Domain.Interfaces;

namespace MyMicro.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly CreateUserUseCase _createUserUseCase;
    private readonly IUserRepository _userRepository;

    public UserController(CreateUserUseCase createUserUseCase, IUserRepository userRepository)
    {
        _createUserUseCase = createUserUseCase;
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        try
        {
            var user = await _createUserUseCase.Execute(request.Name.ToString(), request.Email.ToString());
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userRepository.GetAll();
        return Ok(users);
    }
}

// Request DTO
public record CreateUserRequest(
    string Name,
    string Email);

// Response DTOdynamic
public record UserResponse(Guid Id, string Name, string Email);