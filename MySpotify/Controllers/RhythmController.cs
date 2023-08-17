
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


        [HttpPost("api/v1/Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] string Name)
        {
            Rhythm playlist = _rhythmService.Add(Name);
            return Ok(playlist);
        }


        [HttpDelete("api/v1/Remove")]
        [AllowAnonymous]
        public IActionResult Remove([FromBody] string playlistId)
        {
            _rhythmService.Remove(playlistId);
            return Ok();
        }



        [HttpPut("api/v1/Update")]
        [AllowAnonymous]
        public IActionResult Update([FromBody] Playlist playlist)
        {
            Rhythm playlist1 = _rhythmService.Update(playlist);
            return Ok(playlist1);
        }


        [HttpGet("api/v1/GetbyId")]
        [AllowAnonymous]
        public IActionResult GetById([FromQuery] string playlistId)
        {
            Rhythm rhythm = _rhythmService.GetById(rhythm);
            return Ok(rhythm);
        }


   

    }
}
