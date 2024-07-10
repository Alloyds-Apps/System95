using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Threading.Tasks;

namespace System95.OperatingSystems.System95Plus.Resources.Pages
{
    public sealed partial class PleaseWaitShutDown : Page
    {
        public PleaseWaitShutDown()
        {
            this.InitializeComponent();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.ProtectedCursor = InputSystemCursor.Create(InputSystemCursorShape.Wait);
            await Task.Delay(1500);
            this.ProtectedCursor = InputSystemCursor.Create(InputSystemCursorShape.Arrow);

            await Task.Delay(3500);
            this.Frame.Navigate(typeof(SafeToTurnOff), null, new SuppressNavigationTransitionInfo());
        }
    }
}
