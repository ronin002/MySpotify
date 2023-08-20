using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpotify.Data.Interfaces;
using MySpotity.Data;
using System.Xml.Linq;
using System.Reflection;

namespace MySpotify.Data.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        DataContext _context { get; set; }
        private ILogsService LogsService { get; set; }
        public MusicRepository(ILogsService logsService, DataContext context)
        {
            LogsService = logsService;
            _context = context;
        }
        public Music Add(Music music)
        {
            try
            {
                var exitsMusic = _context.Musics.Where(x=> x.MusicURL == music.MusicURL).Count();
                if (exitsMusic <= 0)
                {
                    _context.Musics.Add(music);
                    _context.SaveChanges();
                    return music;
                }
                else
                {
                   Exception ex = new Exception("Music Already exists");      
                   throw LogsService.HandleException(ex, "Music error", "There was an error adding the Music",
                   this.GetType().ToString());
                }
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Music error", "There was an error adding the Music",
                    this.GetType().ToString());
            }
        }
        public void Remove(Guid Id)
        {
            try
            {
                var music1 = _context.Musics.First(x => x.Id == Id);
                if (music1 != null)
                {
                    _context.Musics.Remove(music1);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Music error", "There was an error removing the Music",
                    this.GetType().ToString());
            }
        }

        public Music Update(Music music)
        {
            try
            {
                //var i = _context.Playlists.Find(playlist.Id);
                //i = playlist;
                _context.Musics.Update(music);
                _context.SaveChanges();
                return music;
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Music error", "There was an error updating the Music",
                    this.GetType().ToString());

            }
        }
        public List<Music> GetAll()
        {
            try
            {
                return _context.Musics.ToList();

            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Music error", "There was an error GetByName the Music",
                    this.GetType().ToString());

            }
        }

        public Music GetById(Guid Id)
        {
            try
            {
                return _context.Musics.First(x => x.Id == Id);
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Music error", "There was an error GetById the Music",
                    this.GetType().ToString());

            }
        }

        public List<Music> GetByName(string Name)
        {
            try
            {
                return _context.Musics.Where(x => x.Name.Contains(Name) || 
                                             x.Singer.Name.Contains(Name) ||
                                             x.Rhythm.Name.Contains(Name)).ToList();
                
            }
            catch (Exception ex)
            {
   
                throw LogsService.HandleException(ex, "Music error", "There was an error GetByName the Music",
                    this.GetType().ToString());

            }
        }

        public List<Music> GetByRhythm(string Name)
        {
            try
            {
                return _context.Musics.Where(x => x.Rhythm.Name.Contains(Name)).ToList();

            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Music error", "There was an error GetByName the Music",
                    this.GetType().ToString());

            }
        }

        public List<Music> GetBySinger(string Name)
        {
            try
            {
                return _context.Musics.Where(x => x.Singer.Name.Contains(Name)).ToList();
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Music error", "There was an error GetByName the Music",
                    this.GetType().ToString());

            }
        }
    }
}
