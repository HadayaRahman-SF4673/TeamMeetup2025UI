using System.Drawing;

namespace SmartHome;

public partial class Kitchen : ContentView
{
	public Kitchen()
	{
		InitializeComponent();
        fridgeSwitch.IsOn = true;
	}

    private void SfLinearGauge_LabelCreated(object sender, Syncfusion.Maui.Gauges.LabelCreatedEventArgs e)
    {
        if (e.Text == "5")
            e.Text = "MAX";
    }

    private void primaryPointer2_ValueChanged(object sender, Syncfusion.Maui.Gauges.ValueChangedEventArgs e)
    {
        if(e.Value == 5)
        {
            secondaryPointer2.Fill = Colors.Red;
        }
        else
        {
            secondaryPointer2.Fill = Microsoft.Maui.Graphics.Color.FromArgb("#77a0d3");
        }
    }

    private void fridgeSwitch_StateChanged(object sender, Syncfusion.Maui.Buttons.SwitchStateChangedEventArgs e)
    {
        if((bool)fridgeSwitch.IsOn!)
        {
            fridgeGauge.IsEnabled = true;
            freezerGauge.IsEnabled = true;
            secondaryPointer2.Fill = Microsoft.Maui.Graphics.Color.FromArgb("#77a0d3");
            secondaryPointer1.Fill = Microsoft.Maui.Graphics.Color.FromArgb("#77a0d3");
            secondaryPointer1Background.Fill = Microsoft.Maui.Graphics.Color.FromArgb("#C9FCFD");
            secondaryPointer2Background.Fill = Microsoft.Maui.Graphics.Color.FromArgb("#C9FCFD");
        }
        else
        {
            fridgeGauge.IsEnabled = false;
            freezerGauge.IsEnabled = false;
            secondaryPointer2.Fill = Colors.DarkGray;
            secondaryPointer1.Fill = Colors.DarkGray;
            secondaryPointer1Background.Fill = Colors.LightGray;
            secondaryPointer2Background.Fill = Colors.LightGray;
        }
    }
}