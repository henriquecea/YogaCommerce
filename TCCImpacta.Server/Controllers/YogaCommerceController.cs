using Microsoft.AspNetCore.Mvc;
using TCCImpacta.Server.Details;
using YogaCommerce.Application.Details.Repository;
using YogaCommerce.EntityFramework.Data.Models;

namespace TCCImpacta.Server.Controllers;

[ApiController]
public class YogaCommerceController
{
    private readonly IRepository<User> _userRepository;

    public YogaCommerceController(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [Route("register")]
    public async Task RegisterUser(UserDto input)
    {
        var newUser = new User()
        {
            Username = input.User,
            EmailAddress = input.Email,
            Password = "",
            CreationTime = DateTime.Now
        };

        await _userRepository.AddAsync(newUser);
        await _userRepository.SaveChangesAsync();
    }
}
