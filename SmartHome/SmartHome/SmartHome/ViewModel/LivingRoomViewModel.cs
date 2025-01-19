using Syncfusion.Maui.Toolkit.SegmentedControl;

namespace SmartHome.ViewModel
{
    public class LivingRoomViewModel
    {
        /// <summary>
        /// Stores Menu Item Icons.
        /// </summary>
        public List<SfSegmentItem> MenuItems { get; set; }

        /// <summary>
        /// Constructor to Initialize Default Values for the Icons.
        /// </summary>
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
