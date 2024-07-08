using CommunityToolkit.WinUI.Animations;
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
using Windows.Foundation;
using Windows.Foundation.Collections;
using System95.OperatingSystems.System95.Resources.Pages;

namespace System95
{
    public sealed partial class GameUI : Page
    {
        public GameUI()
        {
            this.InitializeComponent();
        }
        private void StartSystem95OS_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StartingSystem95), null, new SuppressNavigationTransitionInfo());
        }
    }
}
