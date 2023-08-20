
using MySpotify.Models.Dtos;
using MySpotify.Models;
using MySpotify.Services.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySpotify.Services.Interfaces;

namespace MySpotify.Controllers
{

    public class RhythmController : BaseController
    {

        private IRhythmService _rhythmService;
        public RhythmController(IServiceProvider sp,
                                IRhythmService rhythmService
                                ) :base(sp)
        {
            _rhythmService = rhythmService;
        }


        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] string Name)
        {
            Rhythm playlist = _rhythmService.Add(Name);
            return Ok(playlist);
        }


        [HttpDelete("Remove")]
        [AllowAnonymous]
        public IActionResult Remove([FromBody] string rhythm)
        {
            _rhythmService.Remove(rhythm);
            return Ok();
        }



        [HttpPut("Update")]
        [AllowAnonymous]
        public IActionResult Update([FromBody] Rhythm rhythm)
        {
            Rhythm rhythm1 = _rhythmService.Update(rhythm);
            return Ok(rhythm1);
        }


        [HttpGet("GetbyId")]
        [AllowAnonymous]
        public IActionResult GetById([FromBody] string rhythmId)
        {
            Rhythm rhythm = _rhythmService.GetById(rhythmId);
            return Ok(rhythm);
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            List<Rhythm> rhythms = _rhythmService.GetAll();
            return Ok(rhythms);
        }

        [HttpGet("GetbyName")]
        [AllowAnonymous]
        public IActionResult GetByName([FromBody] string search)
        {
            List<Rhythm> rhythms = _rhythmService.GetByName(search);
            return Ok(rhythms);
        }


    }
}
