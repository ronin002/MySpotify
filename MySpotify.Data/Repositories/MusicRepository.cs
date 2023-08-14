using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpotify.Data.Interfaces;

namespace MySpotify.Data.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        public Music Add(Music singer)
        {
            throw new NotImplementedException();
        }

        public List<Music> GetAll()
        {
            throw new NotImplementedException();
        }

        public Music GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Music> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Music> GetByRhythm(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Music> GetBySinger(string Name)
        {
            throw new NotImplementedException();
        }

        public Music Remove(Music singer)
        {
            throw new NotImplementedException();
        }

        public Music Update(Guid Id, Music singer)
        {
            throw new NotImplementedException();
        }
    }
}
