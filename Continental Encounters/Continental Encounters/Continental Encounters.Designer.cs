﻿namespace Continental_Encounters
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BaseMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContinentFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.ZoneGroupBox = new System.Windows.Forms.GroupBox();
            this.NewZoneBox = new System.Windows.Forms.GroupBox();
            this.RemoveZoneBtn = new System.Windows.Forms.Button();
            this.ZoneInput = new System.Windows.Forms.TextBox();
            this.AddZoneBtn = new System.Windows.Forms.Button();
            this.ZoneListBox = new System.Windows.Forms.ListBox();
            this.EncountersGroupBox = new System.Windows.Forms.GroupBox();
            this.NewEncounterBox = new System.Windows.Forms.GroupBox();
            this.RemoveEncounterBtn = new System.Windows.Forms.Button();
            this.EncounterInput = new System.Windows.Forms.TextBox();
            this.AddEncounterBtn = new System.Windows.Forms.Button();
            this.EncounterListBox = new System.Windows.Forms.ListBox();
            this.RoamersGroupBox = new System.Windows.Forms.GroupBox();
            this.NewRoamerBox = new System.Windows.Forms.GroupBox();
            this.RemoveRoamerBtn = new System.Windows.Forms.Button();
            this.RoamerInput = new System.Windows.Forms.TextBox();
            this.AddRoamerBtn = new System.Windows.Forms.Button();
            this.RoamerListBox = new System.Windows.Forms.ListBox();
            this.EnvironmentsGroupBox = new System.Windows.Forms.GroupBox();
            this.NewEnvironmentBox = new System.Windows.Forms.GroupBox();
            this.RemoveEnvironmentBtn = new System.Windows.Forms.Button();
            this.EnvironmentInput = new System.Windows.Forms.TextBox();
            this.AddEnvironmentBtn = new System.Windows.Forms.Button();
            this.EnvironmentListBox = new System.Windows.Forms.ListBox();
            this.NeighborsGroupBox = new System.Windows.Forms.GroupBox();
            this.NewNeighborBox = new System.Windows.Forms.GroupBox();
            this.RemoveNeighborBtn = new System.Windows.Forms.Button();
            this.NeighborInput = new System.Windows.Forms.TextBox();
            this.AddNeighborBtn = new System.Windows.Forms.Button();
            this.NeighborListBox = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.GeneratorGroupBox = new System.Windows.Forms.GroupBox();
            this.AddZoneTip = new System.Windows.Forms.ToolTip(this.components);
            this.RemoveZoneTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddEncounterTip = new System.Windows.Forms.ToolTip(this.components);
            this.RemoveEncounterTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddRoamerTip = new System.Windows.Forms.ToolTip(this.components);
            this.RemoveRoamerTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddEnvironmentTip = new System.Windows.Forms.ToolTip(this.components);
            this.RemoveEnvironmentTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddNeighborTip = new System.Windows.Forms.ToolTip(this.components);
            this.RemoveNeighborTip = new System.Windows.Forms.ToolTip(this.components);
            this.BaseMenuStrip.SuspendLayout();
            this.ContinentFlowLayout.SuspendLayout();
            this.ZoneGroupBox.SuspendLayout();
            this.NewZoneBox.SuspendLayout();
            this.EncountersGroupBox.SuspendLayout();
            this.NewEncounterBox.SuspendLayout();
            this.RoamersGroupBox.SuspendLayout();
            this.NewRoamerBox.SuspendLayout();
            this.EnvironmentsGroupBox.SuspendLayout();
            this.NewEnvironmentBox.SuspendLayout();
            this.NeighborsGroupBox.SuspendLayout();
            this.NewNeighborBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseMenuStrip
            // 
            this.BaseMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.BaseMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.BaseMenuStrip.Name = "BaseMenuStrip";
            this.BaseMenuStrip.Size = new System.Drawing.Size(1174, 24);
            this.BaseMenuStrip.TabIndex = 0;
            this.BaseMenuStrip.Text = "BaseMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // ContinentFlowLayout
            // 
            this.ContinentFlowLayout.Controls.Add(this.ZoneGroupBox);
            this.ContinentFlowLayout.Controls.Add(this.EncountersGroupBox);
            this.ContinentFlowLayout.Controls.Add(this.RoamersGroupBox);
            this.ContinentFlowLayout.Controls.Add(this.EnvironmentsGroupBox);
            this.ContinentFlowLayout.Controls.Add(this.NeighborsGroupBox);
            this.ContinentFlowLayout.Location = new System.Drawing.Point(3, 3);
            this.ContinentFlowLayout.Name = "ContinentFlowLayout";
            this.ContinentFlowLayout.Size = new System.Drawing.Size(1050, 315);
            this.ContinentFlowLayout.TabIndex = 1;
            // 
            // ZoneGroupBox
            // 
            this.ZoneGroupBox.Controls.Add(this.NewZoneBox);
            this.ZoneGroupBox.Controls.Add(this.ZoneListBox);
            this.ZoneGroupBox.Location = new System.Drawing.Point(3, 3);
            this.ZoneGroupBox.Name = "ZoneGroupBox";
            this.ZoneGroupBox.Size = new System.Drawing.Size(204, 306);
            this.ZoneGroupBox.TabIndex = 0;
            this.ZoneGroupBox.TabStop = false;
            this.ZoneGroupBox.Text = "Zones";
            // 
            // NewZoneBox
            // 
            this.NewZoneBox.Controls.Add(this.RemoveZoneBtn);
            this.NewZoneBox.Controls.Add(this.ZoneInput);
            this.NewZoneBox.Controls.Add(this.AddZoneBtn);
            this.NewZoneBox.Location = new System.Drawing.Point(10, 19);
            this.NewZoneBox.Name = "NewZoneBox";
            this.NewZoneBox.Size = new System.Drawing.Size(182, 45);
            this.NewZoneBox.TabIndex = 2;
            this.NewZoneBox.TabStop = false;
            this.NewZoneBox.Text = "New Zone";
            // 
            // RemoveZoneBtn
            // 
            this.RemoveZoneBtn.Location = new System.Drawing.Point(153, 17);
            this.RemoveZoneBtn.Name = "RemoveZoneBtn";
            this.RemoveZoneBtn.Size = new System.Drawing.Size(23, 23);
            this.RemoveZoneBtn.TabIndex = 2;
            this.RemoveZoneBtn.Text = "-";
            this.RemoveZoneBtn.UseVisualStyleBackColor = true;
            // 
            // ZoneInput
            // 
            this.ZoneInput.Location = new System.Drawing.Point(6, 19);
            this.ZoneInput.Name = "ZoneInput";
            this.ZoneInput.Size = new System.Drawing.Size(121, 20);
            this.ZoneInput.TabIndex = 0;
            // 
            // AddZoneBtn
            // 
            this.AddZoneBtn.Location = new System.Drawing.Point(131, 17);
            this.AddZoneBtn.Name = "AddZoneBtn";
            this.AddZoneBtn.Size = new System.Drawing.Size(23, 23);
            this.AddZoneBtn.TabIndex = 1;
            this.AddZoneBtn.Text = "+";
            this.AddZoneBtn.UseVisualStyleBackColor = true;
            // 
            // ZoneListBox
            // 
            this.ZoneListBox.FormattingEnabled = true;
            this.ZoneListBox.Location = new System.Drawing.Point(10, 70);
            this.ZoneListBox.Name = "ZoneListBox";
            this.ZoneListBox.Size = new System.Drawing.Size(182, 225);
            this.ZoneListBox.TabIndex = 1;
            // 
            // EncountersGroupBox
            // 
            this.EncountersGroupBox.Controls.Add(this.NewEncounterBox);
            this.EncountersGroupBox.Controls.Add(this.EncounterListBox);
            this.EncountersGroupBox.Location = new System.Drawing.Point(213, 3);
            this.EncountersGroupBox.Name = "EncountersGroupBox";
            this.EncountersGroupBox.Size = new System.Drawing.Size(204, 306);
            this.EncountersGroupBox.TabIndex = 1;
            this.EncountersGroupBox.TabStop = false;
            this.EncountersGroupBox.Text = "Encounters";
            // 
            // NewEncounterBox
            // 
            this.NewEncounterBox.Controls.Add(this.RemoveEncounterBtn);
            this.NewEncounterBox.Controls.Add(this.EncounterInput);
            this.NewEncounterBox.Controls.Add(this.AddEncounterBtn);
            this.NewEncounterBox.Location = new System.Drawing.Point(10, 19);
            this.NewEncounterBox.Name = "NewEncounterBox";
            this.NewEncounterBox.Size = new System.Drawing.Size(182, 45);
            this.NewEncounterBox.TabIndex = 2;
            this.NewEncounterBox.TabStop = false;
            this.NewEncounterBox.Text = "New Encounter";
            // 
            // RemoveEncounterBtn
            // 
            this.RemoveEncounterBtn.Location = new System.Drawing.Point(153, 17);
            this.RemoveEncounterBtn.Name = "RemoveEncounterBtn";
            this.RemoveEncounterBtn.Size = new System.Drawing.Size(23, 23);
            this.RemoveEncounterBtn.TabIndex = 2;
            this.RemoveEncounterBtn.Text = "-";
            this.RemoveEncounterBtn.UseVisualStyleBackColor = true;
            // 
            // EncounterInput
            // 
            this.EncounterInput.Location = new System.Drawing.Point(6, 19);
            this.EncounterInput.Name = "EncounterInput";
            this.EncounterInput.Size = new System.Drawing.Size(121, 20);
            this.EncounterInput.TabIndex = 0;
            // 
            // AddEncounterBtn
            // 
            this.AddEncounterBtn.Location = new System.Drawing.Point(131, 17);
            this.AddEncounterBtn.Name = "AddEncounterBtn";
            this.AddEncounterBtn.Size = new System.Drawing.Size(23, 23);
            this.AddEncounterBtn.TabIndex = 1;
            this.AddEncounterBtn.Text = "+";
            this.AddEncounterBtn.UseVisualStyleBackColor = true;
            // 
            // EncounterListBox
            // 
            this.EncounterListBox.FormattingEnabled = true;
            this.EncounterListBox.Location = new System.Drawing.Point(10, 70);
            this.EncounterListBox.Name = "EncounterListBox";
            this.EncounterListBox.Size = new System.Drawing.Size(182, 225);
            this.EncounterListBox.TabIndex = 1;
            // 
            // RoamersGroupBox
            // 
            this.RoamersGroupBox.Controls.Add(this.NewRoamerBox);
            this.RoamersGroupBox.Controls.Add(this.RoamerListBox);
            this.RoamersGroupBox.Location = new System.Drawing.Point(423, 3);
            this.RoamersGroupBox.Name = "RoamersGroupBox";
            this.RoamersGroupBox.Size = new System.Drawing.Size(204, 306);
            this.RoamersGroupBox.TabIndex = 2;
            this.RoamersGroupBox.TabStop = false;
            this.RoamersGroupBox.Text = "Roamers";
            // 
            // NewRoamerBox
            // 
            this.NewRoamerBox.Controls.Add(this.RemoveRoamerBtn);
            this.NewRoamerBox.Controls.Add(this.RoamerInput);
            this.NewRoamerBox.Controls.Add(this.AddRoamerBtn);
            this.NewRoamerBox.Location = new System.Drawing.Point(10, 19);
            this.NewRoamerBox.Name = "NewRoamerBox";
            this.NewRoamerBox.Size = new System.Drawing.Size(182, 45);
            this.NewRoamerBox.TabIndex = 2;
            this.NewRoamerBox.TabStop = false;
            this.NewRoamerBox.Text = "New Roamer";
            // 
            // RemoveRoamerBtn
            // 
            this.RemoveRoamerBtn.Location = new System.Drawing.Point(153, 17);
            this.RemoveRoamerBtn.Name = "RemoveRoamerBtn";
            this.RemoveRoamerBtn.Size = new System.Drawing.Size(23, 23);
            this.RemoveRoamerBtn.TabIndex = 2;
            this.RemoveRoamerBtn.Text = "-";
            this.RemoveRoamerBtn.UseVisualStyleBackColor = true;
            // 
            // RoamerInput
            // 
            this.RoamerInput.Location = new System.Drawing.Point(6, 19);
            this.RoamerInput.Name = "RoamerInput";
            this.RoamerInput.Size = new System.Drawing.Size(121, 20);
            this.RoamerInput.TabIndex = 0;
            // 
            // AddRoamerBtn
            // 
            this.AddRoamerBtn.Location = new System.Drawing.Point(131, 17);
            this.AddRoamerBtn.Name = "AddRoamerBtn";
            this.AddRoamerBtn.Size = new System.Drawing.Size(23, 23);
            this.AddRoamerBtn.TabIndex = 1;
            this.AddRoamerBtn.Text = "+";
            this.AddRoamerBtn.UseVisualStyleBackColor = true;
            // 
            // RoamerListBox
            // 
            this.RoamerListBox.FormattingEnabled = true;
            this.RoamerListBox.Location = new System.Drawing.Point(10, 70);
            this.RoamerListBox.Name = "RoamerListBox";
            this.RoamerListBox.Size = new System.Drawing.Size(182, 225);
            this.RoamerListBox.TabIndex = 1;
            // 
            // EnvironmentsGroupBox
            // 
            this.EnvironmentsGroupBox.Controls.Add(this.NewEnvironmentBox);
            this.EnvironmentsGroupBox.Controls.Add(this.EnvironmentListBox);
            this.EnvironmentsGroupBox.Location = new System.Drawing.Point(633, 3);
            this.EnvironmentsGroupBox.Name = "EnvironmentsGroupBox";
            this.EnvironmentsGroupBox.Size = new System.Drawing.Size(204, 306);
            this.EnvironmentsGroupBox.TabIndex = 3;
            this.EnvironmentsGroupBox.TabStop = false;
            this.EnvironmentsGroupBox.Text = "Environments";
            // 
            // NewEnvironmentBox
            // 
            this.NewEnvironmentBox.Controls.Add(this.RemoveEnvironmentBtn);
            this.NewEnvironmentBox.Controls.Add(this.EnvironmentInput);
            this.NewEnvironmentBox.Controls.Add(this.AddEnvironmentBtn);
            this.NewEnvironmentBox.Location = new System.Drawing.Point(10, 19);
            this.NewEnvironmentBox.Name = "NewEnvironmentBox";
            this.NewEnvironmentBox.Size = new System.Drawing.Size(182, 45);
            this.NewEnvironmentBox.TabIndex = 2;
            this.NewEnvironmentBox.TabStop = false;
            this.NewEnvironmentBox.Text = "New Environment";
            // 
            // RemoveEnvironmentBtn
            // 
            this.RemoveEnvironmentBtn.Location = new System.Drawing.Point(153, 17);
            this.RemoveEnvironmentBtn.Name = "RemoveEnvironmentBtn";
            this.RemoveEnvironmentBtn.Size = new System.Drawing.Size(23, 23);
            this.RemoveEnvironmentBtn.TabIndex = 2;
            this.RemoveEnvironmentBtn.Text = "-";
            this.RemoveEnvironmentBtn.UseVisualStyleBackColor = true;
            // 
            // EnvironmentInput
            // 
            this.EnvironmentInput.Location = new System.Drawing.Point(6, 19);
            this.EnvironmentInput.Name = "EnvironmentInput";
            this.EnvironmentInput.Size = new System.Drawing.Size(121, 20);
            this.EnvironmentInput.TabIndex = 0;
            // 
            // AddEnvironmentBtn
            // 
            this.AddEnvironmentBtn.Location = new System.Drawing.Point(131, 17);
            this.AddEnvironmentBtn.Name = "AddEnvironmentBtn";
            this.AddEnvironmentBtn.Size = new System.Drawing.Size(23, 23);
            this.AddEnvironmentBtn.TabIndex = 1;
            this.AddEnvironmentBtn.Text = "+";
            this.AddEnvironmentBtn.UseVisualStyleBackColor = true;
            // 
            // EnvironmentListBox
            // 
            this.EnvironmentListBox.FormattingEnabled = true;
            this.EnvironmentListBox.Location = new System.Drawing.Point(10, 70);
            this.EnvironmentListBox.Name = "EnvironmentListBox";
            this.EnvironmentListBox.Size = new System.Drawing.Size(182, 225);
            this.EnvironmentListBox.TabIndex = 1;
            // 
            // NeighborsGroupBox
            // 
            this.NeighborsGroupBox.Controls.Add(this.NewNeighborBox);
            this.NeighborsGroupBox.Controls.Add(this.NeighborListBox);
            this.NeighborsGroupBox.Location = new System.Drawing.Point(843, 3);
            this.NeighborsGroupBox.Name = "NeighborsGroupBox";
            this.NeighborsGroupBox.Size = new System.Drawing.Size(204, 306);
            this.NeighborsGroupBox.TabIndex = 4;
            this.NeighborsGroupBox.TabStop = false;
            this.NeighborsGroupBox.Text = "Neighbors";
            // 
            // NewNeighborBox
            // 
            this.NewNeighborBox.Controls.Add(this.RemoveNeighborBtn);
            this.NewNeighborBox.Controls.Add(this.NeighborInput);
            this.NewNeighborBox.Controls.Add(this.AddNeighborBtn);
            this.NewNeighborBox.Location = new System.Drawing.Point(10, 19);
            this.NewNeighborBox.Name = "NewNeighborBox";
            this.NewNeighborBox.Size = new System.Drawing.Size(182, 45);
            this.NewNeighborBox.TabIndex = 2;
            this.NewNeighborBox.TabStop = false;
            this.NewNeighborBox.Text = "New Neighbor";
            // 
            // RemoveNeighborBtn
            // 
            this.RemoveNeighborBtn.Location = new System.Drawing.Point(153, 17);
            this.RemoveNeighborBtn.Name = "RemoveNeighborBtn";
            this.RemoveNeighborBtn.Size = new System.Drawing.Size(23, 23);
            this.RemoveNeighborBtn.TabIndex = 2;
            this.RemoveNeighborBtn.Text = "-";
            this.RemoveNeighborBtn.UseVisualStyleBackColor = true;
            // 
            // NeighborInput
            // 
            this.NeighborInput.Location = new System.Drawing.Point(6, 19);
            this.NeighborInput.Name = "NeighborInput";
            this.NeighborInput.Size = new System.Drawing.Size(121, 20);
            this.NeighborInput.TabIndex = 0;
            // 
            // AddNeighborBtn
            // 
            this.AddNeighborBtn.Location = new System.Drawing.Point(131, 17);
            this.AddNeighborBtn.Name = "AddNeighborBtn";
            this.AddNeighborBtn.Size = new System.Drawing.Size(23, 23);
            this.AddNeighborBtn.TabIndex = 1;
            this.AddNeighborBtn.Text = "+";
            this.AddNeighborBtn.UseVisualStyleBackColor = true;
            // 
            // NeighborListBox
            // 
            this.NeighborListBox.FormattingEnabled = true;
            this.NeighborListBox.Location = new System.Drawing.Point(10, 70);
            this.NeighborListBox.Name = "NeighborListBox";
            this.NeighborListBox.Size = new System.Drawing.Size(182, 225);
            this.NeighborListBox.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ContinentFlowLayout);
            this.flowLayoutPanel1.Controls.Add(this.GeneratorGroupBox);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1056, 470);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // GeneratorGroupBox
            // 
            this.GeneratorGroupBox.Location = new System.Drawing.Point(3, 324);
            this.GeneratorGroupBox.Name = "GeneratorGroupBox";
            this.GeneratorGroupBox.Size = new System.Drawing.Size(1050, 140);
            this.GeneratorGroupBox.TabIndex = 2;
            this.GeneratorGroupBox.TabStop = false;
            this.GeneratorGroupBox.Text = "EncounterGenerator";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 554);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.BaseMenuStrip);
            this.MainMenuStrip = this.BaseMenuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.BaseMenuStrip.ResumeLayout(false);
            this.BaseMenuStrip.PerformLayout();
            this.ContinentFlowLayout.ResumeLayout(false);
            this.ZoneGroupBox.ResumeLayout(false);
            this.NewZoneBox.ResumeLayout(false);
            this.NewZoneBox.PerformLayout();
            this.EncountersGroupBox.ResumeLayout(false);
            this.NewEncounterBox.ResumeLayout(false);
            this.NewEncounterBox.PerformLayout();
            this.RoamersGroupBox.ResumeLayout(false);
            this.NewRoamerBox.ResumeLayout(false);
            this.NewRoamerBox.PerformLayout();
            this.EnvironmentsGroupBox.ResumeLayout(false);
            this.NewEnvironmentBox.ResumeLayout(false);
            this.NewEnvironmentBox.PerformLayout();
            this.NeighborsGroupBox.ResumeLayout(false);
            this.NewNeighborBox.ResumeLayout(false);
            this.NewNeighborBox.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip BaseMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel ContinentFlowLayout;
        private System.Windows.Forms.GroupBox ZoneGroupBox;
        private System.Windows.Forms.GroupBox NewZoneBox;
        private System.Windows.Forms.Button RemoveZoneBtn;
        private System.Windows.Forms.TextBox ZoneInput;
        private System.Windows.Forms.Button AddZoneBtn;
        private System.Windows.Forms.ListBox ZoneListBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox GeneratorGroupBox;
        private System.Windows.Forms.ToolTip AddZoneTip;
        private System.Windows.Forms.ToolTip RemoveZoneTip;
        private System.Windows.Forms.GroupBox EncountersGroupBox;
        private System.Windows.Forms.GroupBox NewEncounterBox;
        private System.Windows.Forms.Button RemoveEncounterBtn;
        private System.Windows.Forms.TextBox EncounterInput;
        private System.Windows.Forms.Button AddEncounterBtn;
        private System.Windows.Forms.ListBox EncounterListBox;
        private System.Windows.Forms.GroupBox RoamersGroupBox;
        private System.Windows.Forms.GroupBox NewRoamerBox;
        private System.Windows.Forms.Button RemoveRoamerBtn;
        private System.Windows.Forms.TextBox RoamerInput;
        private System.Windows.Forms.Button AddRoamerBtn;
        private System.Windows.Forms.ListBox RoamerListBox;
        private System.Windows.Forms.GroupBox EnvironmentsGroupBox;
        private System.Windows.Forms.GroupBox NewEnvironmentBox;
        private System.Windows.Forms.Button RemoveEnvironmentBtn;
        private System.Windows.Forms.TextBox EnvironmentInput;
        private System.Windows.Forms.Button AddEnvironmentBtn;
        private System.Windows.Forms.ListBox EnvironmentListBox;
        private System.Windows.Forms.GroupBox NeighborsGroupBox;
        private System.Windows.Forms.GroupBox NewNeighborBox;
        private System.Windows.Forms.Button RemoveNeighborBtn;
        private System.Windows.Forms.TextBox NeighborInput;
        private System.Windows.Forms.Button AddNeighborBtn;
        private System.Windows.Forms.ListBox NeighborListBox;
        private System.Windows.Forms.ToolTip AddEncounterTip;
        private System.Windows.Forms.ToolTip RemoveEncounterTip;
        private System.Windows.Forms.ToolTip AddRoamerTip;
        private System.Windows.Forms.ToolTip RemoveRoamerTip;
        private System.Windows.Forms.ToolTip AddEnvironmentTip;
        private System.Windows.Forms.ToolTip RemoveEnvironmentTip;
        private System.Windows.Forms.ToolTip AddNeighborTip;
        private System.Windows.Forms.ToolTip RemoveNeighborTip;
    }
}

