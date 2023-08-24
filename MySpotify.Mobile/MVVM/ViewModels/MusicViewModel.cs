using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpotify.Mob.MVVM.Models;

namespace MySpotify.Mob.MVVM.ViewModels
{
    public class MusicViewModel
    {
        public ObservableCollection<Music> Musics { get; set; }

        public MusicViewModel()
        {
            CreateMusics();
        }

        private void CreateMusics() 
        {

            Musics = new ObservableCollection<Music>
            {
                new Music
                {
                    Id = Guid.Parse("08dba1a4-11fd-43e4-8dda-b05eec442e7f"),
                    Name = "04_Fe_rias_Em_Salvador_1.mp3",
                    Duration = "00:04:00",
                    SingerId = Guid.Parse("08dba19e-280d-4ab3-89c6-a7110e0f4b16"),
                    Album = "Salvador",
                    MusicURL = "ZGWXDur/9g8QfI/gYotKIxz6UcaN6jnJkTAALoxyzPo=",
                    Title = "04_Fe_rias_Em_Salvador_1.mp3"
                },
                new Music
                {
                    Id = Guid.Parse("08dba1a4-191a-423e-886c-f49d5acf2b5f"),
                    Name = "01 - Metallica - One.mp3",
                    Duration = "00:07:25",
                    SingerId = Guid.Parse("08dba19e-280d-4ab3-89c6-a7110e0f4b16"),
                    Album = "One (German Single)",
                    MusicURL = "8x5VwzcgORjyivwSWzNHcYfvMm3yz6goOAv8lYow20M=",
                    Title = "One"
                }

                                             
            };

        }

    }
}
