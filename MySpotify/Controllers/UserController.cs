
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySpotify.Models;
using MySpotify.Models.Dtos;
using MySpotify.Services.Interfaces;
using MySpotify.Services.Utils;

namespace MySpotify.Controllers
{
    [ApiController]

    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(
                                ILogger<UserController> logger,
                                IUserService userService
                                ) : base( userService)
        {
            _logger = logger;
        }



        
        [HttpPost("users")]
        [AllowAnonymous]
        public IActionResult CreateUser([FromServices] TokenService tokenService,
                                    [FromBody] CreateUserDto userCreateModel)
        {
            var erros = new List<string>();


            if (userCreateModel == null) return BadRequest(new ErrorDto
            {
                Status = StatusCodes.Status400BadRequest,
                Error = "Err DXE7001 invalid data"
            });

            var user = new User();
            user.Email = userCreateModel.Email;
            user.Name = userCreateModel.Name;

            user.Password = userCreateModel.Password;


            if (!UtilsSecurity.ValidMail(user.Email))
            {
                erros.Add("Err DXE7002 invalid data");
            }
            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 3)
            {
                erros.Add("Err DXE7003 invalid data");
            }

            if (erros.Count > 0)
            {
                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Errors = erros
                });
            }

            user.Password = UtilsSecurity.HashPassword(user.Email, user.Password);

            var bOk = _userService.Save(user);

            if (bOk)
            {
                user.Password = "";
                return Ok(user); //RedirectToPage("dashboard.cshtml");
                //return StatusCode(StatusCodes.Status201Created, user.Email);

            }
            else
            {
                //erros.Add("User already exists");
                return BadRequest("User already exists");
            }
        }




        [HttpGet("users/{id}")]

        public IActionResult GetUser(
                        [FromRoute] string id)
        {
            var erros = new List<string>();

            try
            {
                var user = new User();
                user = _userService.GetById(Guid.Parse(id));
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest(new ErrorDto
                {
                    Status = StatusCodes.Status400BadRequest,
                    Error = "Err DXG7001 Server Error"
                });
            }



        }
    }
}
