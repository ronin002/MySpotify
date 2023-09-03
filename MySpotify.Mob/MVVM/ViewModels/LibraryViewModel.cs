using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MySpotify.Mob.MVVM.Models;

using MySpotify.Mob.Services;


namespace MySpotify.Mob.MVVM.ViewModels
{
    public class LibraryViewModel
    {
        //public ICommand OnSelectMusic => new Command<Music>(DeleteBLEItemControl);

        public ObservableCollection<Music> Musics { get; set; }
        private List<Music> musicList = new List<Music>();
        public LibraryViewModel()
        {
            CreateMusics();
            LoadMusic();


        }
        private void LoadMusic()
        {
            Musics = new ObservableCollection<Music>(musicList);
        }
        
        private Music selectedMusic;
        

        public Music SelectedMusic 
        { 
            get { return SelectedMusic; }

            set {

                if (selectedMusic != value)
                {
                    selectedMusic = value;
                    //OnPropertyChange("SelectedMusic");
                    if (SelectedMusic != null)
                    {
                        PerformNavigation(SelectedMusic.Id.ToString() + " - NAME:" + selectedMusic.Title);
                    }
                }
            } 
        }
        
        /*
        void OnCollectionMusicViewChanged(object sender, SelectionChangedEventArgs e)
        {
            string previous = (e.PreviousSelection.FirstOrDefault() as Music)?.Name;
            string current = (e.CurrentSelection.FirstOrDefault() as Music)?.Name;
            Console.WriteLine("MUSIC SELECTED: " + current);

        }
        */
        public ICommand OnCollectionMusicViewChanged => new Command<Object>((Object e) =>
        {
            Console.WriteLine($"selection made {SelectedMusic.Name}");
        });

        public ICommand PlayMusicItemCommand => new Command<Music>(PlayMusicItemControl);

        public void PlayMusicItemControl(Music o)
        {
            Console.WriteLine($"P {o}");
        }

        private async void PerformNavigation(string MusicId)
        {
            
            //Debug.WriteLine("MUSIC SELECTED: " + MusicId);
            //await Shell.Current.GoToAsync("PageMusic");
        }

 

        private async void CreateMusics() 
        {

            
            APIServices _APIService = new APIServices();
            musicList = await _APIService.GetMusicsALL();
            
            //Musics = new ObservableCollection<Music>(); //Musics = new ObservableCollection<Music>(listMusics);

            
            for (int i = 0; i < musicList.Count(); i++)
            {
                
                //Console.WriteLine(musicList[i].Title);
                //listMusics[i].Imagem = "img1.png";
                Music music = new Music();
                music = musicList[i];
                if (string.IsNullOrEmpty(music.Imagem))
                    music.Imagem = "clavesol.png";

                if (music.Title.Length > 30)
                    music.Title = music.Title.Substring(0, 30);

                Musics.Add(music);
                //Console.WriteLine(music.Title);
            }
            
            
            //Musics = new ObservableCollection<Music>(listMusics);
            /*
            Musics = new ObservableCollection<Music>
            {
                new Music
                {
                    Id = Guid.Parse("08dba1a4-11fd-43e4-8dda-b05eec442e7f"),
                    Imagem = "img1.png",
                    Name = "04_Fe_rias_Em_Salvador_1.mp3",
                    Duration = "00:04:00",
                    SingerId = "08dba19e-280d-4ab3-89c6-a7110e0f4b16",
                    SingerName = "Fernando e Sorocaba",
                    Album = "Salvador",
                    MusicURL = "ZGWXDur/9g8QfI/gYotKIxz6UcaN6jnJkTAALoxyzPo=",
                    Title = "04_Fe_rias_Em_Salvador_1.mp3"
                },
                new Music
                {
                    Id = Guid.Parse("08dba1a4-191a-423e-886c-f49d5acf2b5f"),
                    Imagem = "img2.png",
                    Name = "01 - Metallica - One.mp3",
                    Duration = "00:07:25",
                    SingerId = "08dba19e-280d-4ab3-89c6-a7110e0f4b16",
                    SingerName = "Metallica",
                    Album = "One (German Single)",
                    MusicURL = "8x5VwzcgORjyivwSWzNHcYfvMm3yz6goOAv8lYow20M=",
                    Title = "One"
                }

                                             
            };
            */

            

        }

    }
}
