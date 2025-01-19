using Syncfusion.Maui.Popup;
using Syncfusion.Maui.Toolkit.Buttons;
using Syncfusion.Maui.Toolkit.Chips;
using Syncfusion.Maui.Toolkit.EffectsView;
using Syncfusion.Maui.Toolkit.NavigationDrawer;

namespace SmartHome.Behaviors
{

    public class MainPageBehavior : Behavior<ContentPage>
    {
        /// <summary>
        /// Declaration of Necessary Variables.
        /// </summary>
        private Grid? samplesGrid;
        private SfChip? livingRoomChip;
        private SfChipGroup? chipGroup;
        private ContentPage? mainPage;
        private SfNavigationDrawer? drawer;
        private SfEffectsView? profilePicture;
        private SfButton? optionButton, notificationButton;
        private SfPopup? popupNotification;
        private Syncfusion.Maui.Core.SfBadgeView? indicatorNotification;


        /// <summary>
        /// Begins when the behavior attached to the view.
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            // Initialize Variables.
            this.mainPage = bindable;
            this.chipGroup = bindable.Content.FindByName<SfChipGroup>("chipGroup");
            this.livingRoomChip = bindable.Content.FindByName<SfChip>("livingRoomChip");
            this.samplesGrid = bindable.Content.FindByName<Grid>("SamplesGrid");
            this.drawer = bindable.Content.FindByName<SfNavigationDrawer>("drawer");
            this.profilePicture = bindable.Content.FindByName<SfEffectsView>("profilePicture");
            this.notificationButton = bindable.Content.FindByName<SfButton>("notificationButton");
            this.optionButton = bindable.Content.FindByName<SfButton>("optionButton");
            this.popupNotification = bindable.Content.FindByName<SfPopup>("popupNotification");
            this.indicatorNotification = bindable.Content.FindByName<Syncfusion.Maui.Core.SfBadgeView>("indicatorNotification");

            // Wire Required Event.
            this.chipGroup.SelectionChanged += ChipGroup_SelectionChanged;
            this.profilePicture.AnimationCompleted += ProfilePicture_AnimationCompleted;
            this.optionButton.Clicked += OptionButton_Clicked;
            this.notificationButton.Clicked += NotificationButton_Clicked;

            // Sets Default for the value for the chip group.
            this.chipGroup.SelectedItem = this.livingRoomChip;

        }

        /// <summary>
        /// Prompts Warning Display Alert When Clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionButton_Clicked(object? sender, EventArgs e)
        {
            if (mainPage != null)
            {
                mainPage.DisplayAlert("⚠️ Warning", "Feature will be Updated in Future", "OK");
            }
        }

        /// <summary>
        /// Displays Notification Popup When Displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotificationButton_Clicked(object? sender, EventArgs e)
        {
           if(popupNotification != null && indicatorNotification != null && indicatorNotification.BadgeSettings != null)
            {
                popupNotification.Show();
                indicatorNotification.BadgeSettings.AutoHide = true;
            }
            
        }

        /// <summary>
        /// Opens Navigation Drawer when clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProfilePicture_AnimationCompleted(object? sender, EventArgs e)
        {
            if (drawer != null)
            {
                drawer.ToggleDrawer();
            }
        }

        /// <summary>
        /// Changes Content of the page according to the selected chip.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChipGroup_SelectionChanged(object? sender, Syncfusion.Maui.Toolkit.Chips.SelectionChangedEventArgs e)
        {
            SfChip? selectedItem = e.AddedItem as SfChip;
            if (samplesGrid != null)
            {
                if (selectedItem?.Text == "Cameras")
                {
                    samplesGrid.Children.Clear();
                    samplesGrid.Children.Add(new CamerasPage());

                }
                else if (selectedItem?.Text == "Living Room")
                {
                    samplesGrid.Children.Clear();
                    samplesGrid.Children.Add(new LivingRoom());
                }
                else if (selectedItem?.Text == "Kitchen")
                {
                    samplesGrid.Children.Clear();
                    samplesGrid.Children.Add(new Kitchen());
                }
                else if (selectedItem?.Text == "Bathroom")
                {
                    samplesGrid.Children.Clear();
                    samplesGrid.Children.Add(new Bathroom());
                }
                else if (selectedItem?.Text == "Bed Room")
                {
                    samplesGrid.Children.Clear();
                    samplesGrid.Children.Add(new Bedroom());
                }
            }
        }

        /// <summary>
        /// Begins when the behavior gets detached from the view.
        /// Unwire Events and Nullify Variables
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            
            if (this.chipGroup != null)
            {
                this.chipGroup.SelectionChanged -= ChipGroup_SelectionChanged;
                this.chipGroup = null;
            }

            if (this.profilePicture != null)
            {
                this.profilePicture.AnimationCompleted -= ProfilePicture_AnimationCompleted;
                this.profilePicture = null;
            }

            if (this.optionButton != null)
            {
                this.optionButton.Clicked -= OptionButton_Clicked;
                this.optionButton = null;
            }

            if (this.notificationButton != null)
            {
                this.notificationButton.Clicked -= NotificationButton_Clicked;
                this.notificationButton = null;
            }

            if (this.profilePicture != null)
            {
                this.profilePicture.AnimationCompleted -= ProfilePicture_AnimationCompleted;
                this.profilePicture = null;
            }

            if (this.samplesGrid != null)
            {
                this.samplesGrid = null;
            }

            if (this.livingRoomChip != null)
            {
                this.livingRoomChip = null;
            }

            if (this.drawer != null)
            {
                this.drawer = null;
            }

            if (this.popupNotification != null)
            {
                this.popupNotification = null;
            }

            if (this.indicatorNotification != null)
            {
                this.indicatorNotification = null;
            }
    }
    }
}
