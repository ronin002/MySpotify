using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpotify.Services.Interfaces
{
    public interface IPlaylistService
    {
        Playlist Add(string Name);
        void Remove(string Id);
        Playlist Update(Playlist playlist);
        Playlist GetById(string Id);
        List<Playlist> GetAll();

        void AddMusic(Music music);
        void RemoveMusic(Music music);
        void ChangeOrder(Guid MusicId, int newOrder);
        List<Music> GetMusics();
        List<Music> GetMusicsByName(string Name);
        List<Music> GetMusicsBySinger(string Name);
        List<Music> GetMusicsByRhythm(string Name);

    }
}
