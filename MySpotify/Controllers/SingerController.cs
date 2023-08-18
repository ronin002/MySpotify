
using MySpotify.Models.Dtos;
using MySpotify.Models;
using MySpotify.Services.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySpotify.Services.Interfaces;

namespace MySpotify.Controllers
{

    public class SingerController : BaseController
    {

        private ISingerService _singerService;
        public SingerController(IServiceProvider sp,
                                ISingerService singerService
                                ) :base(sp)
        {
            _singerService = singerService;
        }


        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] string Name)
        {
            Singer singer = _singerService.Add(Name);
            return Ok(singer);
        }


        [HttpDelete("Remove")]
        [AllowAnonymous]
        public IActionResult Remove([FromBody] string singerId)
        {
            _singerService.Remove(singerId);
            return Ok();
        }



        [HttpPut("Update")]
        [AllowAnonymous]
        public IActionResult Update([FromBody] Singer singer)
        {
            Singer singer1 = _singerService.Update(singer);
            return Ok(singer1);
        }


        [HttpGet("GetbyId")]
        [AllowAnonymous]
        public IActionResult GetById([FromQuery] string singerId)
        {
            Singer singer = _singerService.GetById(singerId);
            return Ok(singer);
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            List<Singer> singers = _singerService.GetAll();
            return Ok(singers);
        }

        [HttpGet("GetbyName")]
        [AllowAnonymous]
        public IActionResult GetByName([FromQuery] string search)
        {
            List<Singer> singers = _singerService.GetByName(search);
            return Ok(singers);
        }


    }
}
