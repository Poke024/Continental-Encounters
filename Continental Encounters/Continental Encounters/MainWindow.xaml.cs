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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Continental_Encounters
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void newZone_Click(object sender, RoutedEventArgs e)
        {
            if (ZoneName.Text != "")
            {
                Zone newZone = new Zone(ZoneName.Text);
                ZoneList.Items.Add(newZone);
            }
            ZoneName.Text = "";

        }

        private void remZone_Click(object sender, RoutedEventArgs e)
        {
            if (ZoneList.Items.IndexOf(ZoneList.SelectedItem) < ZoneList.Items.Count && ZoneList.Items.IndexOf(ZoneList.SelectedItem) >= 0)
            {
                ZoneList.Items.RemoveAt(ZoneList.Items.IndexOf(ZoneList.SelectedItem));
            }
            ZoneList.SelectedItem = null;
        }
    }
}
