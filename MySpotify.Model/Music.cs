using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySpotify.Models
{
    public class Music
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Album { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string MusicURL { get; set; }

        [ForeignKey("FK_Rhythm")]
        public int RhythmId { get; set; }
        public virtual Rhythm Rhythm { get; set; }


        [ForeignKey ("FK_Singer")]
        public Guid SingerId { get; set; }
        public virtual Singer Singer { get; set; }


    }
}
