using Syncfusion.Maui.Buttons;
using Syncfusion.Maui.Gauges;

namespace SmartHome.Behaviors
{

    public class KitchenBehavior : Behavior<ContentView>
    {
        /// <summary>
        /// Declaration of Necessary Variables.
        /// </summary>
        private SfSwitch? fridgeSwitch;
        private SfLinearGauge? freezerGauge;
        private SfRadialGauge? fridgeGauge;
        private LinearShapePointer? primaryPointerFreezer;
        private BarPointer? secondaryPointerFreezer;
        private RangePointer? secondaryPointerFridge;
        private LinearLineStyle? freezerGaugeLineBackground;
        private RadialLineStyle? fridgeGaugeLineBackground;


        /// <summary>
        /// Begins when the behavior attached to the view.
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(ContentView bindable)
        {
            base.OnAttachedTo(bindable);

            // Initialize Variables.
            this.fridgeSwitch = bindable.Content.FindByName<SfSwitch>("fridgeSwitch");
            this.freezerGauge = bindable.Content.FindByName<SfLinearGauge>("freezerGauge");
            this.fridgeGauge = bindable.Content.FindByName<SfRadialGauge>("fridgeGauge");
            this.freezerGaugeLineBackground = bindable.Content.FindByName<LinearLineStyle>("freezerGaugeLineBackground");
            this.fridgeGaugeLineBackground = bindable.Content.FindByName<RadialLineStyle>("fridgeGaugeLineBackground");
            this.primaryPointerFreezer = bindable.Content.FindByName<LinearShapePointer>("primaryPointerFreezer");
            this.secondaryPointerFreezer = bindable.Content.FindByName<BarPointer>("secondaryPointerFreezer");
            this.secondaryPointerFridge = bindable.Content.FindByName<RangePointer>("secondaryPointerFridge");

            // Wire Required Event.
            this.fridgeSwitch.StateChanged += FridgeSwitch_StateChanged;
            this.freezerGauge.LabelCreated += FreezerGauge_LabelCreated;
            this.primaryPointerFreezer.ValueChanged += PrimaryPointerFreezer_ValueChanged;

        }

        /// <summary>
        /// Changes Freezer Secondary Pointer's Fill Based on Primary Pointer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimaryPointerFreezer_ValueChanged(object? sender, Syncfusion.Maui.Gauges.ValueChangedEventArgs e)
        {
            if (secondaryPointerFreezer != null)
            {
                if (e.Value == 5)
                {
                    secondaryPointerFreezer.Fill = Colors.Red;
                }
                else
                {
                    secondaryPointerFreezer.Fill = Color.FromArgb("#77a0d3");
                }
            }
        }

        /// <summary>
        /// Used to Change Maximum Value into Max String.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreezerGauge_LabelCreated(object? sender, LabelCreatedEventArgs e)
        {
            if (e.Text == "5")
                e.Text = "MAX";
        }

        /// <summary>
        /// Changes Appearance of the Smart Fridge Control Based on fridge Switch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FridgeSwitch_StateChanged(object? sender, SwitchStateChangedEventArgs e)
        {
            if (fridgeSwitch != null && fridgeGauge != null && freezerGauge != null && secondaryPointerFreezer != null && secondaryPointerFridge != null && freezerGaugeLineBackground != null && fridgeGaugeLineBackground != null)
            {
                if ((bool)fridgeSwitch.IsOn!)
                {
                    fridgeGauge.IsEnabled = true;
                    freezerGauge.IsEnabled = true;
                    secondaryPointerFreezer.Fill = Color.FromArgb("#77a0d3");
                    secondaryPointerFridge.Fill = Color.FromArgb("#77a0d3");
                    fridgeGaugeLineBackground.Fill = Color.FromArgb("#C9FCFD");
                    freezerGaugeLineBackground.Fill = Color.FromArgb("#C9FCFD");
                }
                else
                {
                    fridgeGauge.IsEnabled = false;
                    freezerGauge.IsEnabled = false;
                    secondaryPointerFreezer.Fill = Colors.DarkGray;
                    secondaryPointerFridge.Fill = Colors.DarkGray;
                    fridgeGaugeLineBackground.Fill = Colors.LightGray;
                    freezerGaugeLineBackground.Fill = Colors.LightGray;
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

            if (this.fridgeSwitch != null)
            {
                this.fridgeSwitch.StateChanged -= FridgeSwitch_StateChanged;
                this.fridgeSwitch = null;
            }

            if (this.freezerGauge != null)
            {
                this.freezerGauge.LabelCreated -= FreezerGauge_LabelCreated;
                this.freezerGauge = null;
            }

            if (this.primaryPointerFreezer != null)
            {
                this.primaryPointerFreezer.ValueChanged -= PrimaryPointerFreezer_ValueChanged;
                this.primaryPointerFreezer = null;
            }

            if (this.fridgeGauge != null)
            {
                this.fridgeGauge = null;
            }
            
            if (this.fridgeGaugeLineBackground != null)
            {
                this.fridgeGaugeLineBackground = null;
            }
            
            if (this.freezerGaugeLineBackground != null)
            {
                this.freezerGaugeLineBackground = null;
            }

            if (this.secondaryPointerFreezer != null)
            {
                this.secondaryPointerFreezer = null;
            }

            if (this.secondaryPointerFridge != null)
            {
                this.secondaryPointerFridge = null;
            }
        }
    }
}
