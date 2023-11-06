using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using TraVeL.Core.Helpers;
using TraVeL.Core.Models;
using TraVeL.Core.Services;
using TraVeL.Helpers;
using TraVeL.Services;

namespace TraVeL.ViewModels
{
    public class ContentGridDetailViewModel : ObservableObject
    {
        private DestinationModel _item;

        public DestinationModel Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        private ICommand _goBackCommand;

        public ICommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack));

        public ContentGridDetailViewModel()
        {
        }

        public async Task InitializeAsync(byte id)
        {

            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(Core.Helpers.Constants.connectionString)
            .Options;

            // Create an instance of AppDbContext with your DbContext options
            var dbContext = new AppDbContext(options);

            // Create an instance of SampleDataService and pass the AppDbContext
            var sampleDataService = new SampleDataService(dbContext);

            var data = await sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.Id == id);
        }

        private void OnGoBack()
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
