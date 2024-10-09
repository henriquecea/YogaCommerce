using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using YogaCommerce.Application.Details;
using YogaCommerce.Application.Details.Repository;
using YogaCommerce.EntityFramework.Data.Models;

namespace YogaCommerce.Application.Controllers;

[ApiController]
public class ContactController : ControllerBase
{
    private readonly IRepository<Contact> _contactRepository;

    private static readonly string apiKey = "mlsn.06e79489d44c1d16a4261817cd7982795d64ae604c0f71baae78098d05a84337";
    private static readonly string apiUrl = "https://api.mailersend.com/v1/email";

    public ContactController(IRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpPost]
    [Route("contact")]
    public async Task<IActionResult> Contact(ContactDto input)
    {
        if (input.Email is null || input.Email == string.Empty)
            return BadRequest(new { message = "Email inválido ou nulo." });

        var emailSend = await SendEmail(input.Email, input.Name);
        if (emailSend)
        {
            await SaveContact(input);
            return Ok(new { message = "Seu contato foi salvo com sucesso!" });
        }
        else
            return BadRequest(new { message = "Não foi possível fazer o contato." });
    }

    private async Task SaveContact(ContactDto input)
    {
        var newContact = new Contact()
        {
            Name = input.Name,
            Email = input.Email,
            Phone = input.Phone,
            Message = input.Message,
            Subject = input.Subject
        };

        await _contactRepository.AddAsync(newContact);
        await _contactRepository.SaveChangesAsync();
    }

    private static async Task<bool> SendEmail(string toEmail, string userName)
    {
        using var client = new HttpClient();

        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var emailContent = new
        {
            from = new { email = "MS_QQMDYe@trial-v69oxl5n3ozl785k.mlsender.net" },
            to = new[] { new { email = toEmail } },
            subject = "Obrigado por entrar em contato!",
            text = $@"
               Olá, {userName} 

                Agradecemos por entrar em contato conosco! Recebemos a sua mensagem e nossa equipe está analisando. Entraremos em contato em breve para fornecer a assistência necessária.

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
