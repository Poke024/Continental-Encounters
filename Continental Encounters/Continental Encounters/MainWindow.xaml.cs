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



        private void AddZone_Click(object sender, RoutedEventArgs e)
        {
            if (ZoneName.Text != "")
            {
                Zone newZone = new Zone(ZoneName.Text);
                ZoneList.Items.Add(newZone);
            }
            ZoneName.Text = "";

        }

        private void RemZone_Click(object sender, RoutedEventArgs e)
        {
            if (ZoneList.Items.IndexOf(ZoneList.SelectedItem) < ZoneList.Items.Count && ZoneList.Items.IndexOf(ZoneList.SelectedItem) >= 0)
            {
                foreach (Zone zone in ZoneList.Items)
                {
                    for(int i = 0; i < zone.CountNeighbors(); i++)
                    {
                        if (((Zone)ZoneList.SelectedItem) == zone.GetNeighbor(i))
                        {
                            zone.RemNeighbor(i);
                        }
                    }
                }
                ZoneList.Items.RemoveAt(ZoneList.Items.IndexOf(ZoneList.SelectedItem));
            }
            ZoneList.SelectedItem = null;
        }

        private void Zone_Selected(object sender, RoutedEventArgs e)
        {
            if(EncList.Items.Count != 0)
            {
                EncList.Items.Clear();
            }
            if (RoamList.Items.Count != 0)
            {
                RoamList.Items.Clear();
            }
            if (EnvList.Items.Count != 0)
            {
                EnvList.Items.Clear();
            }
            if (NhbrList.Items.Count != 0)
            {
                NhbrList.Items.Clear();
            }

            if (ZoneList.SelectedItem != null)
            {
                if (!((Zone)ZoneList.SelectedItem).EmptyEnc())
                {
                    foreach (var encounter in ((Zone)ZoneList.SelectedItem).GetAllEncounters())
                    {
                        EncList.Items.Add(encounter);
                    }
                    foreach (var roamer in ((Zone)ZoneList.SelectedItem).GetAllRoamers())
                    {
                        RoamList.Items.Add(roamer);
                    }
                    foreach (var envFeat in ((Zone)ZoneList.SelectedItem).GetAllEnvFeats())
                    {
                        EnvList.Items.Add(envFeat);
                    }
                    foreach (var neighbor in ((Zone)ZoneList.SelectedItem).GetAllNeighbors())
                    {
                        NhbrList.Items.Add(neighbor);
                    }
                }
            }
        }



        private void AddEnc_Click(object sender, RoutedEventArgs e)
        {
            if (EncName.Text != "" && ZoneList.SelectedItem != null)
            {
                ((Zone)ZoneList.SelectedItem).AddEncounter(EncName.Text);
                EncList.Items.Add(EncName.Text);
            }
            EncName.Text = "";

        }

        private void RemEnc_Click(object sender, RoutedEventArgs e)
        {
            if (0 <= EncList.Items.IndexOf(EncList.SelectedItem) && EncList.Items.IndexOf(EncList.SelectedItem) < EncList.Items.Count)
            {
                ((Zone)ZoneList.SelectedItem).RemRoamer(EncList.Items.IndexOf(EncList.SelectedItem));
                EncList.Items.RemoveAt(EncList.Items.IndexOf(EncList.SelectedItem));
            }
            EncList.SelectedItem = null;
        }



        private void AddRoam_Click(object sender, RoutedEventArgs e)
        {
            if (RoamName.Text != "" && ZoneList.SelectedItem != null)
            {
                ((Zone)ZoneList.SelectedItem).AddRoamer(RoamName.Text);
                RoamList.Items.Add(RoamName.Text);
            }
            RoamName.Text = "";
        }

        private void RemRoam_Click(object sender, RoutedEventArgs e)
        {
            if (0 <= RoamList.Items.IndexOf(RoamList.SelectedItem) && RoamList.Items.IndexOf(RoamList.SelectedItem) < RoamList.Items.Count)
            {
                ((Zone)ZoneList.SelectedItem).RemRoamer(RoamList.Items.IndexOf(RoamList.SelectedItem));
                RoamList.Items.RemoveAt(RoamList.Items.IndexOf(RoamList.SelectedItem));
            }
            RoamList.SelectedItem = null;
        }



        private void AddEnv_Click(object sender, RoutedEventArgs e)
        {
            if (EnvName.Text != "" && ZoneList.SelectedItem != null)
            {
                ((Zone)ZoneList.SelectedItem).AddEnvFeat(EnvName.Text);
                EnvList.Items.Add(EnvName.Text);
            }
            EnvName.Text = "";
        }

        private void RemEnv_Click(object sender, RoutedEventArgs e)
        {
            if (0 <= EnvList.Items.IndexOf(EnvList.SelectedItem) && EnvList.Items.IndexOf(EnvList.SelectedItem) < EnvList.Items.Count)
            {
                ((Zone)ZoneList.SelectedItem).RemEnvFeat(EnvList.Items.IndexOf(EnvList.SelectedItem));
                EnvList.Items.RemoveAt(EnvList.Items.IndexOf(EnvList.SelectedItem));
            }
            EnvList.SelectedItem = null;
        }



        private void AddNhbr_Click(object sender, RoutedEventArgs e)
        {
            if (NhbrName.Text != "" && ZoneList.SelectedItem != null)
            {
                bool nhbrAdded = false;
                if (NhbrName.Text != ((Zone)ZoneList.SelectedItem)._Name)
                {
                    foreach (Zone zone in ZoneList.Items)
                    {
                        if (zone._Name == NhbrName.Text)
                        {
                            ((Zone)ZoneList.SelectedItem).AddNeighbor(zone);
                            NhbrList.Items.Add(zone);
                            nhbrAdded = true;
                        }
                    }
                    if (!nhbrAdded)
                    {
                        Zone newZone = new Zone(NhbrName.Text);
                        ZoneList.Items.Add(newZone);
                        NhbrList.Items.Add(newZone);
                    }
                }
            }
            NhbrName.Text = "";
        }

        private void RemNhbr_Click(object sender, RoutedEventArgs e)
        {
            if (0 <= NhbrList.Items.IndexOf(NhbrList.SelectedItem) && NhbrList.Items.IndexOf(NhbrList.SelectedItem) < NhbrList.Items.Count)
            {
                ((Zone)ZoneList.SelectedItem).RemNeighbor(NhbrList.Items.IndexOf(NhbrList.SelectedItem));
                NhbrList.Items.RemoveAt(NhbrList.Items.IndexOf(NhbrList.SelectedItem));
            }
            EnvList.SelectedItem = null;
        }
    }
}
