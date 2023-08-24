using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySpotify.Mob.MVVM.Models
{
    public class Playlist
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string? ImageURL { get; set; }
        public IList<Music> Musics { get; set; }


    }
}
