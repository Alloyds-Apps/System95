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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System95.JustForTesting.Pages;
using System.Threading.Tasks;

namespace System95.JustForTesting
{
    public sealed partial class System95OS : Page
    {
        public bool IsSingleTap;
        public static System95OS Current;
        private bool isPressed = true;
        public System95OS()
        {
            this.InitializeComponent();
            Current = this;
        }
        private void StartButton_Checked(object sender, RoutedEventArgs e)
        {
            this.StartMenu.Visibility = Visibility.Visible;
        }
        private void StartButton_Unchecked(object sender, RoutedEventArgs e)
        {
            this.StartMenu.Visibility = Visibility.Collapsed;
        }
        private void Taskbar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed == true)
            {
                if (isPressed)
                {
                    this.StartButton.IsChecked = false;
                    this.StartMenu.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void Taskbar_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed == true)
            {
                isPressed = true;
            }
        }
        private void ShutDown_Click(object sender, RoutedEventArgs e)
        {
            this.StartButton.IsChecked = false;
            this.StartMenu.Visibility = Visibility.Collapsed;
            this.ShutDownWindow.Visibility = Visibility.Visible;
        }
        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.ShutDownWindow.Visibility = Visibility.Collapsed;
        }
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            this.ShutDownWindow.Visibility = Visibility.Collapsed;
            this.Frame.Navigate(typeof(PleaseWaitRestart), null, new SuppressNavigationTransitionInfo());
        }
        private void ShutDownButton_Click(object sender, RoutedEventArgs e)
        {
            this.ShutDownWindow.Visibility = Visibility.Collapsed;
            this.Frame.Navigate(typeof(PleaseWaitShutDown), null, new SuppressNavigationTransitionInfo());
        }
    }
}
