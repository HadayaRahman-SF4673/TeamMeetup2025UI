using Syncfusion.Maui.Toolkit.SegmentedControl;

namespace SmartHome.ViewModel
{
    internal class LivingRoomViewModel
    {
        public List<SfSegmentItem> MenuItems { get; set; }

        public LivingRoomViewModel()
        {
            MenuItems = new List<SfSegmentItem>()
            {
                new SfSegmentItem(){ImageSource = "homewhite.png"},
                new SfSegmentItem(){ImageSource = "screenwhite.png"},
                new SfSegmentItem(){ImageSource = "linkblack.png"},
                new SfSegmentItem(){ImageSource = "settingswhite.png"}
            };
        }
    }
}
