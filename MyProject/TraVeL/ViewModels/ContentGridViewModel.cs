using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Uwp.UI.Animations;
using Microsoft.VisualBasic;
using TraVeL.Core.Helpers;
using TraVeL.Core.Models;
using TraVeL.Core.Services;
using TraVeL.Services;
using TraVeL.Views;

namespace TraVeL.ViewModels
{
    public class ContentGridViewModel : ObservableObject
    {
        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<DestinationModel>(OnItemClick));

        public ObservableCollection<DestinationModel> Source { get; } = new ObservableCollection<DestinationModel>();

        public ContentGridViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(Core.Helpers.Constants.connectionString)
            .Options;

            // Create an instance of AppDbContext with your DbContext options
            var dbContext = new AppDbContext(options);

            // Create an instance of SampleDataService and pass the AppDbContext
            var sampleDataService = new SampleDataService(dbContext);

            var data = await sampleDataService.GetContentGridDataAsync();
            foreach (var item in data)
            {
                Source.Add(item);
            }
        }


        private void OnItemClick(DestinationModel clickedItem)
        {
            if (clickedItem != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(clickedItem);
                NavigationService.Navigate<ContentGridDetailPage>(clickedItem.Id);
            }
        }
    }
}
