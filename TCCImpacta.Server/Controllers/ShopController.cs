using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using YogaCommerce.Application.Details;
using YogaCommerce.Application.Details.Repository;
using YogaCommerce.EntityFramework.Data.Models;

namespace YogaCommerce.Application.Controllers;

[ApiController]
public class ShopController : ControllerBase
{
    private readonly IRepository<Shopping> _shoppingRepository;

    public ShopController(IRepository<Shopping> shoppingRepository)
    {
        _shoppingRepository = shoppingRepository;
    }

    private static readonly string apiKey = "mlsn.06e79489d44c1d16a4261817cd7982795d64ae604c0f71baae78098d05a84337";
    private static readonly string apiUrl = "https://api.mailersend.com/v1/email";

    [HttpPost]
    [Route("buy")]
    public async Task<IActionResult> BuyProduct(ShoppingDto input)
    {
        if (input.EmailAddress is null || input.EmailAddress == string.Empty)
            return BadRequest(new { message = "Email inválido ou nulo." });

        var emailSend = await SendEmail(input.EmailAddress, input.ProductName);

        if (emailSend)
        {
            await SaveBuy(input);
            return Ok(new { message = "Interesse registrado." });
        }
        else
            return BadRequest(new { message = "Erro no Interesse" });
    }

    private async Task SaveBuy(ShoppingDto input)
    {
        var newContact = new Shopping()
        {
            ProductName = input.ProductName,
            EmailAddress = input.EmailAddress
        };

        await _shoppingRepository.AddAsync(newContact);
        await _shoppingRepository.SaveChangesAsync();
    }

    private static async Task<bool> SendEmail(string email, string product)
    {
        using var client = new HttpClient();

        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var emailContent = new
        {
            from = new { email = "MS_QQMDYe@trial-v69oxl5n3ozl785k.mlsender.net" },
            to = new[] { new { email = "henrique.cea@aluno.faculdadeimpacta.com.br" } },
            subject = "Interessado no Produto - Yoga Commerce",
            text = $@"
                    Olá,

                    Gostaríamos de informar que o e-mail {email} demonstrou interesse em um de nossos produtos. A equipe da Yoga Commerce irá entrar em contato em breve para fornecer mais informações sobre o produto e como você pode adquiri-lo.

                    Produto: {product}

                    Se você tiver alguma dúvida ou precisar de mais detalhes, não hesite em nos avisar.

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
