using SmartHome.ViewModel;
using Syncfusion.Maui.Gauges;
using Syncfusion.Maui.RadialMenu;
using Syncfusion.Maui.Toolkit.SegmentedControl;

namespace SmartHome.Behaviors
{

    public class LivingRoomBehavior : Behavior<ContentView>
    {
        /// <summary>
        /// Declaration of Necessary Variables.
        /// </summary>
        private SfRadialMenu? controlMenu;
        private SfSegmentedControl? menuSegment;
        private LivingRoomViewModel? livingRoomViewModel;
        private BarPointer? volumePointer1, volumePointer2;
        private Label? volumeLevel, volumeControlIcon;

        /// <summary>
        /// Begins when the behavior attached to the view.
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(ContentView bindable)
        {
            base.OnAttachedTo(bindable);

            // Initialize Variables
            this.menuSegment = bindable.Content.FindByName<SfSegmentedControl>("menuSegment");
            this.controlMenu = bindable.Content.FindByName<SfRadialMenu>("controlMenu");
            this.volumePointer1 = bindable.Content.FindByName<BarPointer>("volumePointer1");
            this.volumePointer2 = bindable.Content.FindByName<BarPointer>("volumePointer2");
            this.volumeLevel = bindable.Content.FindByName<Label>("volumeLevel");
            this.volumeControlIcon = bindable.Content.FindByName<Label>("volumeControlIcon");

            // Initialize Default Item Source
            this.livingRoomViewModel = new LivingRoomViewModel();
            this.menuSegment.ItemsSource = livingRoomViewModel.MenuItems;

            // Wire Required Events
            this.controlMenu.Closing += ControlMenu_Closing;
            this.menuSegment.SelectionChanged += MenuSegment_SelectionChanged;
            this.volumePointer1.ValueChanged += VolumePointer1_ValueChanged;
            this.volumePointer2.ValueChanged += VolumePointer2_ValueChanged;
        }

        /// <summary>
        /// Changes the Appearance First volume Control based on Selected Value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumePointer2_ValueChanged(object? sender, Syncfusion.Maui.Gauges.ValueChangedEventArgs e)
        {
            if (volumePointer2 != null && volumeControlIcon != null)
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

        /// <summary>
        /// Changes the Appearance Second volume Control based on Selected Value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumePointer1_ValueChanged(object? sender, Syncfusion.Maui.Gauges.ValueChangedEventArgs e)
        {
            if (volumePointer1 != null && volumeLevel != null)
            {
                if (volumePointer1.Value >= 95)
                {
                    volumePointer1.CornerStyle = CornerStyle.BothCurve;
                }
                else
                {
                    volumePointer1.CornerStyle = CornerStyle.StartCurve;
                }

                if (volumePointer1.Value != 0)
                {
                    volumeLevel.Text = ((int)volumePointer1.Value).ToString();
                }
                else
                {
                    volumeLevel.Text = "X";
                }
            }
        }

        /// <summary>
        /// Used to Change Icons According to Selected Index.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSegment_SelectionChanged(object? sender, Syncfusion.Maui.Toolkit.SegmentedControl.SelectionChangedEventArgs e)
        {
            if (menuSegment != null && livingRoomViewModel != null)
            {
                List<SfSegmentItem> dynamicItems = new List<SfSegmentItem>();
                for (int i = 0; i < ((List<SfSegmentItem>)this.menuSegment.ItemsSource).Count; i++)
                {
                    string? imageSourceString = ((List<SfSegmentItem>)this.menuSegment.ItemsSource)[i].ImageSource.ToString()?.Replace("File: ","");
                    if (imageSourceString != null)
                    {
                        if (i == this.menuSegment.SelectedIndex)
                        {
                           // Change image for the selected item.
                           dynamicItems.Add(new SfSegmentItem() { ImageSource = imageSourceString.Replace("white", "black") });
                        }
                        else
                        {
                            // Change back to unselected image
                            dynamicItems.Add(new SfSegmentItem() { ImageSource = imageSourceString.Replace("black", "white") });
                        }
                    }
                }
                this.menuSegment.ItemsSource = dynamicItems;
            }
        }

        /// <summary>
        /// Prevents Radial Menu from Closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlMenu_Closing(object? sender, ClosingEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// Begins when the behavior gets detached from the view.
        /// Unwire Events and Nullify Variables
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnDetachingFrom(ContentView bindable)
        {
            base.OnDetachingFrom(bindable);

            if (this.controlMenu != null)
            {
                this.controlMenu.Closing -= ControlMenu_Closing;
                this.controlMenu = null;
            }

            if (this.menuSegment != null)
            {
                this.menuSegment.SelectionChanged -= MenuSegment_SelectionChanged;
                this.menuSegment = null;
            }

            if (this.volumePointer1 != null)
            {
                this.volumePointer1.ValueChanged -= VolumePointer1_ValueChanged;
                this.volumePointer1 = null;
            }

            if (this.volumePointer2 != null)
            {
                this.volumePointer2.ValueChanged -= VolumePointer2_ValueChanged;
                this.volumePointer2 = null;
            }

            if (this.volumeLevel != null)
            {
                this.volumeLevel = null;
            }

            if (this.volumeControlIcon != null)
            {
                this.volumeControlIcon = null;
            }

        }
    }
}
