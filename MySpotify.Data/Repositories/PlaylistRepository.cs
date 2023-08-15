using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpotify.Data.Interfaces;
using MySpotity.Data;

namespace MySpotify.Data.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {

        DataContext _context { get; set; }

        public PlaylistRepository(DataContext context)
        {
            _context = context;
        }

        public Playlist Add(string Name)
        {
            Playlist playlist = new Playlist();
            playlist.Name = Name;
            _context.Playlists.Add(playlist);
            return playlist;

        }
        public void Remove(Guid Id)
        {
      
            try
            {
                var playlist = _context.Playlists.First(x=>x.Id == Id);
                if (playlist != null) 
                {
                    _context.Playlists.Remove(playlist);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                /*
                throw LogsService.HandleException(ex, "Game error", "There was an error removing the game",
                    this.GetType().ToString());
                */
            }
        }
        public Playlist Update(Playlist playlist)
        {
            try
            {
                var i = _context.Playlists.Find(playlist.Id);
                i = playlist;
                _context.Playlists.Update(i);
                _context.SaveChanges();
                return i;
            }
            catch (Exception ex)
            {
                return null;
                /*
                throw LogsService.HandleException(ex, "Item error", "There was an error updating the item",
                    this.GetType().ToString());
                */
            }
        }

        public Playlist GetById(Guid Id)
        {
            try
            {
                return _context.Playlists.First(x => x.Id == Id);

            }
            catch (Exception ex)
            {
                return null;
                /*
                throw LogsService.HandleException(ex, "Game error", "There was an error removing the game",
                    this.GetType().ToString());
                */
            }
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

        
    }
}
