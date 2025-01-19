namespace SmartHome;

public partial class CameraViewCommon : ContentPage
{
	public CameraViewCommon(string headerText)
	{
		InitializeComponent();

		// Sets Initial Camera Header Text.
		cameraName.Text = headerText;
	}
}