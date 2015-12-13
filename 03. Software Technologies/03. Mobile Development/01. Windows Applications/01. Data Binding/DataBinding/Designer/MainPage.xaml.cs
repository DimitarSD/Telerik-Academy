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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Designer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnForegroudColorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var color = (ComboBoxItem)foregroundColor.SelectedValue;
            textContainer.Foreground = GetColor(color.Content.ToString());
        }

        private void OnBackgroundColorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var color = (ComboBoxItem)backgroundColor.SelectedValue;
            textContainerBackground.Background = GetColor(color.Content.ToString());
        }

        private SolidColorBrush GetColor(string colorName)
        {
            switch (colorName)
            {
                case "Pink":
                    return new SolidColorBrush(Colors.Pink);
                case "White":
                    return new SolidColorBrush(Colors.White);
                case "Green":
                    return new SolidColorBrush(Colors.Green);
                case "Black":
                    return new SolidColorBrush(Colors.Black);
                case "Yellow":
                    return new SolidColorBrush(Colors.Yellow);
                case "Red":
                    return new SolidColorBrush(Colors.Red);
                default:
                    return null;
            }
        }
    }
}
