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

        private void ZoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddZoneBtn_Click(object sender, EventArgs e)
        {

        }

        private void RemoveZoneBtn_Click(object sender, EventArgs e)
        {

        }

        private void EncounterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddEncounterBtn_Click(object sender, EventArgs e)
        {

        }

        private void RemoveEncounterBtn_Click(object sender, EventArgs e)
        {

        }

        private void RoamerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddRoamerBtn_Click(object sender, EventArgs e)
        {

        }

        private void RemoveRoamerBtn_Click(object sender, EventArgs e)
        {

        }

        private void EnvironmentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddEnvironmentBtn_Click(object sender, EventArgs e)
        {

        }

        private void RemoveEnvironmentBtn_Click(object sender, EventArgs e)
        {

        }

        private void NeighborListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddNeighborBtn_Click(object sender, EventArgs e)
        {

        }

        private void RemoveNeighborBtn_Click(object sender, EventArgs e)
        {

        }

        private void AllRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RandomRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
