
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
using Microsoft.IdentityModel.Tokens;

namespace MySpotify.Controllers
{

    public class MusicController : BaseController
    {

        private IMusicService _musicService;
        private IPlaylistService _playlistService;


        public static IWebHostEnvironment _environment;

        public MusicController(IServiceProvider sp,
                                IWebHostEnvironment environment,
                                IMusicService musicService,
                                IPlaylistService playlistService
                                ) :base(sp)
        {
            _musicService = musicService;
            _environment = environment;
            _playlistService = playlistService;
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
        public IActionResult GetByName([FromQuery] string search)
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

                    string hash;
                    string FilePath = _environment.WebRootPath + "\\musics\\" + arquivo.FileName;
                    using (FileStream filestream = System.IO.File.Create(FilePath))
                    {

                        await arquivo.CopyToAsync(filestream);
                        filestream.Flush();

                        using (var md5 = MD5.Create())
                        {
                            var hashMD5 = md5.ComputeHash(filestream);
                            var base64String = Convert.ToBase64String(hashMD5);
                            hash = base64String;
                        }
                    }
                    HashAlgorithm cryptoService = SHA256.Create();
                    using (cryptoService)
                    {
                        using (var fileStream = new FileStream(FilePath,
                                                               FileMode.Open,
                                                               FileAccess.Read,
                                                               FileShare.ReadWrite))
                        {
                            var hashLocal = cryptoService.ComputeHash(fileStream);
                            var hashString = Convert.ToBase64String(hashLocal);
                            hash = hashString;
                        }
                    }
                    TagLib.File tagFile = TagLib.File.Create(_environment.WebRootPath + "\\musics\\" + arquivo.FileName);
                    TagLib.Tag tag = tagFile.GetTag(TagLib.TagTypes.AllTags);

                    string artist = "";
                    string author = "";
                    string album = "";
                    string title = arquivo.FileName;
                    string rhythm = "";

                    if (!string.IsNullOrEmpty(tagFile.Tag.Title)) title = tagFile.Tag.Title;
                    if (!string.IsNullOrEmpty(tagFile.Tag.FirstPerformer)) author = tagFile.Tag.FirstPerformer;
                    if (!string.IsNullOrEmpty(tagFile.Tag.FirstAlbumArtist)) artist = tagFile.Tag.FirstAlbumArtist;
                    if (!string.IsNullOrEmpty(tagFile.Tag.Album)) album = tagFile.Tag.Album;
                    if (tagFile.Tag.Genres.Length > 0) rhythm = tagFile.Tag.Genres[0];


                    string duration = "";
                    if (tagFile.Properties.Duration != null)
                    {
                        duration = tagFile.Properties.Duration.ToString();
                        if (duration.Length >=8) duration = duration.ToString().Substring(0, 8);
                    }

                    Music music = new Music();
                    music.Name = arquivo.FileName;
                    music.Artist = artist;
                    music.Album = album;
                    music.Title = title;
                    music.Rhythm = rhythm;
                    music.Author = author;
                    music.MusicURL = hash;
                    music.Duration = duration;


                    foreach(string item in tagFile.Tag.Performers)
                    {
                        Console.WriteLine(item);
                    }


                    foreach (string item in tagFile.Tag.AlbumArtists)
                    {
                        Console.WriteLine(item);
                    }
                    

                    /*
                    
                    if (artist != null)
                    {

                        //List<Singer> singers =(List<Singer>) new SingerController(_serviceProvider, _singerService).GetByName(artist);                        

                        List<Singer> singers = _singerService.GetByName(artist);

                        if (singers != null && singers.Count >= 1)
                            music.SingerId = singers[0].Id;
                        else
                        {
                            //Singer newSinger = (Singer)new SingerController(_serviceProvider, _singerService).Create(artist);
                            Singer newSinger = _singerService.Add(artist);
                            music.SingerId = newSinger.Id;
                        }
                    }

                    music.Album = album;
                    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title)) title = arquivo.FileName;
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
