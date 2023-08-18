﻿
using MySpotify.Models.Dtos;
using MySpotify.Models;
using MySpotify.Services.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySpotify.Services.Interfaces;
using MySpotify.Services.Impl;

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


        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] string Name)
        {
            Playlist playlist = _playlistService.Add(Name);
            return Ok(playlist);
        }


        [HttpDelete("Remove")]
        [AllowAnonymous]
        public IActionResult Remove([FromBody] string playlistId)
        {
            _playlistService.Remove(playlistId);
            return Ok();
        }



        [HttpPut("Update")]
        [AllowAnonymous]
        public IActionResult Update([FromBody] Playlist playlist)
        {
            Playlist playlist1 = _playlistService.Update(playlist);
            return Ok(playlist1);
        }


        [HttpGet("GetById")]
        [AllowAnonymous]
        public IActionResult GetById([FromQuery] string playlistId)
        {
            Playlist playlist = _playlistService.GetById(playlistId);
            return Ok(playlist);
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            List<Playlist> playlists = _playlistService.GetAll();
            return Ok(playlists);
        }

        [HttpGet("GetByName")]
        [AllowAnonymous]
        public IActionResult GetByName([FromQuery] string search)
        {
            List<Playlist> playlists = _playlistService.GetByName(search);
            return Ok(playlists);
        }


    }
}
