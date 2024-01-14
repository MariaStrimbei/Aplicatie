using PetHotelApplication.Models;
using Plugin.LocalNotification;

namespace PetHotelApplication
{
    public partial class ReservationPage : ContentPage
    {
        public ReservationPage()
        {
            InitializeComponent();
            BindingContext = new Reservation();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var reservation = (Reservation)BindingContext;

            // Verifică dacă utilizatorul a selectat o dată în DatePicker
            if (checkInDatePicker.Date != DateTime.MinValue)
                reservation.CheckInDate = checkInDatePicker.Date.Add(new TimeSpan(20, 21, 0));

            

            // Salvați rezervarea în baza de date
            await App.Database.SaveReservationAsync(reservation);

            // Programați notificarea cu o zi înainte
            await ScheduleNotificationOneDayBefore(reservation.CheckInDate);

            await Navigation.PopAsync();
        }
        async Task ScheduleNotificationOneDayBefore(DateTime checkInDate)
        {
            if (checkInDate != null)
            {
                var notificationId = 1; // Setați un ID unic pentru fiecare notificare

                var request = new NotificationRequest
                {
                    Title = "Reminder",
                    Description = "Your reservation check-in is tomorrow!",
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = checkInDate.AddDays(1) // Adaugă o zi la data de check-in
                    }
                };

                LocalNotificationCenter.Current.Show(request);
            }
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (Reservation)BindingContext;
            await App.Database.DeleteReservationAsync(slist);
            await Navigation.PopAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RoomPage((Reservation)this.BindingContext)
            {
                BindingContext = new Room()
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var res = (Reservation)BindingContext;

            listView.ItemsSource = await App.Database.GetListRoomsAsync(res.ID);
        }
    }
}
