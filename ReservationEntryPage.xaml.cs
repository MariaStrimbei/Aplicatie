using PetHotelApplication.Models;
namespace PetHotelApplication;

public partial class ReservationEntryPage : ContentPage
{
	public ReservationEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetReservationsAsync();
    }

    async void OnReservationAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReservationPage
        {
            BindingContext = new Reservation()
        });
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ReservationPage
            {
                BindingContext = e.SelectedItem as Reservation
            });
        }
    }

}