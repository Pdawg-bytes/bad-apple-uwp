using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Timers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Printing3D;
using Windows.Security.Cryptography.Core;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BadAppleUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer Timer = new DispatcherTimer();
        public MainPage()
        {
            this.InitializeComponent();

            // Defines song player URI and sets variables
            Uri songUri = new Uri("ms-appx:///Assets/Sounds/bad_apple.mp3");
            songPlayer.Source = songUri;
            SongVolume.Value = 100;
            FrameNumberBox.IsEnabled = false;

            //Init frame update
            Timer.Tick += Timer_Tick;
            Timer.Interval = TimeSpan.FromMilliseconds(44);
        }

        // Double to be used for volume control
        public static double SongVolDouble;

        private void play_Click(object sender, RoutedEventArgs e)
        {
            // Pretty self explanitory
            songPlayer.Play();
            Timer.Start();
            play.IsEnabled = false;
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            // Pretty self explanitory
            songPlayer.Pause();
            Timer.Stop();
            play.IsEnabled = true;
        }

        private void SongVolume_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            // Pretty self explanitory
            SongVolDouble = e.NewValue / 100;
            songPlayer.Volume = Math.Round(SongVolDouble, 2);
        }

        // Creates image variable
        public static BitmapImage FrameImage;
        // Defines frame count
        public static int framei;
        private void Timer_Tick(object sender, object e)
        {
            // Adds 1 to move onto the next frame
            framei++;
            // Sets frame source
            FrameImage = new BitmapImage(new Uri("ms-appx:///Assets/Frames/" + framei + ".jpg"));
            // Sets image source
            BadAppleFrame.Source = FrameImage;
            // Adds to frame counter value
            FrameNumberBox.Value++;
        }

        private void songPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            // Pretty self explanitory
            Timer.Stop();
            framei = 0;
            FrameImage = new BitmapImage(new Uri("ms-appx:///Assets/Frames/1.jpg"));
            BadAppleFrame.Source = FrameImage;
            FrameNumberBox.Value = 0;
            play.IsEnabled = true;
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            // Pretty self explanitory
            Timer.Stop();
            framei = 0;
            FrameImage = new BitmapImage(new Uri("ms-appx:///Assets/Frames/1.jpg"));
            BadAppleFrame.Source = FrameImage;
            songPlayer.Position = new TimeSpan(0, 0, 0);
            Uri songUri = new Uri("ms-appx:///Assets/Sounds/bad_apple.mp3");
            FrameNumberBox.Value = 0;
            play.IsEnabled = false;
            Thread.Sleep(1);
            songPlayer.Play();
            Timer.Start();
        }
    }
}
