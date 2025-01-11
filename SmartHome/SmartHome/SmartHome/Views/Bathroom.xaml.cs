using System.Collections.Generic;

namespace SmartHome;

public partial class Bathroom : ContentView
{
    public Bathroom()
    {
        InitializeComponent();
        if ((bool)heaterSwitch.IsOn!)
        {
            linearGauge.IsEnabled = true;
            radialGauge.IsEnabled = true;
            pointer.Fill = Color.FromArgb("#77a0d3");
            pointerBackground.Fill = Color.FromArgb("#C9FCFD"); ;
        }
        else
        {
            linearGauge.IsEnabled = false;
            radialGauge.IsEnabled = false;
            pointer.Fill = Colors.DarkGray;
            pointerBackground.Fill = Colors.LightGray;
        }
    }

    private void heaterSwitch_StateChanged(object sender, Syncfusion.Maui.Buttons.SwitchStateChangedEventArgs e)
    {
        if ((bool)heaterSwitch.IsOn!)
        {
            linearGauge.IsEnabled = true;
            radialGauge.IsEnabled = true;
            pointer.Fill = Color.FromArgb("#77a0d3");
            pointerBackground.Fill = Color.FromArgb("#C9FCFD"); ;
        }
        else
        {
            linearGauge.IsEnabled = false;
            radialGauge.IsEnabled = false;
            pointer.Fill = Colors.DarkGray;
            pointerBackground.Fill = Colors.LightGray;
        }
    }
}