using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;
using YogaCommerce.Application.Details;
using YogaCommerce.Application.Details.Repository;
using YogaCommerce.EntityFramework.Data.Models;

namespace YogaCommerce.Application.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    private readonly IRepository<User> _userRepository;

    public AccountController(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser(UserDto input)
    {
        bool samePassword = input.Password == input.ConfirmPassword;

        if (!samePassword)
            return BadRequest(new { message = "As senhas não coincidem." });

        if (!input.TermsOfUseAccepted)
            return BadRequest(new { message = "Os termos de uso não foram aceitos." });

        var passwordKey = PasswordHasher.Hash(input.Password);
        var newUser = new User()
        {
            Username = input.Username,
            EmailAddress = input.Email,
            Password = passwordKey,
            TermsOfUseAccepted = input.TermsOfUseAccepted,
            CreationTime = DateTime.Now
        };

        await _userRepository.AddAsync(newUser);
        await _userRepository.SaveChangesAsync();

        return Ok(new { message = "Usuário registrado com sucesso!" });
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginUser(UserDto input)
    {
        var user = await _userRepository.FirstOrDefaultAsync(x => x.EmailAddress == input.Email);

        if (user is null)
            return BadRequest(new { message = "Usuário ou senha inválidos." });

        if (!PasswordHasher.Verify(user.Password, input.Password))
            return BadRequest(new { message = "Usuário ou senha inválidos." });

        return Ok(new {message = "Usuário logado com sucesso!"});
    }
}
