using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace System95.OperatingSystems.System95Plus.Resources.Pages
{
    public sealed partial class SafeToTurnOff : Page
    {
        MediaPlayer SafeToTurnOffPlay = new MediaPlayer();
        public SafeToTurnOff()
        {
            this.InitializeComponent();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            this.TurnOn.Visibility = Visibility.Visible;
        }
        private void TurnOn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GameUI), null, new SuppressNavigationTransitionInfo());
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SafeToTurnOffPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/fanshutdown.mp3"));
            SafeToTurnOffPlay.Play();
        }
    }
}
