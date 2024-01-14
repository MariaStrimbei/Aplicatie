
using Microsoft.Maui.Controls;

namespace PetHotelApplication
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnExploreRoomsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RoomEntryPage());
        }
        private void OnReservationClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ReservationEntryPage());
        }

        private void OnContactClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ContactPage());
        }
        private void OnLogoutClicked(object sender, EventArgs e)
        {
          

            Navigation.PushAsync(new LoginPage());
        }
    }
}
