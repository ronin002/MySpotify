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
    public class RhythmRepository : IRhythmRepository
    {
        DataContext _context { get; set; }
        private ILogsService LogsService { get; set; }


        public RhythmRepository(DataContext context, ILogsService logsService)
        {
            _context = context;
            LogsService = logsService;
        }

        public Rhythm Add(string RhythmName)
        {
            try
            {
                Rhythm rhythm = new Rhythm();
                rhythm.Name = RhythmName;
                _context.Rhythms.Add(rhythm);
                _context.SaveChanges();
                return rhythm;
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Rhythm error", "There was an error removing the Rhythm",
                    this.GetType().ToString());
            }
        }

        public List<Rhythm> GetAll()
        {
            try
            {
                return _context.Rhythms.ToList();

            }
            catch (Exception ex)
            {
                return null;

                throw LogsService.HandleException(ex, "Rhythm error", "There was an error get the Rhythm",
                    this.GetType().ToString());

            }
        }

        public Rhythm GetById(int Id)
        {
            try
            {
                return _context.Rhythms.First(x => x.Id == Id);

            }
            catch (Exception ex)
            {
                return null;

                throw LogsService.HandleException(ex, "Rhythm error", "There was an error get the Rhythm",
                    this.GetType().ToString());

            }
        }

        public List<Rhythm> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public void Remove(Rhythm rhythm)
        {
            try
            {
                var rhythm1 = _context.Rhythms.First(x => x.Id == rhythm.Id);
                if (rhythm1 != null)
                {
                    _context.Rhythms.Remove(rhythm1);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw LogsService.HandleException(ex, "Rhythm error", "There was an error removing the Rhythm",
                    this.GetType().ToString());
            }
        }

        public Rhythm Update(Rhythm rhythm)
        {
            try
            {
                //var i = _context.Playlists.Find(playlist.Id);
                //i = playlist;
                _context.Rhythms.Update(rhythm);
                _context.SaveChanges();
                return rhythm;
            }
            catch (Exception ex)
            {
                return null;

                throw LogsService.HandleException(ex, "Rhythm error", "There was an error updating the Rhythm",
                    this.GetType().ToString());

            }
        }
    }
}
