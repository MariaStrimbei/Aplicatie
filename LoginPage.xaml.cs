using System.Windows.Input;
using PetHotelApplication.Models;
namespace PetHotelApplication;

public partial class LoginPage : ContentPage
{
    private List<User> users = new List<User>();
    private Entry _usernameEntry;
    private Entry _passwordEntry;

    public ICommand LoginCommand { get; }

    public LoginPage()
	{
        InitializeComponent();

        LoginCommand = new Command(OnLoginButtonClicked);

        _usernameEntry = new Entry { Placeholder = "Enter username" };
        _passwordEntry = new Entry { Placeholder = "Enter password", IsPassword = true };
        var loginButton = new Button
        {
            Text = "Login",
            Command = LoginCommand
        };

        var registerButton = new Button
        {
            Text = "Register",
            Command = new Command(OnRegisterButtonClicked)
        };

        Content = new StackLayout
        {
            Children =
                {
                    new Label { Text = "User:" },
                    _usernameEntry,
                    new Label { Text = "Password:" },
                    _passwordEntry,
                    loginButton,
                    registerButton
                }
        };

        //utilizatori de test
        users.Add(new User { Username = "maria", Password = "parola1234" });
    }

    
    private void OnRegisterButtonClicked()
    {
        string username = _usernameEntry.Text;
        string password = _passwordEntry.Text;

        // utilizatorul exist? deja
        var existingUser = users.Find(u => u.Username == username);

        if (existingUser != null)
        {
            DisplayAlert("Register", "Username already exists. Choose a different username.", "OK");
        }
        else
        {
            // noul utilizator
            var newUser = new User { Username = username, Password = password };
            users.Add(newUser);
            DisplayAlert("Register", "Registration successful!", "OK");
        }
    }
    private void OnLoginButtonClicked()
    {
        string username = _usernameEntry.Text;
        string password = _passwordEntry.Text;

        // Verificare autentificare
        var user = users.Find(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            // Autentificarea a avut succes, navig?m la pagina principal?
            Navigation.PushAsync(new MainPage());
        }
        else
        {
            DisplayAlert("Login", "Invalid username or password.", "OK");
        }
    }

}
