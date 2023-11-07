using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TraVeL.Core.Helpers;
using TraVeL.Core.Models;
using TraVeL.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;

namespace TraVeL.Views
{
    public sealed partial class ContentGridPage : Page
    {
        private Popup addDestinationPopup;

        public ContentGridViewModel ViewModel { get; } = new ContentGridViewModel();

        //public ContentGridPage()
        //{
        //    InitializeComponent();
        //}

        private AppDbContext _dbContext; // Declare the context as a private field

        public ContentGridPage()
        {
            InitializeComponent();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(Core.Helpers.Constants.connectionString)
                .Options;

            _dbContext = new AppDbContext(options); // Create a new instance of AppDbContext with the options
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }

        private async void AddDestinationButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddDestinationForm();
            var result = await dialog.ShowAsync();

            if (dialog.DialogResult == ContentDialogResult.Primary)
            {
                // User clicked "Add"
                var newLocationName = dialog.LocationName;
                var newDescription = dialog.Description;
                var newNumberOfPassenger = dialog.NumberOfPassenger;

                // Create a new DestinationModel object
                var newDestination = new DestinationModel
                {
                    location_name = newLocationName,
                    address = newDescription,
                    number_of_passenger = newNumberOfPassenger
                    // Set other properties of DestinationModel if needed
                };

                // Add the new destination to the DbSet in your DbContext
                _dbContext.Destination.Add(newDestination);

                try
                {
                    // Save changes to the database
                    await _dbContext.SaveChangesAsync();

                    // Optionally, reload your data source if you want the new destination to appear in the GridView
                    await ViewModel.RefreshDataAsync();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during database interaction
                    // You can show an error message or log the exception for debugging
                }
            }
        }

    }
}
