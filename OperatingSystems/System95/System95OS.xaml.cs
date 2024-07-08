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
using System95.OperatingSystems.System95.Resources.Pages;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Core;
using Microsoft.UI.Input;
using System.Reflection;

namespace System95.OperatingSystems.System95
{
    public sealed partial class System95OS : Page
    {
        MediaPlayer introPlay = new MediaPlayer();
        MediaPlayer outroPlay = new MediaPlayer();
        MediaPlayer clickPlay = new MediaPlayer();
        private CanvasBitmap backgroundImage;
        private CanvasImageBrush backgroundBrush;
        public System95OS()
        {
            this.InitializeComponent();
        }
        private void BackgroundCanvas_CreateResources(CanvasControl sender, CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(Task.Run(async () =>
            {
                string uri = "ms-appx:///OperatingSystems/System95/Resources/Images/grid.png";

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
        private void BeginButton_Checked(object sender, RoutedEventArgs e)
        {
            this.BeginMenu.Visibility = Visibility.Visible;
        }
        private void BeginButton_Unchecked(object sender, RoutedEventArgs e)
        {
            this.BeginMenu.Visibility = Visibility.Collapsed;
        }
        private void ShutDown_Click(object sender, RoutedEventArgs e)
        {
            this.BeginButton.IsChecked = false;
            this.BeginMenu.Visibility = Visibility.Collapsed;
            this.ShutDownWindow.Visibility = Visibility.Visible;

            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void CloseShutDownWindow_Click(object sender, RoutedEventArgs e)
        {
            this.ShutDownWindow.Visibility = Visibility.Collapsed;
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            this.ShutDownWindow.Visibility = Visibility.Collapsed;
            this.Frame.Navigate(typeof(PleaseWaitRestart), null, new SuppressNavigationTransitionInfo());

            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();

            introPlay.Dispose();
            outroPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///OperatingSystems/System95/Resources/Sounds/outro_s95.mp3"));
            outroPlay.Play();
        }
        private void ShutDownButton_Click(object sender, RoutedEventArgs e)
        {
            this.ShutDownWindow.Visibility = Visibility.Collapsed;
            this.Frame.Navigate(typeof(PleaseWaitShutDown), null, new SuppressNavigationTransitionInfo());

            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();

            introPlay.Dispose();
            outroPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///OperatingSystems/System95/Resources/Sounds/outro_s95.mp3"));
            outroPlay.Play();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            introPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///OperatingSystems/System95/Resources/Sounds/intro_s95.mp3"));
            introPlay.Play();
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            ShutDownButton.Click += ShutDownButton_Click;
            RestartButton.Click += RestartButton_Click;
        }
        private void BeginButton_Click(object sender, RoutedEventArgs e)
        {
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void Achievements_Click(object sender, RoutedEventArgs e)
        {
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void SystemNet_Click(object sender, RoutedEventArgs e)
        {
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void MyMenu_Click(object sender, RoutedEventArgs e)
        {
            this.BeginButton.IsChecked = false;
            this.BeginMenu.Visibility = Visibility.Collapsed;
            this.MyMenuWindow.Visibility = Visibility.Visible;
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void LoadSave_Click(object sender, RoutedEventArgs e)
        {
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.BeginButton.IsChecked = false;
            this.BeginMenu.Visibility = Visibility.Collapsed;
            this.SettingsWindow.Visibility = Visibility.Visible;
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void SystemDOS_Click(object sender, RoutedEventArgs e)
        {
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void Help_Click(object sender, RoutedEventArgs e)
        {
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void SoundToggle_Click(object sender, RoutedEventArgs e)
        {
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void GameLanguage_Click(object sender, RoutedEventArgs e)
        {
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void MediaPlayer_Click(object sender, RoutedEventArgs e)
        {
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void Defragmentation_Click(object sender, RoutedEventArgs e)
        {
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void Bin_Click(object sender, RoutedEventArgs e)
        {
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void CloseSettingsWindow_Click(object sender, RoutedEventArgs e)
        {
            this.SettingsWindow.Visibility = Visibility.Collapsed;
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
        private void CloseMyMenuWindow_Click(object sender, RoutedEventArgs e)
        {
            this.MyMenuWindow.Visibility = Visibility.Collapsed;
            clickPlay.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sounds/click.mp3"));
            clickPlay.Play();
        }
    }
}
