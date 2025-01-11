namespace SmartHome;

public partial class CameraViewCommon : ContentPage
{
	public CameraViewCommon(string headerText)
	{
		InitializeComponent();
		cameraName.Text = headerText;
	}

    private void SfButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void SfButton_Clicked_1(object sender, EventArgs e)
    {
        if(cameraName.Text == "Entrance Camera")
        {
            cameraName.Text = "Backdoor Camera";
        }
        else if (cameraName.Text == "Hall Camera")
        {
            cameraName.Text = "Entrance Camera";
        }
        else if (cameraName.Text == "Corridor Camera")
        {
            cameraName.Text = "Hall Camera";
        }
        else
        {
            cameraName.Text = "Corridor Camera";
        }
    }

    private void SfButton_Clicked_2(object sender, EventArgs e)
    {
        if (cameraName.Text == "Entrance Camera")
        {
            cameraName.Text = "Hall Camera";
        }
        else if (cameraName.Text == "Hall Camera")
        {
            cameraName.Text = "Corridor Camera";
        }
        else if (cameraName.Text == "Corridor Camera")
        {
            cameraName.Text = "Backdoor Camera";
        }
        else
        {
            cameraName.Text = "Entrance Camera";
        }
    }

    private void SfRadialMenu_Closing(object sender, Syncfusion.Maui.RadialMenu.ClosingEventArgs e)
    {
        e.Cancel = true;
    }

    private void SfButton_Clicked_3(object sender, EventArgs e)
    {
        indicatorButton.AutoHide = true;
        DisplayAlert("Warning", "Feature will be Updated in Future", "OK");
    }
}