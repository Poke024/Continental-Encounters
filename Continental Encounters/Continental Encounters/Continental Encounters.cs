using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Continental_Encounters
{
    public partial class ContinentForm : Form
    {
        public ContinentForm()
        {
            InitializeComponent();


            AddZoneTip.SetToolTip(AddZoneBtn, "Add Typed Zone");
            RemoveZoneTip.SetToolTip(RemoveZoneBtn, "Remove Selected Zone");
            AddEncounterTip.SetToolTip(AddEncounterBtn, "Add Typed Encounter");
            RemoveEncounterTip.SetToolTip(RemoveEncounterBtn, "Remove Selected Encounter");
            AddRoamerTip.SetToolTip(AddRoamerBtn, "Add Typed Roamer");
            RemoveRoamerTip.SetToolTip(RemoveRoamerBtn, "Remove Selected Roamer");
            AddEnvironmentTip.SetToolTip(AddEnvironmentBtn, "Add Typed Environment");
            RemoveEnvironmentTip.SetToolTip(RemoveEnvironmentBtn, "Remove Selected Environment");
            AddNeighborTip.SetToolTip(AddNeighborBtn, "Add Typed Neighbor");
            RemoveNeighborTip.SetToolTip(RemoveNeighborBtn, "Remove Selected Neighbor");
        }

        List<Zone> zones = new List<Zone>();
        private void AddZoneBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ZoneInput.Text) && !ZoneListBox.Items.Contains(ZoneInput.Text))
            { 
                ZoneListBox.Items.Add(ZoneInput.Text);
                zones.Add(new Zone(ZoneInput.Text));
            }
        }

        private void ZoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EncounterListBox.Items.Clear();
            RoamerListBox.Items.Clear();
            EnvironmentListBox.Items.Clear();
            NeighborListBox.Items.Clear();
            
            if (zones[ZoneListBox.SelectedIndex]._Name == (string)ZoneListBox.SelectedItem)
            {

            }
            else
            {
                Zone targZone = new Zone((string)ZoneListBox.SelectedItem);
                if (zones.Contains(targZone))
                {

                }
                else
                {

                }
            }
        }
    }
}
