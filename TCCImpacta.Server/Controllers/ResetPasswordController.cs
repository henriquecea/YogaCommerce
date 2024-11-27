using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SecureIdentity.Password;
using System.Text;
using YogaCommerce.Application.Details;
using YogaCommerce.Application.Details.Repository;
using YogaCommerce.EntityFramework.Data.Models;

namespace YogaCommerce.Application.Controllers;

[ApiController]
public class ResetPasswordController : ControllerBase
{
    private readonly IRepository<User> _userRepository;

    private static readonly string apiKey = "mlsn.06e79489d44c1d16a4261817cd7982795d64ae604c0f71baae78098d05a84337";
    private static readonly string apiUrl = "https://api.mailersend.com/v1/email";

    public ResetPasswordController(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [Route("reset")]
    public async Task<IActionResult> ResetPassword(UserDto user)
    {
        if (user.Email is null || user.Email == string.Empty)
            return BadRequest(new { message = "Email inválido ou nulo." });

        var newPassword = Guid.NewGuid().ToString();

        var emailSend = await SendEmail(user.Email, newPassword);

        if (emailSend)
        {
            await UpdateUserPassword(user.Email, newPassword);
            return Ok(new { message = "Sua nova senha foi enviada por e-mail." });
        }
        else
            return BadRequest(new { message = "não foi possível alterar sua senha." });
    }

    private async Task UpdateUserPassword(string emailAddress, string newPassword)
    {
        var user = await _userRepository.FirstOrDefaultAsync(x => x.EmailAddress == emailAddress);

        if (user is null)
            return;

        var passwordKey = PasswordHasher.Hash(newPassword);
        user.Password = passwordKey;

        await _userRepository.UpdateAsync(user);
        await _userRepository.SaveChangesAsync();
    }

    private static async Task<bool> SendEmail(string toEmail, string newPassword)
    {
        using var client = new HttpClient();

        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var emailContent = new
        {
            from = new { email = "MS_QQMDYe@trial-v69oxl5n3ozl785k.mlsender.net" },
            to = new[] { new { email = toEmail } },
            subject = "Obrigado por entrar em contato!",
            text = $@"
               Olá, 

                Recebemos o pedido para alteração de senha, segue abaixo sua nova senha:
                
                Senha: {newPassword}

                Se você tiver alguma dúvida urgente, não hesite em nos avisar.

                Atenciosamente,  
                Equipe Yoga Commerce
                "
        };

        var jsonContent = JsonConvert.SerializeObject(emailContent);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
        catch
        {
            return false;
        }
    }
}
