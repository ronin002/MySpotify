﻿
using MySpotify.Models.Dtos;
using MySpotify.Models;
using MySpotify.Services.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySpotify.Services.Interfaces;
using MySpotify.Services.Impl;
using System.IO;
using System.Drawing;
using System.Security.Cryptography;
using System.IO.Pipes;


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
        public async Task<IActionResult> EnviaArquivo([FromForm] IFormFile arquivo)
        {
            if (arquivo.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\musics\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\musics\\");
                    }

                    string hash = "";

                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\musics\\" + arquivo.FileName))
                    {
                        await arquivo.CopyToAsync(filestream);
                        filestream.Flush();
                        using (var sha = SHA256.Create())
                        {
                            hash = Convert.ToBase64String(sha.ComputeHash(filestream));
                        }
                    }

                    TagLib.File tagFile = TagLib.File.Create(_environment.WebRootPath + "\\musics\\" + arquivo.FileName);
                    string artist = tagFile.Tag.FirstAlbumArtist;
                    string album = tagFile.Tag.Album;
                    string title = tagFile.Tag.Title;
                    TimeSpan duration = tagFile.Properties.Duration;

                    Music music = new Music();
                    //music.Singer.Name = artist;
                    music.Album = album;
                    music.Title = title;

                    if (duration.ToString().Length >=9)
                        music.Duration = duration.ToString().Substring(0,8);
                    else
                        music.Duration = duration.ToString();

                    music.Name = arquivo.FileName;
                    music.MusicURL = hash;





                    //Catch Picture

                    /*
                    var mStream = new MemoryStream();
                    var firstPicture = tagFile.Tag.Pictures.FirstOrDefault();

                    if (firstPicture != null)
                    {
                        byte[] pData = firstPicture.Data.Data;
                        mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                        var bm = new Bitmap(mStream, false);
                        mStream.Dispose();
                        coverPictureBox.Image = bm;
                    }
                    else
                    {
                        // set "no cover" image
                    }
                    music.ImageURL
                    */
                    this.Create(music);

                    return Ok(music);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }
            else
            {
                return  BadRequest("Ocorreu uma falha no envio do arquivo...");
            }
        }
    }

}
