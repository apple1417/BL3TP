namespace CarWarpHelper {
  partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.notHookedLabel = new System.Windows.Forms.Label();
      this.xInput = new System.Windows.Forms.NumericUpDown();
      this.yInput = new System.Windows.Forms.NumericUpDown();
      this.zInput = new System.Windows.Forms.NumericUpDown();
      this.zLock = new System.Windows.Forms.CheckBox();
      this.xLock = new System.Windows.Forms.CheckBox();
      this.yLock = new System.Windows.Forms.CheckBox();
      this.positionTable = new System.Windows.Forms.TableLayoutPanel();
      this.positionLabel = new System.Windows.Forms.Label();
      this.lockLabel = new System.Windows.Forms.Label();
      this.prevMapButton = new System.Windows.Forms.Button();
      this.nextMapButton = new System.Windows.Forms.Button();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.mapLabel = new System.Windows.Forms.Label();
      this.nextStationButton = new System.Windows.Forms.Button();
      this.stationLabel = new System.Windows.Forms.Label();
      this.prevStationButton = new System.Windows.Forms.Button();
      this.autoTeleportBox = new System.Windows.Forms.CheckBox();
      this.locationHeader = new System.Windows.Forms.Label();
      this.teleportButton = new System.Windows.Forms.Button();
      this.savePosButtton = new System.Windows.Forms.Button();
      this.loadPosButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.xInput)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.yInput)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.zInput)).BeginInit();
      this.positionTable.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // notHookedLabel
      // 
      this.notHookedLabel.BackColor = System.Drawing.Color.Crimson;
      this.notHookedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.notHookedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.notHookedLabel.ForeColor = System.Drawing.Color.White;
      this.notHookedLabel.Location = new System.Drawing.Point(0, 0);
      this.notHookedLabel.Name = "notHookedLabel";
      this.notHookedLabel.Size = new System.Drawing.Size(219, 254);
      this.notHookedLabel.TabIndex = 28;
      this.notHookedLabel.Text = "Not Hooked";
      this.notHookedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.notHookedLabel.Visible = false;
      // 
      // xInput
      // 
      this.xInput.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.xInput.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.xInput.Location = new System.Drawing.Point(3, 18);
      this.xInput.Name = "xInput";
      this.xInput.Size = new System.Drawing.Size(150, 20);
      this.xInput.TabIndex = 0;
      this.xInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.xInput.ValueChanged += new System.EventHandler(this.Position_ValueChanged);
      this.xInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Position_KeyDown);
      // 
      // yInput
      // 
      this.yInput.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.yInput.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.yInput.Location = new System.Drawing.Point(3, 44);
      this.yInput.Name = "yInput";
      this.yInput.Size = new System.Drawing.Size(150, 20);
      this.yInput.TabIndex = 8;
      this.yInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.yInput.ValueChanged += new System.EventHandler(this.Position_ValueChanged);
      this.yInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Position_KeyDown);
      // 
      // zInput
      // 
      this.zInput.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.zInput.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.zInput.Location = new System.Drawing.Point(3, 70);
      this.zInput.Name = "zInput";
      this.zInput.Size = new System.Drawing.Size(150, 20);
      this.zInput.TabIndex = 9;
      this.zInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.zInput.ValueChanged += new System.EventHandler(this.Position_ValueChanged);
      this.zInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Position_KeyDown);
      // 
      // zLock
      // 
      this.zLock.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.zLock.AutoSize = true;
      this.zLock.Location = new System.Drawing.Point(168, 73);
      this.zLock.Name = "zLock";
      this.zLock.Size = new System.Drawing.Size(15, 14);
      this.zLock.TabIndex = 14;
      this.zLock.UseVisualStyleBackColor = true;
      // 
      // xLock
      // 
      this.xLock.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.xLock.AutoSize = true;
      this.xLock.Location = new System.Drawing.Point(168, 21);
      this.xLock.Name = "xLock";
      this.xLock.Size = new System.Drawing.Size(15, 14);
      this.xLock.TabIndex = 15;
      this.xLock.UseVisualStyleBackColor = true;
      // 
      // yLock
      // 
      this.yLock.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.yLock.AutoSize = true;
      this.yLock.Location = new System.Drawing.Point(168, 47);
      this.yLock.Name = "yLock";
      this.yLock.Size = new System.Drawing.Size(15, 14);
      this.yLock.TabIndex = 16;
      this.yLock.UseVisualStyleBackColor = true;
      // 
      // positionTable
      // 
      this.positionTable.AutoSize = true;
      this.positionTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.positionTable.ColumnCount = 2;
      this.positionTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.positionTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.positionTable.Controls.Add(this.positionLabel, 0, 0);
      this.positionTable.Controls.Add(this.zLock, 1, 3);
      this.positionTable.Controls.Add(this.yLock, 1, 2);
      this.positionTable.Controls.Add(this.lockLabel, 1, 0);
      this.positionTable.Controls.Add(this.xLock, 1, 1);
      this.positionTable.Controls.Add(this.zInput, 0, 3);
      this.positionTable.Controls.Add(this.xInput, 0, 1);
      this.positionTable.Controls.Add(this.yInput, 0, 2);
      this.positionTable.Location = new System.Drawing.Point(12, 12);
      this.positionTable.Name = "positionTable";
      this.positionTable.RowCount = 4;
      this.positionTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.positionTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.positionTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.positionTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.positionTable.Size = new System.Drawing.Size(195, 93);
      this.positionTable.TabIndex = 20;
      // 
      // positionLabel
      // 
      this.positionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.positionLabel.AutoSize = true;
      this.positionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.positionLabel.Location = new System.Drawing.Point(52, 0);
      this.positionLabel.Name = "positionLabel";
      this.positionLabel.Size = new System.Drawing.Size(51, 15);
      this.positionLabel.TabIndex = 0;
      this.positionLabel.Text = "Position";
      // 
      // lockLabel
      // 
      this.lockLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.lockLabel.AutoSize = true;
      this.lockLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lockLabel.Location = new System.Drawing.Point(159, 0);
      this.lockLabel.Name = "lockLabel";
      this.lockLabel.Size = new System.Drawing.Size(33, 15);
      this.lockLabel.TabIndex = 1;
      this.lockLabel.Text = "Lock";
      // 
      // prevMapButton
      // 
      this.prevMapButton.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.prevMapButton.Location = new System.Drawing.Point(3, 3);
      this.prevMapButton.Name = "prevMapButton";
      this.prevMapButton.Size = new System.Drawing.Size(23, 23);
      this.prevMapButton.TabIndex = 21;
      this.prevMapButton.Text = "<";
      this.prevMapButton.UseVisualStyleBackColor = true;
      this.prevMapButton.Click += new System.EventHandler(this.PrevMapButton_Click);
      // 
      // nextMapButton
      // 
      this.nextMapButton.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.nextMapButton.Location = new System.Drawing.Point(169, 3);
      this.nextMapButton.Name = "nextMapButton";
      this.nextMapButton.Size = new System.Drawing.Size(23, 23);
      this.nextMapButton.TabIndex = 22;
      this.nextMapButton.Text = ">";
      this.nextMapButton.UseVisualStyleBackColor = true;
      this.nextMapButton.Click += new System.EventHandler(this.NextMapButton_Click);
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.AutoSize = true;
      this.tableLayoutPanel2.ColumnCount = 3;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.Controls.Add(this.mapLabel, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.prevMapButton, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.nextMapButton, 2, 0);
      this.tableLayoutPanel2.Controls.Add(this.nextStationButton, 2, 1);
      this.tableLayoutPanel2.Controls.Add(this.stationLabel, 1, 1);
      this.tableLayoutPanel2.Controls.Add(this.prevStationButton, 0, 1);
      this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 155);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel2.Size = new System.Drawing.Size(195, 58);
      this.tableLayoutPanel2.TabIndex = 24;
      // 
      // mapLabel
      // 
      this.mapLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.mapLabel.AutoSize = true;
      this.mapLabel.Location = new System.Drawing.Point(83, 8);
      this.mapLabel.Name = "mapLabel";
      this.mapLabel.Size = new System.Drawing.Size(28, 13);
      this.mapLabel.TabIndex = 23;
      this.mapLabel.Text = "Map";
      this.mapLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // nextStationButton
      // 
      this.nextStationButton.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.nextStationButton.Location = new System.Drawing.Point(169, 32);
      this.nextStationButton.Name = "nextStationButton";
      this.nextStationButton.Size = new System.Drawing.Size(23, 23);
      this.nextStationButton.TabIndex = 24;
      this.nextStationButton.Text = ">";
      this.nextStationButton.UseVisualStyleBackColor = true;
      this.nextStationButton.Click += new System.EventHandler(this.NextStationButton_Click);
      // 
      // stationLabel
      // 
      this.stationLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.stationLabel.AutoSize = true;
      this.stationLabel.Location = new System.Drawing.Point(74, 37);
      this.stationLabel.Name = "stationLabel";
      this.stationLabel.Size = new System.Drawing.Size(47, 13);
      this.stationLabel.TabIndex = 25;
      this.stationLabel.Text = "Terminal";
      this.stationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // prevStationButton
      // 
      this.prevStationButton.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.prevStationButton.Location = new System.Drawing.Point(3, 32);
      this.prevStationButton.Name = "prevStationButton";
      this.prevStationButton.Size = new System.Drawing.Size(23, 23);
      this.prevStationButton.TabIndex = 26;
      this.prevStationButton.Text = "<";
      this.prevStationButton.UseVisualStyleBackColor = true;
      this.prevStationButton.Click += new System.EventHandler(this.PrevStationButton_Click);
      // 
      // autoTeleportBox
      // 
      this.autoTeleportBox.AutoSize = true;
      this.autoTeleportBox.Location = new System.Drawing.Point(159, 223);
      this.autoTeleportBox.Name = "autoTeleportBox";
      this.autoTeleportBox.Size = new System.Drawing.Size(48, 17);
      this.autoTeleportBox.TabIndex = 25;
      this.autoTeleportBox.Text = "Auto";
      this.autoTeleportBox.UseVisualStyleBackColor = true;
      // 
      // locationHeader
      // 
      this.locationHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.locationHeader.Location = new System.Drawing.Point(12, 137);
      this.locationHeader.Name = "locationHeader";
      this.locationHeader.Size = new System.Drawing.Size(195, 15);
      this.locationHeader.TabIndex = 26;
      this.locationHeader.Text = "Catch-A-Rides";
      this.locationHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // teleportButton
      // 
      this.teleportButton.Location = new System.Drawing.Point(12, 219);
      this.teleportButton.Name = "teleportButton";
      this.teleportButton.Size = new System.Drawing.Size(141, 23);
      this.teleportButton.TabIndex = 27;
      this.teleportButton.Text = "Teleport";
      this.teleportButton.UseVisualStyleBackColor = true;
      this.teleportButton.Click += new System.EventHandler(this.TeleportButton_Click);
      // 
      // savePosButtton
      // 
      this.savePosButtton.Location = new System.Drawing.Point(12, 111);
      this.savePosButtton.Name = "savePosButtton";
      this.savePosButtton.Size = new System.Drawing.Size(94, 23);
      this.savePosButtton.TabIndex = 29;
      this.savePosButtton.Text = "Save";
      this.savePosButtton.UseVisualStyleBackColor = true;
      this.savePosButtton.Click += new System.EventHandler(this.SavePosButtton_Click);
      // 
      // loadPosButton
      // 
      this.loadPosButton.Enabled = false;
      this.loadPosButton.Location = new System.Drawing.Point(113, 111);
      this.loadPosButton.Name = "loadPosButton";
      this.loadPosButton.Size = new System.Drawing.Size(94, 23);
      this.loadPosButton.TabIndex = 30;
      this.loadPosButton.Text = "Load";
      this.loadPosButton.UseVisualStyleBackColor = true;
      this.loadPosButton.Click += new System.EventHandler(this.LoadPosButton_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(219, 254);
      this.Controls.Add(this.loadPosButton);
      this.Controls.Add(this.savePosButtton);
      this.Controls.Add(this.teleportButton);
      this.Controls.Add(this.locationHeader);
      this.Controls.Add(this.autoTeleportBox);
      this.Controls.Add(this.tableLayoutPanel2);
      this.Controls.Add(this.positionTable);
      this.Controls.Add(this.notHookedLabel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.Text = "Car Warp Helper";
      ((System.ComponentModel.ISupportInitialize)(this.xInput)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.yInput)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.zInput)).EndInit();
      this.positionTable.ResumeLayout(false);
      this.positionTable.PerformLayout();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion


        private System.Windows.Forms.Label notHookedLabel;
        private System.Windows.Forms.TableLayoutPanel positionTable;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Label lockLabel;
        private System.Windows.Forms.Button prevMapButton;
        private System.Windows.Forms.Button nextMapButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label mapLabel;
        private System.Windows.Forms.Button nextStationButton;
        private System.Windows.Forms.Label stationLabel;
        private System.Windows.Forms.Button prevStationButton;
        private System.Windows.Forms.Label locationHeader;
        private System.Windows.Forms.Button teleportButton;
    private System.Windows.Forms.Button savePosButtton;
    private System.Windows.Forms.Button loadPosButton;
        internal System.Windows.Forms.CheckBox zLock;
        internal System.Windows.Forms.CheckBox xLock;
        internal System.Windows.Forms.CheckBox yLock;
        internal System.Windows.Forms.CheckBox autoTeleportBox;
        private System.Windows.Forms.NumericUpDown xInput;
        private System.Windows.Forms.NumericUpDown yInput;
        private System.Windows.Forms.NumericUpDown zInput;
    }
}

