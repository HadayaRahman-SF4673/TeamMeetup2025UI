using Microsoft.Maui.Controls;
using SmartHome.ViewModel;
using Syncfusion.Maui.Core;
using Syncfusion.Maui.RadialMenu;
using Syncfusion.Maui.Toolkit.Buttons;
using Syncfusion.Maui.Toolkit.SegmentedControl;
using System.Windows.Input;

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

            // Initialize Default Item Source
            this.livingRoomViewModel = new LivingRoomViewModel();
            this.menuSegment.ItemsSource = livingRoomViewModel.MenuItems;

            // Wire Required Events
            this.controlMenu.Closing += ControlMenu_Closing;
            this.menuSegment.SelectionChanged += MenuSegment_SelectionChanged;
        }

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

        }
    }
}
