namespace SmartHome;

public partial class Bathroom : ContentView
{
    public Bathroom()
    {
        InitializeComponent();

        // Sets Default Appearence for Bathroom Page since the switch is default value is off here.
        linearGauge.IsEnabled = false;
        radialGauge.IsEnabled = false;
        pointer.Fill = Colors.DarkGray;
        pointerBackground.Fill = Colors.LightGray;
    }

    /// <summary>
    /// Used for changing appearence of the page according to the switch.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void heaterSwitch_StateChanged(object sender, Syncfusion.Maui.Buttons.SwitchStateChangedEventArgs e)
    {
        if ((bool)heaterSwitch.IsOn!)
        {
            // Sets the both gauges to enable state and sets expected colors for the linear gauge.
            linearGauge.IsEnabled = true;
            radialGauge.IsEnabled = true;
            pointer.Fill = Color.FromArgb("#77a0d3");
            pointerBackground.Fill = Color.FromArgb("#C9FCFD"); ;
        }
        else
        {
            // Sets the both gauges to disable state and sets gray color for the linear gauge.
            linearGauge.IsEnabled = false;
            radialGauge.IsEnabled = false;
            pointer.Fill = Colors.DarkGray;
            pointerBackground.Fill = Colors.LightGray;
        }
    }
}