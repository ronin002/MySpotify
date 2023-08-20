using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpotify.Data.Interfaces;
using MySpotity.Data;
using System.Xml.Linq;

namespace MySpotify.Data.Repositories
{
    public class SingerRepository : ISingerRepository
    {
        DataContext _context { get; set; }
        private ILogsService LogsService { get; set; }

        public SingerRepository(ILogsService logsService, DataContext context)
        {
            _context = context;
            LogsService = logsService;
        }
        public Singer Add(string Name)
        {
            try
            {
                Singer singer = new Singer();
                singer.Name = Name;
                _context.Singers.Add(singer);
                _context.SaveChanges();
                return singer;
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Singer error", "There was an error removing the Singer",
                    this.GetType().ToString());
            }
        }

        public void Remove(Guid singerId)
        {

            try
            {
                var singer1 = _context.Singers.First(x => x.Id == singerId);
                if (singer1 != null)
                {
                    _context.Singers.Remove(singer1);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw LogsService.HandleException(ex, "Singer error", "There was an error removing the Singer",
                    this.GetType().ToString());
            }
        }


        public Singer Update(Singer singer)
        {
            try
            {
                //var i = _context.Playlists.Find(playlist.Id);
                //i = playlist;
                _context.Singers.Update(singer);
                _context.SaveChanges();
                return singer;
            }
            catch (Exception ex)
            {
                throw LogsService.HandleException(ex, "Singer error", "There was an error updating the Singer",
                    this.GetType().ToString());
            }
        }
        public List<Singer> GetAll()
        {
            try
            {
                return _context.Singers.ToList();

            }
            catch (Exception ex)
            {
                throw LogsService.HandleException(ex, "Singer error", "There was an error get the Singer",
                    this.GetType().ToString());
            }
        }

        public Singer GetById(Guid Id)
        {
            try
            {
                return _context.Singers.First(x => x.Id == Id);

            }
            catch (Exception ex)
            {
                throw LogsService.HandleException(ex, "Singer error", "There was an error get the Singer",
                    this.GetType().ToString());
            }
        }

        public List<Singer> GetByName(string Name)
        {
            try
            {
                return _context.Singers.Where(x => x.Name.Contains(Name)).ToList();

            }
            catch (Exception ex)
            {
                throw LogsService.HandleException(ex, "Singer error", "There was an error get the Singer",
                    this.GetType().ToString());
            }
        }

      
    }
}
