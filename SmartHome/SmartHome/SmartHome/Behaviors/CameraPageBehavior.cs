using System.Windows.Input;

namespace SmartHome.Behaviors
{
    public class CameraPageBehavior
    {
        /// <summary>
        /// Commannd for Cameras Page Image Buttons Pressed.
        /// </summary>
        public ICommand ImageButtonPressed { get; set; }

        /// <summary>
        /// Constructor for Cameras Page Behavior which initializes it's Command
        /// </summary>
        public CameraPageBehavior()
        {
            ImageButtonPressed = new Command<string>(OnImageButtonPressed);
        }

        /// <summary>
        /// Method Which gets called when image button is preesed on Cameras page. 
        /// </summary>
        /// <param name="cameraName"></param>
        private void OnImageButtonPressed(string cameraName)
        {
            if (!string.IsNullOrEmpty(cameraName))
            {
                if (Application.Current != null)
                {
                    Application.Current.Windows[0].Navigation.PushModalAsync(new CameraViewCommon(cameraName));
                }
            }
        }
    }
}
