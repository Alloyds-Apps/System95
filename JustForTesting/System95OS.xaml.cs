using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace System95.JustForTesting
{
    public sealed partial class System95OS : Page
    {
        public System95OS()
        {
            this.InitializeComponent();
        }
        private void StartButton_Checked(object sender, RoutedEventArgs e)
        {
            this.StartMenu.Visibility = Visibility.Visible;
        }
        private void StartButton_Unchecked(object sender, RoutedEventArgs e)
        {
            this.StartMenu.Visibility = Visibility.Collapsed;
        }
    }
}
