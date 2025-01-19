namespace SmartHome.ViewModel
{
    public class MainPageViewModel
    {
        /// <summary>
        /// Stores Profile Options for Navigation Drawer.
        /// </summary>
        public List<string> ProfileOptions { get; set; }

        /// <summary>
        /// Stores Notification Details for the Popup.
        /// </summary>
        public List<string> NotificationContents { get; set; }

        /// <summary>
        /// Constructor to Initialize Default Values for the Both Lists.
        /// </summary>
        public MainPageViewModel()
        {
            ProfileOptions = new List<string>()
            {
               "Profile",
                "Settings",
                "Help",
                "Contact Us"
            };
            NotificationContents = new List<string>()
            {

                "Motion Detected on Entrance Camera",
                "Bed Room Light is Turning On",
                "Bed Room Fan is Turning On",
                "Fridge is Turning On",
                "Smart Heater is Turning Off",
                "Bed Room Light is Turning Off",
                "Bed Room Fan is Turning Off",
                "Fridge is Turning Off"
            };
        }
    }
}
