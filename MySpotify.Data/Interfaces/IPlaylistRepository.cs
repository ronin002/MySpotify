using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpotify.Data.Interfaces
{
    public interface IPlaylistRepository
    {
        Playlist Add(string Name);
        void Remove(Guid Id);
        Playlist Update(Playlist playlist);
        Playlist GetById(Guid Id);
        List<Playlist> GetAll();
        List<Playlist> GetByName(string Search);

        void AddMusic(Music music);
        void RemoveMusic(Music music);
        void ChangeOrder(Guid MusicId, int newOrder);
        List<Music> GetMusics();
        List<Music> GetMusicsByName(string Name);
        List<Music> GetMusicsBySinger(string Name);
        List<Music> GetMusicsByRhythm(string Name);

    }
}
