
using MySpotify.Models.Dtos;
using MySpotify.Models;
using MySpotify.Services.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySpotify.Services.Interfaces;

namespace MySpotify.Controllers
{

    public class PlaylistController : BaseController
    {

        private IPlaylistService _playlistService;
        private IMusicService _musicService;
        public PlaylistController(IServiceProvider sp,
                                IMusicService musicService,
                                IPlaylistService playlistService
                                ) :base(sp)
        {
            _musicService = musicService;
            _playlistService = playlistService;
        }


        [HttpPost("api/v1/Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] string Name)
        {
            Playlist playlist = _playlistService.Add(Name);
            return Ok(playlist);
        }


        [HttpDelete("api/v1/Remove")]
        [AllowAnonymous]
        public IActionResult Remove([FromBody] string playlistId)
        {
            _playlistService.Remove(playlistId);
            return Ok();
        }



        [HttpPut("api/v1/Update")]
        [AllowAnonymous]
        public IActionResult Update([FromBody] Playlist playlist)
        {
            Playlist playlist1 = _playlistService.Update(playlist);
            return Ok(playlist1);
        }


        [HttpGet("api/v1/GetbyId")]
        [AllowAnonymous]
        public IActionResult GetById([FromQuery] string playlistId)
        {
            Playlist playlist = _playlistService.GetById(playlistId);
            return Ok(playlist);
        }


   

    }
}
