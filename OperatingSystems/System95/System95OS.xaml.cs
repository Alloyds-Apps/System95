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
using System95.OperatingSystems.System95.System95Resources.Pages;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas;

namespace System95.OperatingSystems.System95
{
    public sealed partial class System95OS : Page
    {
        private CanvasBitmap backgroundImage;
        private CanvasImageBrush backgroundBrush;
        private bool isPressed = true;
        public System95OS()
        {
            this.InitializeComponent();
        }
        private void BackgroundCanvas_CreateResources(CanvasControl sender, CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(Task.Run(async () =>
            {
                string uri = "ms-appx:///OperatingSystems/System95/System95Resources/Images/grid.png";

                backgroundImage = await CanvasBitmap.LoadAsync(sender, new Uri(uri));
                backgroundBrush = new CanvasImageBrush(sender, backgroundImage);

                // Set the brush's edge behaviour to wrap, so the image repeats if the drawn region is too big
                backgroundBrush.ExtendX = backgroundBrush.ExtendY = CanvasEdgeBehavior.Wrap;
                backgroundBrush.Transform = System.Numerics.Matrix3x2.CreateScale(0.4f);
            }).AsAsyncAction());
        }

        private void BackgroundCanvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            var session = args.DrawingSession;
            session.FillRectangle(new Rect(new Point(), sender.RenderSize), backgroundBrush);
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
        private void CloseShutDownWindow_Click(object sender, RoutedEventArgs e)
        {
            this.ShutDownWindow.Visibility = Visibility.Collapsed;
        }
        private void CloseSettingsWindow_Click(object sender, RoutedEventArgs e)
        {
            this.SettingsWindow.Visibility = Visibility.Collapsed;
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

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.SettingsWindow.Visibility = Visibility.Visible;
            this.StartButton.IsChecked = false;
            this.StartMenu.Visibility = Visibility.Collapsed;
        }
    }
}
