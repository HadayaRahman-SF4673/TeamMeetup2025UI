namespace SmartHome;

public partial class CamerasPage : ContentView
{
	public CamerasPage()
	{
		InitializeComponent();
	}

    private void ImageButton_Pressed(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new CameraViewCommon("Entrance Camera"));
    }

    private void ImageButton_Pressed_1(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new CameraViewCommon("Hall Camera"));
    }

    private void ImageButton_Pressed_2(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new CameraViewCommon("Corridor Camera"));
    }

    private void ImageButton_Pressed_3(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new CameraViewCommon("Backdoor Camera"));
    }
}