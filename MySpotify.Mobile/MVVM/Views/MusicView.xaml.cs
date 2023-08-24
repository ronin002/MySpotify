namespace MySpotify.Mobile.MVVM.Views;
using MySpotify.Mob.MVVM.ViewModels;
public partial class MusicView : ContentPage
{
	public MusicView()
	{
		InitializeComponent();
		BindingContext = new MusicViewModel();
	}
}