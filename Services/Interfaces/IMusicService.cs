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
        Music Add(Music music);

        void Remove(string MusicId);
        Music Update( Music music);
        Music GetById(string Id);
        List<Music> GetAll();
        List<Music> GetByName(string Name);
        List<Music> GetByRhythm(string Name);
        List<Music> GetBySinger(string Name);


    }
}
