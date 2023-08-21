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

        void AddMusic(Guid PlaylistId, Guid MusicId);
        void RemoveMusic(Guid PlaylistId, Guid MusicId);
        void ChangeOrder(Guid PlaylistId, Guid MusicId, int newOrder);
        List<Music> GetMusics(Guid PlaylistId);
        List<Music> GetMusicsByName(Guid PlaylistId, string Name);
        List<Music> GetMusicsBySinger(Guid PlaylistId, string Name);
        List<Music> GetMusicsByRhythm(Guid PlaylistId, string Name);

    }
}
