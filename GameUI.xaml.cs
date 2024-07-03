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

namespace System95
{
    public sealed partial class GameUI : Page
    {
        public GameUI()
        {
            this.InitializeComponent();
            createdBy();

            
        }
        public void createdBy()
        {
            TextBlock1.Text = "Created by:";
            TextBlock2.Text = "Alloyd";

            DoubleAnimation DA1 = new DoubleAnimation();
            DA1.From = 0.0;
            DA1.To = 1.0;
            DA1.Duration = new Duration(TimeSpan.FromSeconds(1));
            Storyboard SB1 = new Storyboard();
            SB1.Children.Add(DA1);
            Storyboard.SetTargetName(DA1, TextBlock1.Name); 
            DoubleAnimation DA2 = new DoubleAnimation();
            DA1.From = 0.0;
            DA1.To = 1.0;
            DA1.Duration = new Duration(TimeSpan.FromSeconds(1));
            Storyboard SB2 = new Storyboard();
            SB2.Children.Add(DA2);
            Storyboard.SetTargetName(DA2, TextBlock2.Name);
        }
    }
}
