
using first_core_app.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static first_core_app.Models.AuthModel;
using static first_core_app.Models.UserModel;

namespace first_core_app.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {

        IAuthService _authService;
        IUserService _userService;
        IMenuService _menuService;
        IMailService _mailService;

        public AuthController(IAuthService authService, IUserService userService, IMenuService menuService, IMailService mailService)
        {
            _authService = authService;
            _userService = userService;
            _menuService = menuService;
            _mailService = mailService;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {

            bool loginResult = _authService.Login(loginRequest);


            if (loginResult == false)
                return Unauthorized();


            UserLoginModel userData = _userService.GetUserLogin(loginRequest.Username);

            if (userData.RoleId == 0)
                return UnprocessableEntity("RoleId hatalı");

            _menuService.GetUserMenu(userData.RoleId);


            if (userData.Email == null)
                return UnprocessableEntity("User email hatalı");


            await _mailService.SendEmailAsync(new Models.MailModel.MailRequest()
            {
                ToEmail = userData.Email,
                Body = "Giriş yapan siz değilseniz müşteri temsilcinize ulaşın.",
                Subject = "Giriş başarılı"
            });



            return Ok();
        }
    }
}
