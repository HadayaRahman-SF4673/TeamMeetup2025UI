using System.Collections.ObjectModel;
using System.Reflection;

namespace SmartHome;

public partial class Bedroom : ContentView
{
    public ObservableCollection<Color> BorderColors = new ObservableCollection<Color>();
    public ObservableCollection<Color> BorderGrays = new ObservableCollection<Color>();
    public Bedroom()
	{
		InitializeComponent();
        BorderColors = GetColor();
        BorderGrays = GetGray();
        BindableLayout.SetItemsSource(list, BorderColors);


    }

	public ObservableCollection<Color> GetColor()
	{
        ObservableCollection<Color> Colors = new ObservableCollection<Color>();


        Random random = new Random();

        Colors.Add(Color.Parse("White"));
        for (int i = 1; i < 20;i++)
        {
            byte min = 1, max = 200;
            byte randomInRange1 = (byte)random.Next(min, max);
            byte randomInRange2 = (byte)random.Next(min, max);
            byte randomInRange3 = (byte)random.Next(min, max);
            Colors.Add(Color.FromRgb(randomInRange1, randomInRange2, randomInRange3));
        }
        return Colors;
    }

    public ObservableCollection<Color> GetGray()
    {
        ObservableCollection<Color> Colors = new ObservableCollection<Color>(
            Enumerable.Repeat(Color.Parse("Gray"), 20)
        );
        return Colors;
    }

    private void lightSwitch_StateChanged(object sender, Syncfusion.Maui.Buttons.SwitchStateChangedEventArgs e)
    {
        if ((bool)lightSwitch.IsOn!)
        {
            BindableLayout.SetItemsSource(list, BorderColors);
            list.IsEnabled = true;
        }
        else
        {
            BindableLayout.SetItemsSource(list, BorderGrays);
            list.IsEnabled = false;
        }
    }

    private void fanSwitch_StateChanged(object sender, Syncfusion.Maui.Buttons.SwitchStateChangedEventArgs e)
    {
        if ((bool)fanSwitch.IsOn!)
        {
            fanGauge.IsEnabled = true;
            fanControlBackground1.Fill = Color.FromArgb("#77a0d3");
            fanControlBackground2.Fill = Color.FromArgb("#77a0d3");
            fanDial.BackgroundColor = Colors.LightSkyBlue;
            fanDialBackground.Brush = Colors.LightSkyBlue;
        }
        else
        {
            fanGauge.IsEnabled = false;
            fanControlBackground1.Fill = Colors.Gray;
            fanControlBackground2.Fill = Colors.Gray;
            fanDial.BackgroundColor = Colors.LightGray;
            fanDialBackground.Brush = Colors.Transparent;
        }
    }
}