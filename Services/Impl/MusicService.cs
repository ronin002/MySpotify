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
    public class MusicService : IMusicService
    {

        IMusicRepository musicRepository { get; set; }
        public Music Add(Music singer)
        {
            throw new NotImplementedException();
        }

        public List<Music> GetAll()
        {
            throw new NotImplementedException();
        }

        public Music GetById(int Id)
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

        public Music Update(int Id, Music singer)
        {
            throw new NotImplementedException();
        }
    }
}
