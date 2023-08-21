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
        List<Playlist> GetByName(string Name);

        void AddMusic(string PlaylistId, string MusicId);
        void RemoveMusic(string PlaylistId, string MusicId);
        void ChangeOrder(string PlaylistId, string MusicId, int newOrder);
        List<Music> GetMusics(string PlaylistId);
        List<Music> GetMusicsByName(string PlaylistId, string MusicId);
        List<Music> GetMusicsBySinger(string PlaylistId, string MusicId);
        List<Music> GetMusicsByRhythm(string PlaylistId, string MusicId);

    }
}
