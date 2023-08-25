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
        MusicDto GetById(string Id);
        List<MusicDto> GetAll();
        List<MusicDto> GetByName(string Name);
        List<MusicDto> GetByRhythm(string Name);
        List<MusicDto> GetBySinger(string Name);

    }
}
