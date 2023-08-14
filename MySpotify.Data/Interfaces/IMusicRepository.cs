using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpotify.Data.Interfaces
{
    public interface IMusicRepository
    {
        Music Add(Music singer);
        Music Remove(Music singer);
        Music Update(Guid Id, Music singer);
        Music GetById(Guid Id);
        List<Music> GetAll();
        List<Music> GetByName(string Name);
        List<Music> GetByRhythm(string Name);
        List<Music> GetBySinger(string Name);

    }
}
