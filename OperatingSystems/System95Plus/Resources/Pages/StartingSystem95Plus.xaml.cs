using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Media.Animation;
using System.Threading.Tasks;

namespace System95.OperatingSystems.System95Plus.Resources.Pages
{
    public sealed partial class StartingSystem95Plus : Page
    {
        public StartingSystem95Plus()
        {
            this.InitializeComponent();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(500);
            this.Frame.Navigate(typeof(BootScreen), null, new SuppressNavigationTransitionInfo());
        }
    }
}
