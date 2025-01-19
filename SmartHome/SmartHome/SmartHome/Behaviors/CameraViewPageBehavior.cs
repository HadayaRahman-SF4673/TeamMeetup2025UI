using Syncfusion.Maui.Core;
using Syncfusion.Maui.RadialMenu;
using Syncfusion.Maui.Toolkit.Buttons;

namespace SmartHome.Behaviors
{

    public class CameraViewsPageBehavior : Behavior<ContentPage>
    {
        /// <summary>
        /// Declaration of Necessary Variables.
        /// </summary>
        private SfButton? leftButton, rightButton, backButton, notificationButton;
        private SfBadgeView? notificationIndicator;
        private Label? cameraName;
        private SfRadialMenu? controlMenu;
        private ContentPage? cameraViewPage;

        /// <summary>
        /// Begins when the behavior attached to the view.
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            // Initialize Variables
            this.cameraViewPage = bindable;
            this.leftButton = bindable.Content.FindByName<SfButton>("leftButton");
            this.rightButton = bindable.Content.FindByName<SfButton>("rightButton");
            this.backButton = bindable.Content.FindByName<SfButton>("backButton");
            this.notificationButton = bindable.Content.FindByName<SfButton>("notificationButton");
            this.notificationIndicator = bindable.Content.FindByName<SfBadgeView>("notificationIndicator");
            this.cameraName = bindable.Content.FindByName<Label>("cameraName");
            this.controlMenu = bindable.Content.FindByName<SfRadialMenu>("controlMenu");

            // Wire Required Events
            this.backButton.Clicked += BackButton_Clicked;
            this.leftButton.Clicked += LeftButton_Clicked;
            this.rightButton.Clicked += RightButton_Clicked;
            this.controlMenu.Closing += ControlMenu_Closing;
            this.notificationButton.Clicked += NotificationButton_Clicked;
        }

        /// <summary>
        /// Prompts Warning Display Alert When Clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotificationButton_Clicked(object? sender, EventArgs e)
        {
            if (notificationIndicator != null && notificationIndicator.BadgeSettings != null)
            {
                notificationIndicator.BadgeSettings.AutoHide = true;
            }
            if (cameraViewPage != null)
            {
                cameraViewPage.DisplayAlert("⚠️ Warning", "Feature will be Updated in Future", "OK");
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
        /// Changes Camera Text Based on Current Camera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightButton_Clicked(object? sender, EventArgs e)
        {
            if (cameraName != null)
            {
                if (cameraName.Text == "Entrance Camera")
                {
                    cameraName.Text = "Hall Camera";
                }
                else if (cameraName.Text == "Hall Camera")
                {
                    cameraName.Text = "Corridor Camera";
                }
                else if (cameraName.Text == "Corridor Camera")
                {
                    cameraName.Text = "Backdoor Camera";
                }
                else
                {
                    cameraName.Text = "Entrance Camera";
                }
            }
        }

        /// <summary>
        /// Changes Camera Text Based on Current Camera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftButton_Clicked(object? sender, EventArgs e)
        {
            if (cameraName != null)
            {
                if (cameraName.Text == "Entrance Camera")
                {
                    cameraName.Text = "Backdoor Camera";
                }
                else if (cameraName.Text == "Hall Camera")
                {
                    cameraName.Text = "Entrance Camera";
                }
                else if (cameraName.Text == "Corridor Camera")
                {
                    cameraName.Text = "Hall Camera";
                }
                else
                {
                    cameraName.Text = "Corridor Camera";
                }
            }
        }

        /// <summary>
        /// Used to Navigate Backwards from Current Page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Clicked(object? sender, EventArgs e)
        {

            if (Application.Current != null)
            {
                Application.Current.Windows[0].Navigation.PopModalAsync();
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
            
            if (this.leftButton != null)
            {
                this.leftButton.Clicked -= LeftButton_Clicked;
                this.leftButton = null;
            }

            if (this.rightButton != null)
            {
                this.rightButton.Clicked -= RightButton_Clicked;
                this.rightButton = null;
            }

            if (this.backButton != null)
            {
                this.backButton.Clicked -= BackButton_Clicked;
                this.backButton = null;
            }

            if (this.notificationButton != null)
            {
                this.notificationButton.Clicked -= NotificationButton_Clicked;
                this.notificationButton = null;
            }

            if (this.controlMenu != null)
            {
                this.controlMenu.Closing -= ControlMenu_Closing;
                this.controlMenu = null;
            }

            if (this.cameraName != null)
            {
                this.cameraName = null;
            }

            if (this.cameraViewPage != null)
            {
                this.cameraViewPage = null;
            }

            if (this.notificationIndicator != null)
            {
                this.notificationIndicator = null;
            }

        }
    }
}
