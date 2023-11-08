using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraVeL.Core.Helpers;
using TraVeL.Core.Models;
using TraVeL.Services;
using TraVeL.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
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

        private async void SearchBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            // Get the text entered in the search box
            string query = SearchBox.Text;

            if (!string.IsNullOrWhiteSpace(query))
            {
                // Check if the search query is not empty
                // You can perform your search operation here and populate the SearchResults ListView
                var searchResults = await SearchDestinationsAsync(query);

                if (searchResults.Count > 0)
                {
                    // If there are search results, populate the SearchResults ListView
                    SearchResults.ItemsSource = searchResults;
                    SearchResults.Visibility = Visibility.Visible;
                }
                else
                {
                    // If there are no results, hide the SearchResults ListView
                    SearchResults.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                // If the search query is empty, hide the SearchResults ListView
                SearchResults.Visibility = Visibility.Collapsed;
            }
        }

        private void SearchResults_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is DestinationModel clickedItem)
            {
                // Handle the item click from search results
                // You can navigate to the detail page or perform other actions
                // For example, you can navigate to the details page using the clickedItem.Id
                // NavigationService.Navigate<DetailsPage>(clickedItem.Id);
                NavigationService.Navigate<ContentGridDetailPage>(clickedItem.Id);
            }
        }


        private async Task<List<DestinationModel>> SearchDestinationsAsync(string query)
        {
            // Initialize a list to store the search results
            List<DestinationModel> searchResults = new List<DestinationModel>();

            // Assuming you have an instance of your DbContext called "_dbContext"
            // Use the _dbContext to query your database and filter destinations based on the query
            // You can adjust the search criteria based on your database structure
            // Here, I'm assuming you want to search for destinations by their location_name

            if (!string.IsNullOrWhiteSpace(query))
            {
                searchResults = await _dbContext.Destination
                    .Where(dest => dest.location_name.Contains(query))
                    .ToListAsync();
            }

            // Return the search results
            return searchResults;
        }



    }
}
