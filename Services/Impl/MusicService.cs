using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpotify.Data.Interfaces;
using MySpotify.Services.Interfaces;
using MySpotify.Data.Repositories;
using System.Security.Cryptography;

namespace MySpotify.Services.Impl
{
    public class MusicService : IMusicService
    {
        IMusicRepository _musicRepository { get; set; }

        public MusicService(IMusicRepository musicRepository)
        {
            _musicRepository =  musicRepository;
        }


        public Music Add(Music music)
        {
            return _musicRepository.Add(music);
        }

        public void Remove(string Id)
        {
            Guid guid = Guid.Parse(Id);
            _musicRepository.Remove(guid);
        }

        public Music Update(Music playlist)
        {
            playlist = _musicRepository.Update(playlist);
            return playlist;
        }

        public Music GetById(string Id)
        {
            Guid guid = Guid.Parse(Id);
            return _musicRepository.GetById(guid);
        }

        public List<Music> GetAll()
        {
            var playlists = _musicRepository.GetAll();
            return playlists;
        }


        public List<Music> GetByName(string Name)
        {
            var playlists = _musicRepository.GetByName(Name);
            return playlists;
        }

        public List<Music> GetBySinger(string Name)
        {
            var playlists = _musicRepository.GetBySinger(Name);
            return playlists;
        }

        public List<Music> GetByRhythm(string Name)
        {
            var playlists = _musicRepository.GetByRhythm(Name);
            return playlists;
        }


        #region CopyAndGetTag
        /*
        public async Task<string> CopiaArquivo(IFormFile arquivo)
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

                return hash;
            }
            catch (Exception)
            {

                return "";
            }

        }
        
        public async Task<Music> GetTags(IFormFile arquivo)
        {
            //Duraction 27
            //Title 21
            //Authors 20
            //Album 14
            //Artists 13
            const int ARTIST = 13;
            const int ALBUM = 14;
            const int RHYTHM = 16;
            const int AUTHORS = 20;
            const int TITLE = 21;
            const int DURATION = 27;


            Music music = new Music();

            List<string> arrHeaders = new List<string>();
            var shellapp = WScript.CreateObject("Shell.Application");
            var shell = new Shell32.Shell();
            var strFileName = _environment.WebRootPath + "\\musics\\" + arquivo.FileName;
            Shell32.Folder objFolder = shell.NameSpace(System.IO.Path.GetDirectoryName(strFileName));
            Shell32.FolderItem folderItem = objFolder.ParseName(System.IO.Path.GetFileName(strFileName));

            for (int i = 0; i < short.MaxValue; i++)
            {
                string header = objFolder.GetDetailsOf(null, i);
                if (String.IsNullOrEmpty(header))
                    break;
                arrHeaders.Add(header);
            }

            for (int i = 0; i < arrHeaders.Count; i++)
            {
                //Console.WriteLine("{ 0}\t{ 1}: { 2}", i, arrHeaders[i], objFolder.GetDetailsOf(folderItem, i));
                //Console.WriteLine($"{i} - {arrHeaders[i]} , {objFolder.GetDetailsOf(folderItem, i)}");
            }

            music.Name = arquivo.FileName;

            if (arrHeaders.Count >= 27)
            {
                music.Artist = objFolder.GetDetailsOf(folderItem, ARTIST).ToString();
                music.Rhythm = objFolder.GetDetailsOf(folderItem, RHYTHM).ToString();
                music.Album = objFolder.GetDetailsOf(folderItem, ALBUM).ToString();
                music.Author = objFolder.GetDetailsOf(folderItem, AUTHORS).ToString();
                music.Title = objFolder.GetDetailsOf(folderItem, TITLE).ToString();
                music.Duration = objFolder.GetDetailsOf(folderItem, DURATION).ToString();
            }
            //Console.ReadLine();



            return music;
        }
        */
        #endregion
    }
}
