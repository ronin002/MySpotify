using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpotify.Data.Interfaces;
using MySpotity.Data;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace MySpotify.Data.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {

        DataContext _context { get; set; }
        private ILogsService LogsService { get; set; }

        public PlaylistRepository(ILogsService logsService, DataContext context)
        {
            _context = context;
            LogsService = logsService;
        }

        public Playlist Add(string Name)
        {
            
            try
            {
                Playlist playlist = new Playlist();
                playlist.Name = Name;
                _context.Playlists.Add(playlist);
                _context.SaveChanges();
                return playlist;
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Playlist error", "There was an error removing the Playlist",
                    this.GetType().ToString());
            }

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
                
                throw LogsService.HandleException(ex, "Playlist error", "There was an error removing the Playlist",
                    this.GetType().ToString());
            }
        }
        public Playlist Update(Playlist playlist)
        {
            try
            {
                //var i = _context.Playlists.Find(playlist.Id);
                //i = playlist;
                _context.Playlists.Update(playlist);
                _context.SaveChanges();
                return playlist;
            }
            catch (Exception ex)
            {     
                throw LogsService.HandleException(ex, "Playlist error", "There was an error updating the Playlist",
                    this.GetType().ToString());
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

                throw LogsService.HandleException(ex, "Playlist error", "There was an error get the Playlist",
                    this.GetType().ToString());
                
            }
        }


        public List<Playlist> GetAll()
        {
            try
            {
                return _context.Playlists.ToList();

            }
            catch (Exception ex)
            {
                return null;

                throw LogsService.HandleException(ex, "Playlist error", "There was an error get the Playlist",
                    this.GetType().ToString());

            }
        }

        public List<Playlist> GetByName(string Search)
        {
            try
            {
                return _context.Playlists.Where(x => x.Name.Contains(Search)).ToList();

            }
            catch (Exception ex)
            {
                return null;

                throw LogsService.HandleException(ex, "Playlist error", "There was an error get the Playlist",
                    this.GetType().ToString());

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
