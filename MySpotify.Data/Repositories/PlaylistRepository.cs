using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpotify.Data.Interfaces;

namespace MySpotify.Data.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        public Playlist Add(Playlist singer)
        {
            throw new NotImplementedException();
        }

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

        public Playlist GetById(Playlist Id)
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

        public Playlist Remove(Playlist singer)
        {
            throw new NotImplementedException();
        }

        public void RemoveMusic(Music music)
        {
            throw new NotImplementedException();
        }

        public Playlist Update(Playlist Id, Music singer)
        {
            throw new NotImplementedException();
        }
    }
}
