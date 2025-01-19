using Microsoft.Maui.Controls.Shapes;
using Syncfusion.Maui.Buttons;
using Syncfusion.Maui.Gauges;
using System.Collections.ObjectModel;

namespace SmartHome.Behaviors
{

    public class BedroomBehavior : Behavior<ContentView>
    {
        /// <summary>
        /// Declaration of Necessary Variables.
        /// </summary>
        private FlexLayout? colorList;
        private SfSwitch? lightSwitch, fanSwitch;
        private RadialLineStyle? fanDialOuterRing, fanDialInnerRing;
        private SfRadialGauge? fanGauge;
        private Ellipse? fanDial;
        private Shadow? fanDialShadow;
        private ObservableCollection<Color> BorderColors = new ObservableCollection<Color>();
        private ObservableCollection<Color> BorderGrays = new ObservableCollection<Color>();

        /// <summary>
        /// Begins when the behavior attached to the view.
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(ContentView bindable)
        {
            base.OnAttachedTo(bindable);

            // Initialize Variables.
            this.colorList = bindable.Content.FindByName<FlexLayout>("colorList");
            this.lightSwitch = bindable.Content.FindByName<SfSwitch>("lightSwitch");
            this.fanSwitch = bindable.Content.FindByName<SfSwitch>("fanSwitch");
            this.fanGauge = bindable.Content.FindByName<SfRadialGauge>("fanGauge");
            this.fanDial = bindable.Content.FindByName<Ellipse>("fanDial");
            this.fanDialShadow = bindable.Content.FindByName<Shadow>("fanDialShadow");
            this.fanDialInnerRing = bindable.Content.FindByName<RadialLineStyle>("fanDialInnerRing");
            this.fanDialOuterRing = bindable.Content.FindByName<RadialLineStyle>("fanDialOuterRing");

            // Initialize Default Appearance for Smart Light Control.
            BorderColors = GetColor();
            BorderGrays = GetGray();
            BindableLayout.SetItemsSource(colorList, BorderColors);

            // Wire Required Event.
            this.fanSwitch.StateChanged += FanSwitch_StateChanged;
            this.lightSwitch.StateChanged += LightSwitch_StateChanged;

        }

        /// <summary>
        /// Used for changing appearance of the Light Control according to the switch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LightSwitch_StateChanged(object? sender, SwitchStateChangedEventArgs e)
        {
            if (lightSwitch != null && colorList != null)
            {
                if ((bool)lightSwitch.IsOn!)
                {
                    BindableLayout.SetItemsSource(colorList, BorderColors);
                    colorList.IsEnabled = true;
                }
                else
                {
                    BindableLayout.SetItemsSource(colorList, BorderGrays);
                    colorList.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// Used for changing appearance of the Fan Control according to the switch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FanSwitch_StateChanged(object? sender, SwitchStateChangedEventArgs e)
        {
            if (fanSwitch != null && fanGauge != null && fanDialInnerRing != null && fanDialOuterRing != null && fanDial != null && fanDialShadow != null)
            {
                if ((bool)fanSwitch.IsOn!)
                {
                    fanGauge.IsEnabled = true;
                    fanDialInnerRing.Fill = Color.FromArgb("#77a0d3");
                    fanDialOuterRing.Fill = Color.FromArgb("#77a0d3");
                    fanDial.BackgroundColor = Colors.LightSkyBlue;
                    fanDialShadow.Brush = Colors.LightSkyBlue;
                }
                else
                {
                    fanGauge.IsEnabled = false;
                    fanDialInnerRing.Fill = Colors.Gray;
                    fanDialOuterRing.Fill = Colors.Gray;
                    fanDial.BackgroundColor = Colors.LightGray;
                    fanDialShadow.Brush = Colors.Transparent;
                }
            }
        }


        /// <summary>
        /// Begins when the behavior gets detached from the view.
        /// Unwire Events and Nullify Variables
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnDetachingFrom(ContentView bindable)
        {
            base.OnDetachingFrom(bindable);

            if (this.lightSwitch != null)
            {
                this.lightSwitch.StateChanged -= LightSwitch_StateChanged;
                this.lightSwitch = null;
            }

            if (this.fanSwitch != null)
            {
                this.fanSwitch.StateChanged -= FanSwitch_StateChanged;
                this.fanSwitch = null;
            }

            if (this.colorList != null)
            {
                this.colorList = null;
            }

            if (this.fanDialInnerRing != null)
            {
                this.fanDialInnerRing = null;
            }

            if (this.fanDialOuterRing != null)
            {
                this.fanDialOuterRing = null;
            }

            if (this.fanGauge != null)
            {
                this.fanGauge = null;
            }

            if (this.fanDial != null)
            {
                this.fanDial = null;
            }

            if (this.fanDialShadow != null)
            {
                this.fanDialShadow = null;
            }

        }

        /// <summary>
        /// Generates 20 Different Colors as Item Source for Smart Light.
        /// </summary>
        /// <returns>ObservableCollection</returns>
        public ObservableCollection<Color> GetColor()
        {
            ObservableCollection<Color> Colors = new ObservableCollection<Color>();


            Random random = new Random();

            Colors.Add(Color.Parse("White"));
            for (int i = 1; i < 20; i++)
            {
                byte min = 1, max = 200;
                byte randomInRange1 = (byte)random.Next(min, max);
                byte randomInRange2 = (byte)random.Next(min, max);
                byte randomInRange3 = (byte)random.Next(min, max);
                Colors.Add(Color.FromRgb(randomInRange1, randomInRange2, randomInRange3));
            }
            return Colors;
        }

        /// <summary>
        /// Generates Gray Color Item Source for Smart Light.
        /// </summary>
        /// <returns>ObservableCollection</returns>
        public ObservableCollection<Color> GetGray()
        {
            ObservableCollection<Color> Colors = new ObservableCollection<Color>(
                Enumerable.Repeat(Color.Parse("Gray"), 20)
            );
            return Colors;
        }
    }
}
