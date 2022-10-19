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
    public partial class Form1 : Form
    {
        public Form1()
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
    }
}
