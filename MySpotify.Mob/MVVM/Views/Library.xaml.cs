using MySpotify.Mob.MVVM.Models;
using MySpotify.Mob.MVVM.ViewModels;
using System.Windows.Input;

namespace MySpotify.Mob.MVVM.Views;

public partial class Library : ContentPage
{

    
    public Library()
	{

		InitializeComponent();

		BindingContext = new LibraryViewModel();


        void OnCollectionMusicViewChanged(object sender, SelectionChangedEventArgs e)
        {
            string previous = (e.PreviousSelection.FirstOrDefault() as Music)?.Name;
            string current = (e.CurrentSelection.FirstOrDefault() as Music)?.Name;
            Console.WriteLine("MUSIC SELECTED: " + current);

        }
    }
}