using System;
using PetHotelApplication.Data;
using System.IO;

namespace PetHotelApplication;

public partial class App : Application
{
    static PetHotelDatabasedb database;
    public static PetHotelDatabasedb Database
    {
        get
        {
            if (database == null)
            {
                database = new
               PetHotelDatabasedb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "PetHotel1.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
