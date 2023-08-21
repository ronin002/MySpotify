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



        public void AddMusic(Guid PlaylistId, Guid MusicId)
        {
            try
            {
                var playlist = _context.Playlists.Find(PlaylistId);
                if (playlist == null) return;

                var musicExists = _context.Musics.FirstOrDefault(x => x.Id == MusicId);
                if (musicExists == null) return;

                IList<Music> Musics = new List<Music>();
                if (playlist.Musics != null)
                {
                    var musicOnPlaylist = playlist.Musics.Where(y => y.Id == MusicId).ToList();
                    if (musicOnPlaylist != null) return;
                    Musics = playlist.Musics;
                }
                Musics.Add(musicExists);

                playlist.Musics = Musics;
                
                _context.SaveChanges();
                
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Playlist error", "There was an error adding Music to the Playlist",
                    this.GetType().ToString());
            }
        }

        public void ChangeOrder(Guid PlaylistId, Guid MusicId, int newOrder)
        {
            throw new NotImplementedException();
        }

        
        

        public List<Music> GetMusics(Guid PlaylistId)
        {
            try
            {
                var playlist = _context.Playlists.Find(PlaylistId);
                if (playlist == null) return null;


                var musics = playlist.Musics.ToList();
                return musics;
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Playlist error", "There was an error  get all Musics of the Playlist",
                    this.GetType().ToString());
            }
        }

        public List<Music> GetMusicsByName(Guid PlaylistId, string Name)
        {
            try
            {
                var playlist = _context.Playlists.Find(PlaylistId);
                if (playlist == null) return null ;


                var musics = playlist.Musics.Where(x=>x.Name.Contains(Name)).ToList();
                return musics;
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Playlist error", "There was an error  get Music By Name of the Playlist",
                    this.GetType().ToString());
            }
        }

        public List<Music> GetMusicsByRhythm(Guid PlaylistId, string Name)
        {
            try
            {
                var playlist = _context.Playlists.Find(PlaylistId);
                if (playlist == null) return null;


                var musics = playlist.Musics.Where(x => x.Rhythm.Name.Contains(Name)).ToList();
                return musics;
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Playlist error", "There was an error get Music By Rhytmn of the Playlist",
                    this.GetType().ToString());
            }
        }

        public List<Music> GetMusicsBySinger(Guid PlaylistId, string Name)
        {
            try
            {
                var playlist = _context.Playlists.Find(PlaylistId);
                if (playlist == null) return null;


                var musics = playlist.Musics.Where(x => x.Singer.Name.Contains(Name)).ToList();
                return musics;
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Playlist error", "There was an error get Music By Singer of the Playlist",
                    this.GetType().ToString());
            }
        }

    

        public void RemoveMusic(Guid PlaylistId, Guid MusicId)
        {
            try
            {
                var playlist = _context.Playlists.Find(PlaylistId);
                if (playlist == null) return;

                var musicExists = playlist.Musics.Where(x => x.Id == MusicId).First();
                playlist.Musics.Remove(musicExists);
                return;
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Playlist error", "There was an error removing music of Playlist",
                    this.GetType().ToString());
            }
        }

        
    }
}
