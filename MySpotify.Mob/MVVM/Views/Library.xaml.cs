using MySpotify.Mob.MVVM.ViewModels;

namespace MySpotify.Mob.MVVM.Views;

public partial class Library : ContentPage
{
	public Library()
	{
		InitializeComponent();

		BindingContext = new LibraryViewModel();
	}
}