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
        Music Add(Music music);
        void Remove(Guid Id);
        Music Update(Music music);
        MusicDto GetById(Guid Id);
        List<MusicDto> GetAll();
        List<MusicDto> GetByName(string Name);
        List<MusicDto> GetByRhythm(string Name);
        List<MusicDto> GetBySinger(string Name);

    }
}
