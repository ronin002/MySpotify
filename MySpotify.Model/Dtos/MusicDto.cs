using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySpotify.Models
{
    public class MusicDto
    {
        public Guid Id { get; set; }
        public string Imagem { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string? Album { get; set; }
        public string Title { get; set; }
        public string MusicURL { get; set; }
        public string RhythmId { get; set; }
        public string RhythmName { get; set; }
        public string SingerId { get; set; }
        public string SingerName { get; set; }
    }
}
