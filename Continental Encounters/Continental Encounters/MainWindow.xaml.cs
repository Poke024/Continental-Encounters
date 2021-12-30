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
using Windows.Storage.Pickers;
using Windows.Storage;
using WinRT.Interop;
using CommunityToolkit.WinUI.UI.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Continental_Encounters
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow() { this.InitializeComponent(); }
        private int TypeSel = 0;

        private void ClearLists()
        {
            if (EncList.Items.Count != 0) { EncList.Items.Clear(); }
            if (RoamList.Items.Count != 0) { RoamList.Items.Clear(); }
            if (EnvList.Items.Count != 0) { EnvList.Items.Clear(); }
            if (NhbrList.Items.Count != 0) { NhbrList.Items.Clear(); }
        }



        private async void OpenContinent_Click(object sender, RoutedEventArgs e)
        {
            var hwnd = WindowNative.GetWindowHandle(this);
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.List;
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".ctnt");
            InitializeWithWindow.Initialize(picker, hwnd);

            StorageFile openFile = await picker.PickSingleFileAsync();
            if (openFile != null)
            {
                ClearLists();
                if (ZoneList.Items.Count != 0) { ZoneList.Items.Clear(); }
                if (EncFeats.Items.Count != 0) { EncList.Items.Clear(); }

                string[] lines = System.IO.File.ReadAllLines(openFile.Path);
                int zoneCount = Convert.ToInt32(lines[0].Trim());

                bool validFile = false;
                string[] zoneNames = new string[zoneCount];
                for (int i = 0; i < zoneCount; i++)
                {
                    string nextZone = lines[1 + (5 * i)].Trim();
                    if (zoneNames.Contains(nextZone))
                    {
                        validFile = false;
                        break;
                    }
                    else
                    {
                        zoneNames[i] = nextZone;
                    }
                }
                validFile = true;
                
                if (validFile)
                {
                    for (int i = 0; i < zoneCount; i++)
                    {
                        Zone newZone = new Zone(lines[1 + (5 * i)].Trim());
                        List<string> encLine = lines[2 + (5 * i)].Trim().Split(", ").ToList();
                        List<string> roamLine = lines[3 + (5 * i)].Trim().Split(", ").ToList();
                        List<string> envLine = lines[4 + (5 * i)].Trim().Split(", ").ToList();
                        List<string> nhbrLine = lines[5 + (5 * i)].Trim().Split(", ").ToList();

                        if (encLine.Count() > 1) { newZone.SetEncounters(encLine.GetRange(1, encLine.Count() - 1)); }
                        if (roamLine.Count() > 1) { newZone.SetRoamers(roamLine.GetRange(1, roamLine.Count() - 1)); }
                        if (envLine.Count() > 1) { newZone.SetEnvFeats(envLine.GetRange(1, envLine.Count() - 1)); }
                        if (nhbrLine.Count() > 1) { newZone.SetNeighbors(nhbrLine.GetRange(1, nhbrLine.Count() - 1)); }

                        ZoneList.Items.Add(newZone);
                    }
                }
                else
                {
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Invalid file, duplicate zone names are not allowed.",
                        PrimaryButtonText = "Okay",
                        DefaultButton = ContentDialogButton.Primary
                    };
                    dialog.XamlRoot = m_Window.Content.XamlRoot;
                    ContentDialogResult result = await dialog.ShowAsync();
                }
            }
            else
            {
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "File could not be opened.",
                    PrimaryButtonText = "Okay",
                    DefaultButton = ContentDialogButton.Primary
                };
                dialog.XamlRoot = m_Window.Content.XamlRoot;
                ContentDialogResult result = await dialog.ShowAsync();
            }
        }

        private async void SaveContinent_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "",
                PrimaryButtonText = "Okay",
                DefaultButton = ContentDialogButton.Primary
            };
            dialog.XamlRoot = m_Window.Content.XamlRoot;

            var hwnd = WindowNative.GetWindowHandle(this);
            var savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("Continent", new List<string>() { ".ctnt" });
            savePicker.SuggestedFileName = "New Continent";
            InitializeWithWindow.Initialize(savePicker, hwnd);

            StorageFile saveFile = await savePicker.PickSaveFileAsync();
            if (saveFile != null)
            {
                CachedFileManager.DeferUpdates(saveFile);

                var stream = await saveFile.OpenAsync(FileAccessMode.ReadWrite);

                using (var outputStream = stream.GetOutputStreamAt(0))
                {
                    using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                    {
                        dataWriter.WriteString($"{ZoneList.Items.Count}\n");
                        foreach (Zone curZone in ZoneList.Items)
                        {
                            dataWriter.WriteString($"{curZone._Name}\n");

                            dataWriter.WriteString($"{curZone.CountEncounters()}");
                            if (curZone.CountEncounters() > 0)
                            {
                                string combined = string.Join(", ", curZone.GetAllEncounters().ToArray());
                                dataWriter.WriteString(", " + combined);
                            }
                            dataWriter.WriteString("\n");

                            dataWriter.WriteString($"{curZone.CountRoamers()}");
                            if (curZone.CountRoamers() > 0)
                            {
                                string combined = string.Join(", ", curZone.GetAllRoamers().ToArray());
                                dataWriter.WriteString(", " + combined);
                            }
                            dataWriter.WriteString("\n");

                            dataWriter.WriteString($"{curZone.CountEnvFeats()}");
                            if (curZone.CountEnvFeats() > 0)
                            {
                                string combined = string.Join(", ", curZone.GetAllEnvFeats().ToArray());
                                dataWriter.WriteString(", " + combined);
                            }
                            dataWriter.WriteString("\n");

                            dataWriter.WriteString($"{curZone.CountNeighbors()}");
                            if (curZone.CountNeighbors() > 0)
                            {
                                string combined = string.Join(", ", curZone.GetAllNeighbors().ToArray());
                                dataWriter.WriteString(", " + combined);
                            }
                            dataWriter.WriteString("\n");
                        }
                        await dataWriter.StoreAsync();
                        await outputStream.FlushAsync();
                    }
                }
                stream.Dispose();

                Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(saveFile);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete) { dialog.Title = "File '" + saveFile.Name + "' was saved."; }
                else if (status == Windows.Storage.Provider.FileUpdateStatus.CompleteAndRenamed) { dialog.Title = "File '" + saveFile.Name + "' was renamed and saved."; }
                else { dialog.Title = "File '" + saveFile.Name + "' couldn't be saved."; }
            }
            else { dialog.Title = "Operation cancelled."; }

            ContentDialogResult result = await dialog.ShowAsync();
        }


        private void AddZoneKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) { AddZone_Click(sender, e); }
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
                        if (((Zone)ZoneList.SelectedItem)._Name == zone.GetNeighbor(i))
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
            ClearLists();

            if (ZoneList.SelectedItem != null)
            {
                if (!((Zone)ZoneList.SelectedItem).EmptyEnc())
                {
                    foreach (var encounter in ((Zone)ZoneList.SelectedItem).GetAllEncounters()) { EncList.Items.Add(encounter); }
                }

                if (!((Zone)ZoneList.SelectedItem).EmptyRoam())
                {
                    foreach (var roamer in ((Zone)ZoneList.SelectedItem).GetAllRoamers()) { RoamList.Items.Add(roamer); }
                }

                if (!((Zone)ZoneList.SelectedItem).EmptyEnv())
                {
                    foreach (var envFeat in ((Zone)ZoneList.SelectedItem).GetAllEnvFeats()) { EnvList.Items.Add(envFeat); }
                    EnvSlider.Maximum = ((Zone)ZoneList.SelectedItem).CountEnvFeats();
                }
                else { EnvSlider.Maximum = 0; }

                if (!((Zone)ZoneList.SelectedItem).EmptyNhbr())
                {
                    foreach (var neighbor in ((Zone)ZoneList.SelectedItem).GetAllNeighbors()) { NhbrList.Items.Add(neighbor); }
                }
            }
        }



        private void AddEncKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) { AddEnc_Click(sender, e); }
        }
        private void AddEnc_Click(object sender, RoutedEventArgs e)
        {
            if (EncName.Text != "" && ZoneList.SelectedItem != null)
            {
                ((Zone)ZoneList.SelectedItem).AddEncounter(EncName.Text);
                EncList.Items.Add(EncName.Text);
                EncName.Text = "";
            }

        }

        private void RemEnc_Click(object sender, RoutedEventArgs e)
        {
            if (0 <= EncList.Items.IndexOf(EncList.SelectedItem) && EncList.Items.IndexOf(EncList.SelectedItem) < EncList.Items.Count)
            {
                ((Zone)ZoneList.SelectedItem).RemEncounter(EncList.Items.IndexOf(EncList.SelectedItem));
                EncList.Items.RemoveAt(EncList.Items.IndexOf(EncList.SelectedItem));
            }
            EncList.SelectedItem = null;
        }



        private void AddRoamKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) { AddRoam_Click(sender, e); }
        }
        private void AddRoam_Click(object sender, RoutedEventArgs e)
        {
            if (RoamName.Text != "" && ZoneList.SelectedItem != null)
            {
                ((Zone)ZoneList.SelectedItem).AddRoamer(RoamName.Text);
                RoamList.Items.Add(RoamName.Text);
                RoamName.Text = "";
            }
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



        private void AddEnvKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) { AddEnv_Click(sender, e); }
        }
        private void AddEnv_Click(object sender, RoutedEventArgs e)
        {
            if (EnvName.Text != "" && ZoneList.SelectedItem != null)
            {
                ((Zone)ZoneList.SelectedItem).AddEnvFeat(EnvName.Text);
                EnvList.Items.Add(EnvName.Text);
                EnvName.Text = "";
                EnvSlider.Maximum++;
            }
        }

        private void RemEnv_Click(object sender, RoutedEventArgs e)
        {
            if (0 <= EnvList.Items.IndexOf(EnvList.SelectedItem) && EnvList.Items.IndexOf(EnvList.SelectedItem) < EnvList.Items.Count)
            {
                ((Zone)ZoneList.SelectedItem).RemEnvFeat(EnvList.Items.IndexOf(EnvList.SelectedItem));
                EnvList.Items.RemoveAt(EnvList.Items.IndexOf(EnvList.SelectedItem));
                EnvSlider.Maximum--;
            }
            EnvList.SelectedItem = null;
        }



        private void AddNhbrKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) { AddNhbr_Click(sender, e); }
        }
        private void AddNhbr_Click(object sender, RoutedEventArgs e)
        {
            if (NhbrName.Text != "" && ZoneList.SelectedItem != null)
            {
                Zone newZone = new Zone(NhbrName.Text);
                if (newZone != ((Zone)ZoneList.SelectedItem) && !((Zone)ZoneList.SelectedItem).GetAllNeighbors().Contains(newZone._Name))
                {
                    if(ZoneList.Items.Any(item => ((Zone)item) == newZone))
                    {
                        int index = -1;
                        for (int i = 0; i < ZoneList.Items.Count; i++)
                        {
                            if (newZone == (Zone)ZoneList.Items[i])
                            {
                                index = i;
                                break;
                            }
                        }
                        ((Zone)ZoneList.Items[index]).AddNeighbor(((Zone)ZoneList.SelectedItem)._Name);
                        ((Zone)ZoneList.SelectedItem).AddNeighbor(((Zone)ZoneList.Items[index])._Name);
                        NhbrList.Items.Add(((Zone)ZoneList.Items[index])._Name);
                    }
                    else
                    {
                        NhbrList.Items.Add(newZone._Name);
                        ((Zone)ZoneList.SelectedItem).AddNeighbor(newZone._Name);
                        newZone.AddNeighbor(((Zone)ZoneList.SelectedItem)._Name);
                        ZoneList.Items.Add(newZone);
                    }
                }
                NhbrName.Text = "";
            }
        }

        private async void RemNhbr_Click(object sender, RoutedEventArgs e)
        {
            int nhbrIndex = -1;
            for(int i = 0; i < ZoneList.Items.Count(); i++)
            {
                Zone curZone = (Zone)ZoneList.Items[i];
                if (curZone._Name == (string)NhbrList.SelectedItem) { nhbrIndex = i; }
            }

            if (((Zone)ZoneList.Items[nhbrIndex]).GetAllNeighbors().Contains(((Zone)ZoneList.SelectedItem)._Name))
            {
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Remove current zone from deletion target's neighbors?",
                    PrimaryButtonText = "Yes",
                    SecondaryButtonText = "No",
                    DefaultButton = ContentDialogButton.Primary
                };
                dialog.XamlRoot = m_Window.Content.XamlRoot;
                ContentDialogResult result = await dialog.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {
                    foreach (Zone zone in ZoneList.Items)
                    {
                        if (zone._Name == (string)NhbrList.SelectedItem)
                        {
                            for (int i = 0; i < zone.CountNeighbors(); i++)
                            {
                                if (zone.GetNeighbor(i) == ((Zone)ZoneList.SelectedItem)._Name)
                                {
                                    zone.RemNeighbor(i);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }

            if (0 <= NhbrList.Items.IndexOf(NhbrList.SelectedItem) && NhbrList.Items.IndexOf(NhbrList.SelectedItem) < NhbrList.Items.Count)
            {
                ((Zone)ZoneList.SelectedItem).RemNeighbor(NhbrList.Items.IndexOf(NhbrList.SelectedItem));
                NhbrList.Items.RemoveAt(NhbrList.Items.IndexOf(NhbrList.SelectedItem));
            }
            EnvList.SelectedItem = null;
        }

        

        private void TypeButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null)
            {
                string TypeName = rb.Tag.ToString();
                switch (TypeName)
                {
                    case "Any":
                        TypeSel = 4;
                        break;

                    case "Local":
                        TypeSel = 1;
                        break;

                    case "Roam":
                        TypeSel = 2;
                        break;

                    case "Combined":
                        TypeSel = 3;
                        break;
                }
            }
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            if(ZoneList.SelectedItem != null)
            {
                Zone selZone = (Zone)ZoneList.SelectedItem;
                int choice = 0;
                EncFeats.Items.Clear();

                if (TypeSel != 0) { choice = TypeSel; }

                var rnd = new Random();
                bool roamerPossible, breakLoop;
                roamerPossible = breakLoop = false;
                
                if (choice > 0)
                {
                    if (selZone.EmptyNhbr()) { roamerPossible = false; }
                    else
                    {
                        foreach (Zone curZone in ZoneList.Items)
                        {
                            if (selZone.GetAllNeighbors().Contains(curZone._Name) && !curZone.EmptyRoam())
                            {
                                roamerPossible = true;
                                break;
                            }
                        }
                    }
                }

                do
                {
                    switch (choice)
                    {
                        case 1:
                            if (selZone.EmptyEnc())
                            {
                                GeneratedEnc.Severity = InfoBarSeverity.Warning;
                                GeneratedEnc.Message = "Unable to generate encounter with current selections.";
                                breakLoop = true;
                            }
                            else
                            {
                                GeneratedEnc.Severity = InfoBarSeverity.Success;
                                GeneratedEnc.Message = selZone.GenerateLocal();
                                breakLoop = true;
                            }
                            break;

                        case 2:
                            if (!roamerPossible)
                            {
                                GeneratedEnc.Severity = InfoBarSeverity.Warning;
                                GeneratedEnc.Message = "Unable to generate encounter with current selections.";
                                breakLoop = true;
                            }
                            else
                            {
                                int nhbrIndex2 = -1;
                                Zone nhbr2 = new Zone();
                                do
                                {
                                    nhbrIndex2 = rnd.Next(ZoneList.Items.Count());
                                    nhbr2 = (Zone)ZoneList.Items[nhbrIndex2];
                                } while (!selZone.GetAllNeighbors().Contains(nhbr2._Name) || nhbr2.EmptyRoam());

                                GeneratedEnc.Severity = InfoBarSeverity.Success;
                                GeneratedEnc.Message = nhbr2.GenerateRoamer();
                                breakLoop = true;
                            }
                            break;

                        case 3:
                            if (selZone.EmptyEnc() || !roamerPossible)
                            {
                                GeneratedEnc.Severity = InfoBarSeverity.Warning;
                                GeneratedEnc.Message = "Unable to generate encounter with current selections.";
                                breakLoop = true;
                            }
                            else
                            {
                                int nhbrIndex3 = -1;
                                Zone nhbr3 = new Zone();
                                do
                                {
                                    nhbrIndex3 = rnd.Next(ZoneList.Items.Count());
                                    nhbr3 = (Zone)ZoneList.Items[nhbrIndex3];
                                } while (!selZone.GetAllNeighbors().Contains(nhbr3._Name) || nhbr3.EmptyRoam());

                                GeneratedEnc.Severity = InfoBarSeverity.Success;
                                string enc1 = selZone.GenerateLocal();
                                string enc2 = nhbr3.GenerateRoamer();
                                GeneratedEnc.Message = $"{enc1} and {enc2}";
                                breakLoop = true;
                            }
                            break;

                        case 4:
                            if (selZone.EmptyEnc() && !roamerPossible)
                            {
                                GeneratedEnc.Severity = InfoBarSeverity.Warning;
                                GeneratedEnc.Message = "Unable to generate encounter with current selections.";
                                breakLoop = true;
                            }
                            else if (selZone.EmptyEnc()) { choice = 2; }
                            else if (!roamerPossible) { choice = 1; }
                            else { choice = rnd.Next(1, 4); }
                            break;

                        default:
                            GeneratedEnc.Severity = InfoBarSeverity.Error;
                            GeneratedEnc.Message = "A generation error has occured. Please ensure a type has been selected.";
                            breakLoop = true;
                            break;
                    }
                } while (!breakLoop);

                if ((int)EnvSlider.Value > 0)
                {
                    for(int i = 0; i < (int)EnvSlider.Value; i++)
                    {
                        EncFeats.Items.Add(((Zone)ZoneList.SelectedItem).GenerateFeature());
                    }
                }
            }
            else
            {
                GeneratedEnc.Message = "Please select a zone before generating.";
                GeneratedEnc.Severity = InfoBarSeverity.Error;
            }
        }
    }
}
