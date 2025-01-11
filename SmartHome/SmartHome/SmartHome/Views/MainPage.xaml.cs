
using Syncfusion.Maui.Popup;
using Syncfusion.Maui.Toolkit.Chips;
using Syncfusion.Maui.Toolkit.SegmentedControl;

namespace SmartHome
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            chipGroup.SelectedItem = livingRoomChip;
        }

        private void SfChipGroup_SelectionChanged(object sender, Syncfusion.Maui.Toolkit.Chips.SelectionChangedEventArgs e)
        {
            SfChip? selectedItem = e.AddedItem as SfChip;
            if(selectedItem?.Text == "Cameras")
            {
                SamplesGrid.Children.Clear();
                SamplesGrid.Children.Add(new CamerasPage());

            }
            else if (selectedItem?.Text == "Living Room")
            {
                SamplesGrid.Children.Clear();
                SamplesGrid.Children.Add(new LivingRoom());
            }
            else if (selectedItem?.Text == "Kitchen")
            {
                SamplesGrid.Children.Clear();
                SamplesGrid.Children.Add(new Kitchen());
            }
            else if (selectedItem?.Text == "Bathroom")
            {
                SamplesGrid.Children.Clear();
                SamplesGrid.Children.Add(new Bathroom());
            }
            else if (selectedItem?.Text == "Bed Room")
            {
                SamplesGrid.Children.Clear();
                SamplesGrid.Children.Add(new Bedroom());
            }
        }

        private void SfEffectsView_AnimationCompleted(object sender, EventArgs e)
        {
            drawer.ToggleDrawer();
        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {
            popupNotification.Show();
            indicatorNotification.AutoHide = true;
        }

        private void SfButton_Clicked_1(object sender, EventArgs e)
        {
            DisplayAlert("Warning", "Feature will be Updated in Future", "OK");
        }
    }
}
