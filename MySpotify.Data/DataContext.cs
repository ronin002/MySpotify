using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


namespace MySpotity.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
                var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");

                var config = configuration.Build();
                var connectionStrings = config.GetConnectionString("DefaultConnection");

                optionsBuilder.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings));
                
                /*
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.use(connectionString);
                
                */
            }
            //optionsBuilder.UseLazyLoadingProxies().UseSqlServer(Config.dbContextConnString);
        }
        

        public DbSet<Music> Musics { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        //public DbSet<Singer> Singers { get; set; }
        //public DbSet<Rhythm> Rhythms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

    }
}
