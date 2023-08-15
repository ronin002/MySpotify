using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpotify.Services.Interfaces
{
    public interface IMusicService
    {
        Music Add(Music singer);
        Music Remove(Music singer);
        Music Update(int Id, Music singer);
        Music GetById(int Id);
        List<Music> GetAll();
        List<Music> GetByName(string Name);
        List<Music> GetByRhythm(string Name);
        List<Music> GetBySinger(string Name);

    }
}
