using Syncfusion.Maui.Buttons;
using Syncfusion.Maui.Gauges;

namespace SmartHome.Behaviors
{

    public class BathroomBehavior : Behavior<ContentView>
    {
        /// <summary>
        /// Declaration of Necessary Variables.
        /// </summary>
        private SfSwitch? heaterSwitch;
        private SfLinearGauge? linearGauge;
        private SfRadialGauge? radialGauge;
        private BarPointer? pointer;
        private LinearLineStyle? pointerBackground;

        /// <summary>
        /// Begins when the behavior attached to the view.
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(ContentView bindable)
        {
            base.OnAttachedTo(bindable);

            // Initialize Variables.
            this.heaterSwitch = bindable.Content.FindByName<SfSwitch>("heaterSwitch");
            this.linearGauge = bindable.Content.FindByName<SfLinearGauge>("linearGauge");
            this.radialGauge = bindable.Content.FindByName<SfRadialGauge>("radialGauge");
            this.pointerBackground = bindable.Content.FindByName<LinearLineStyle>("pointerBackground");
            this.pointer = bindable.Content.FindByName<BarPointer>("pointer");

            // Sets Default Appearance for Bathroom Page since the switch is default value is off here.
            this.linearGauge.IsEnabled = false;
            this.radialGauge.IsEnabled = false;
            this.pointer.Fill = Colors.DarkGray;
            this.pointerBackground.Fill = Colors.LightGray;

            // Wire Required Event.
            this.heaterSwitch.StateChanged += HeaterSwitch_StateChanged;

        }

        /// <summary>
        /// Used for changing appearance of the page according to the switch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaterSwitch_StateChanged(object? sender, SwitchStateChangedEventArgs e)
        {
            if (heaterSwitch != null && linearGauge != null && radialGauge != null && pointer != null && pointerBackground != null)
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

        /// <summary>
        /// Begins when the behavior gets detached from the view.
        /// Unwire Events and Nullify Variables
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnDetachingFrom(ContentView bindable)
        {
            base.OnDetachingFrom(bindable);
            
            if (this.heaterSwitch != null)
            {
                this.heaterSwitch.StateChanged -= HeaterSwitch_StateChanged;
                this.heaterSwitch = null;
            }

            if (this.linearGauge != null)
            {
                this.linearGauge = null;
            }
            
            if (this.radialGauge != null)
            {
                this.radialGauge = null;
            }
            
            if (this.pointer != null)
            {
                this.pointer = null;
            }
            
            if (this.pointerBackground != null)
            {
                this.pointerBackground = null;
            }
        }
    }
}
