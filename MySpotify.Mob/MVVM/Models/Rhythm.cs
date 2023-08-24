using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace MySpotify.Mob.MVVM.Models
{
    public class Rhythm
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageURL { get; set; }
        public IList<Music> Musics { get; set; }
    }
}
