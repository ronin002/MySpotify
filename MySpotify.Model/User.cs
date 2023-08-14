using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MySpotify.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        //[ForeignKey("Company")]
        //public Guid CompanyId { get; set; }
        //public virtual Company Company { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }


        [JsonIgnore]
        public string Password { get; set; }
        public List<Playlist> Playlists { get; set; }


    }
}
