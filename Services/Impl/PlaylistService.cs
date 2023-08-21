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

        public Playlist GetById( string Id)
        {
            Guid guid = Guid.Parse(Id);
            return _playlistRepository.GetById(guid);
        }

        public List<Playlist> GetAll()
        {
            var playlists = _playlistRepository.GetAll();
            return playlists;
        }


        public List<Playlist> GetByName(string Name)
        {
            var playlists = _playlistRepository.GetByName(Name);
            return playlists;
        }


        #region Music



        public void AddMusic(string PlaylistId, string MusicId)
        {
            Guid gPlaylistId = Guid.Empty;
            Guid gMusicId = Guid.Empty;

            if (!Guid.TryParse(PlaylistId, out gPlaylistId))
                return;

            if (!Guid.TryParse(MusicId, out gMusicId))
                return;
              
            _playlistRepository.AddMusic(gPlaylistId, gMusicId);

        }

  
        public void ChangeOrder(string PlaylistId, string MusicId, int newOrder)
        {
            throw new NotImplementedException();
        }

 

        public List<Music> GetMusics(string PlaylistId)
        {
            throw new NotImplementedException();
        }

        public List<Music> GetMusicsByName(string PlaylistId, string MusicName)
        {
            throw new NotImplementedException();
        }

        public List<Music> GetMusicsByRhythm(string PlaylistId, string Rhythm)
        {
            throw new NotImplementedException();
        }

        public List<Music> GetMusicsBySinger(string PlaylistId, string Singer)
        {
            throw new NotImplementedException();
        }

       

        public void RemoveMusic(string PlaylistId, string MusicId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}