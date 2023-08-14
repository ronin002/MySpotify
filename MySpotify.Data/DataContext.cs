using Microsoft.EntityFrameworkCore;
using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpotity.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Rhythm> Rhythms { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
