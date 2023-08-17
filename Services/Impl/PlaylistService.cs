using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpotify.Data.Interfaces;
using MySpotify.Services.Interfaces;

namespace MySpotify.Services.Impl
{
    public class PlaylistService : IPlaylistService
    {
        IPlaylistRepository _playlistRepository;

        public PlaylistService(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public Playlist Add(string playlistName)
        {
            return _playlistRepository.Add(playlistName);
        }

        public void Remove(string Id)
        {
            Guid guid = Guid.Parse(Id);
            _playlistRepository.Remove(guid);
        }

        public Playlist Update(Playlist playlist)
        {
            playlist = _playlistRepository.Update(playlist);
            return playlist;
        }

        public Playlist GetById(string Id)
        {
            Guid guid = Guid.Parse(Id);
            return _playlistRepository.GetById(guid);
        }




        #region Music



        public void AddMusic(Music music)
        {
            throw new NotImplementedException();
        }

  
        public void ChangeOrder(Guid MusicId, int newOrder)
        {
            throw new NotImplementedException();
        }

        public List<Playlist> GetAll()
        {
            throw new NotImplementedException();
        }

 

        public List<Music> GetMusics()
        {
            throw new NotImplementedException();
        }

        public List<Music> GetMusicsByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Music> GetMusicsByRhythm(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Music> GetMusicsBySinger(string Name)
        {
            throw new NotImplementedException();
        }

       

        public void RemoveMusic(Music music)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}