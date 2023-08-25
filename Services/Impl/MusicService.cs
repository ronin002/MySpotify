using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpotify.Data.Interfaces;
using MySpotify.Services.Interfaces;
using MySpotify.Data.Repositories;

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

        public MusicDto GetById(string Id)
        {
            Guid guid = Guid.Parse(Id);
            return _musicRepository.GetById(guid);
        }

        public List<MusicDto> GetAll()
        {
            var playlists = _musicRepository.GetAll();
            return playlists;
        }


        public List<MusicDto> GetByName(string Name)
        {
            var playlists = _musicRepository.GetByName(Name);
            return playlists;
        }

        public List<MusicDto> GetBySinger(string Name)
        {
            var playlists = _musicRepository.GetBySinger(Name);
            return playlists;
        }

        public List<MusicDto> GetByRhythm(string Name)
        {
            var playlists = _musicRepository.GetByRhythm(Name);
            return playlists;
        }

    }
}
