using first_core_app.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static first_core_app.Models.MailModel;

namespace first_core_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradesoftController : ControllerBase
    {


        private readonly IMailService _mailService;

        private readonly ITradesoftService _tradesoftService;
        public TradesoftController(ITradesoftService tradesoftService, IMailService mailService)
        {

            this._mailService = mailService;
            this._tradesoftService = tradesoftService;
        }


        [HttpGet("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {

            string result = _tradesoftService.Login(username, password);

            MailRequest newMail = new MailRequest()
            {

                ToEmail = "test@gmail.com",
                Body = "mail içeriği buraya gelecek",
                Subject = "mailin başlığı"
            };

            await _mailService.SendEmailAsync(newMail);





            if (result == "Ok")
                return Ok("giriş başarılı.");

            return StatusCode(500, "kullanıcı adı şifre hatalı");

        }

    }
}
