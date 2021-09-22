using System.Windows;

namespace WPFHelpers.XamlBehaviors.Triggers
{
    public class HandlingEventTrigger : Microsoft.Xaml.Behaviors.EventTrigger
    {
        protected override void OnEvent(System.EventArgs eventArgs)
        {
            if (eventArgs is RoutedEventArgs routedEventArgs)
                routedEventArgs.Handled = true;
            base.OnEvent(eventArgs);
        }
    }

}
