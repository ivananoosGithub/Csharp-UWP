using Windows.UI.Xaml.Controls;

namespace TraVeL.Views
{
    public sealed partial class AddDestinationForm : ContentDialog
    {
        public string LocationName { get; private set; }
        public string Description { get; private set; }

        public string NumberOfPassenger { get; private set; }
        // Add more properties for other destination properties

        // Add a property to track the result
        public ContentDialogResult DialogResult { get; private set; }

        public AddDestinationForm()
        {
            this.InitializeComponent();
            this.PrimaryButtonClick += ContentDialog_PrimaryButtonClick;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Retrieve user's input
            
            LocationName = txtLocationName.Text;
            Description = txtDescription.Text;
            NumberOfPassenger = textNumberOfPassenger.Text;
            // Retrieve values from other input fields

            // Set the result to Primary
            DialogResult = ContentDialogResult.Primary;

            // Close the dialog
            this.Hide();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // User canceled; no action required
            LocationName = null;
            Description = null;
            NumberOfPassenger = null;
            // Set other properties to null or default values if needed

            // Close the dialog
            this.Hide();
        }
    }
}
