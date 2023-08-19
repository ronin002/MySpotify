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

    public class MusicController : BaseController
    {

        private IMusicService _musicService;
        public static IWebHostEnvironment _environment;
        public MusicController(IServiceProvider sp,
                                IWebHostEnvironment environment,
                                IMusicService musicService,
                                IPlaylistService playlistService
                                ) :base(sp)
        {
            _musicService = musicService;
            _environment = environment;
        }


        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] Music music)
        {
            Music music1 = _musicService.Add(music);
            return Ok(music1);
        }


        [HttpDelete("Remove")]
        [AllowAnonymous]
        public IActionResult Remove([FromBody] string musicId)
        {
            _musicService.Remove(musicId);
            return Ok();
        }



        [HttpPut("Update")]
        [AllowAnonymous]
        public IActionResult Update([FromBody] Music music)
        {
            Music music1 = _musicService.Update(music);
            return Ok(music1);
        }


        [HttpGet("GetById")]
        [AllowAnonymous]
        public IActionResult GetById([FromBody] string musicId)
        {
            Music music = _musicService.GetById(musicId);
            return Ok(music);
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            List<Music> musics = _musicService.GetAll();
            return Ok(musics);
        }

        [HttpGet("GetByName")]
        [AllowAnonymous]
        public IActionResult GetByName([FromBody] string search)
        {
            List<Music> musics = _musicService.GetByName(search);
            return Ok(musics);
        }

        [HttpGet("GetBySinger")]
        [AllowAnonymous]
        public IActionResult GetBySinger([FromBody] string search)
        {
            List<Music> musics = _musicService.GetBySinger(search);
            return Ok(musics);
        }

        [HttpGet("GetByRhythm")]
        [AllowAnonymous]
        public IActionResult GetByRhythm([FromBody] string search)
        {
            List<Music> musics = _musicService.GetByRhythm(search);
            return Ok(musics);
        }




        [HttpPost("Upload")]
        [AllowAnonymous]
        public async Task<string> EnviaArquivo([FromForm] IFormFile arquivo)
        {
            if (arquivo.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\musics\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\musics\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\musics\\" + arquivo.FileName))
                    {
                        await arquivo.CopyToAsync(filestream);
                        filestream.Flush();
                        return "\\imagens\\" + arquivo.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Ocorreu uma falha no envio do arquivo...";
            }
        }
    }

}