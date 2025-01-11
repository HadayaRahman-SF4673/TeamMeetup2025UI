using Syncfusion.Maui.RadialMenu;
using System.Drawing;

namespace SmartHome;

public partial class LivingRoom : ContentView
{
	public LivingRoom()
	{
		InitializeComponent();
	}

    private void SfRadialMenu_Closing(object sender, Syncfusion.Maui.RadialMenu.ClosingEventArgs e)
    {
        e.Cancel = true;
    }

    private void secondaryPointer2_ValueChanged(object sender, Syncfusion.Maui.Gauges.ValueChangedEventArgs e)
    {
        if(volumePointer.Value >= 95)
        {
            volumePointer.CornerStyle = Syncfusion.Maui.Gauges.CornerStyle.BothCurve;
        }
        else
        {
            volumePointer.CornerStyle = Syncfusion.Maui.Gauges.CornerStyle.StartCurve;
        }

        if (volumePointer.Value != 0)
        {
            volumeLevel.Text = ((int)volumePointer.Value).ToString();
        }
        else
        {
            volumeLevel.Text = "X";
        }
    }

    private void BarPointer_ValueChanged(object sender, Syncfusion.Maui.Gauges.ValueChangedEventArgs e)
    {
        if (volumePointer2.Value >= 90)
        {
            volumePointer2.CornerStyle = Syncfusion.Maui.Gauges.CornerStyle.BothCurve;
        }
        else
        {
            volumePointer2.CornerStyle = Syncfusion.Maui.Gauges.CornerStyle.StartCurve;
        }
        if (volumePointer2.Value == 0)
        {
            volumeControlIcon.Text = "\uE992";
        }
        else if (volumePointer2.Value <= 30)
        {
            volumeControlIcon.Text = "\uE993";
        }
        else if (volumePointer2.Value <= 60)
        {
            volumeControlIcon.Text = "\uE994";
        }
        else if (volumePointer2.Value <= 80)
        {
            volumeControlIcon.Text = "\uE995";
        }
    }
}