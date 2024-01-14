using PetHotelApplication.Models;
namespace PetHotelApplication;

public partial class RoomPage : ContentPage
{
    Reservation res;
    public RoomPage(Reservation re)
    {
        InitializeComponent();
        res = re;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var room = (Room)BindingContext;
        await App.Database.SaveRoomAsync(room);
        listView.ItemsSource = await App.Database.GetRoomsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var room = (Room)BindingContext;
        await App.Database.DeleteRoomAsync(room);
        listView.ItemsSource = await App.Database.GetRoomsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRoomsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Room r;
        if (listView.SelectedItem != null)
        {
            r = listView.SelectedItem as Room;
            var lr = new ListRoom()
            {
                ReservationID = res.ID,
                RoomID = r.ID
            };
            await App.Database.SaveListRoomAsync(lr);
            r.ListRooms = new List<ListRoom> { lr };
            await Navigation.PopAsync();
        }
    }
    async void OnDeleteAllRoomsClicked(object sender, EventArgs e)
    {
        await App.Database.DeleteAllRoomsAsync();
        listView.ItemsSource = await App.Database.GetRoomsAsync();
    }

}