﻿using Q42.WinRT.Controls;
using Q42.WinRT.UniversalSampleApp.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Q42.WinRT.UniversalSampleApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ControlsExamplePage : Page
    {
      Random _random = new Random();
      Random _random2 = new Random();

      public ControlsExamplePage()
      {
        this.InitializeComponent();
      }

      protected override void OnNavigatedTo(NavigationEventArgs e)
      {
        RandomColors = new List<Color>();
        RandomColors.Add(Colors.LightSkyBlue);
        RandomColors.Add(Colors.MidnightBlue);
        RandomColors.Add(Colors.LightPink);
        RandomColors.Add(Colors.YellowGreen);
        RandomColors.Add(Colors.Yellow);
        RandomColors.Add(Colors.Firebrick);
        RandomColors.Add(Colors.OldLace);

#if WINDOWS_PHONE_APP
        Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
#endif
      }

      protected override void OnNavigatedFrom(NavigationEventArgs e)
      {
#if WINDOWS_PHONE_APP
        Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
#endif
      }

#if WINDOWS_PHONE_APP
      void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
      {
        e.Handled = true;
        if (this.Frame.CanGoBack)
          this.Frame.GoBack();
      }
#endif

      public List<Color> RandomColors { get; set; }


      private void Button_Click_1(object sender, RoutedEventArgs e)
      {
        UserControlFlyout flyout = new UserControlFlyout();
        flyout.ShowFlyout(new FlyoutContentUserControl());
      }

      private void AddButton_Click_1(object sender, RoutedEventArgs e)
      {
        Border border = new Border();
        border.Height = RandomSize();
        border.Width = RandomSize();
        border.Margin = new Thickness(5);
        border.Background = RandomBackgroundColor();

        WrapPanel.Children.Add(border);
      }

      private double RandomSize()
      {
        int size = _random.Next(100);

        return 40 + size;
      }

      private Brush RandomBackgroundColor()
      {
        int index = _random2.Next(RandomColors.Count() - 1);

        return new SolidColorBrush(RandomColors[index]);
      }


    }
}
