
using MySpotify.Models.Dtos;
using MySpotify.Models;
using MySpotify.Services.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySpotify.Services.Interfaces;

namespace MySpotify.Controllers
{

    public class LoginController : BaseController
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public LoginController(ILogger<UserController> logger,
                                IUserService userService
                                ) : base(userService)
        {

            _logger = logger;

        }


        [HttpGet("login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromServices] TokenService tokenService,
                                    [FromForm] LoginUserDto userLogin)
        {
            var erros = new List<string>();

            if (!UtilsSecurity.ValidMail(userLogin.Email))
            {
                erros.Add("Login invalid data ");
            }
            if (string.IsNullOrEmpty(userLogin.Password) || string.IsNullOrWhiteSpace(userLogin.Password) || userLogin.Password.Length < 3)
            {
                erros.Add("Login invalid data ");
            }

            if (erros.Count > 0)
            {
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Errors = erros
                });
            }

            var user = new User();
            user = _userService.Login(userLogin.Email, UtilsSecurity.HashPassword(userLogin.Email, userLogin.Password));

            if (user != null)
            {
                user.Password = "";
                //var roles = new List<UserRolesDto>();
                //roles = _roleRepository.GetUserRoles(user.Id);

                var token = tokenService.GenerateToken(user);//, roles);

                var retorno = new
                {
                    Token = token,
                    user = user
                };

                //return View("~/dashboard/dashboard");
                //return RedirectToAction("Dashboard", "Dashboard", new { Retorno = retorno });
                return View("~/views/dashboard/dashboard.cshtml", new { Retorno = retorno });

                //return RedirectToPage("/dashboard.cshtml", new { Retorno = retorno });
                //return RedirectToPage($"~/dashboard.cshtml", new { Retorno = retorno });
                //return Ok(retorno);
            }
            else
            {
                erros.Add("Login invalid data ");

                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Errors = erros
                });
            }

        }
    }
}
