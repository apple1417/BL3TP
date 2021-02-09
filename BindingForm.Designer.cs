namespace BL3TP {
  partial class BindingForm {
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
      this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.lockBox = new BL3TP.KeybindBox();
      this.lockLabel = new System.Windows.Forms.Label();
      this.prevMapBox = new BL3TP.KeybindBox();
      this.loadPosBox = new BL3TP.KeybindBox();
      this.savePosLabel = new System.Windows.Forms.Label();
      this.savePosBox = new BL3TP.KeybindBox();
      this.nextMapBox = new BL3TP.KeybindBox();
      this.prevMapLabel = new System.Windows.Forms.Label();
      this.loadPosLabel = new System.Windows.Forms.Label();
      this.nextMapLabel = new System.Windows.Forms.Label();
      this.teleportBox = new BL3TP.KeybindBox();
      this.nextStationBox = new BL3TP.KeybindBox();
      this.prevStationBox = new BL3TP.KeybindBox();
      this.autoBox = new BL3TP.KeybindBox();
      this.teleportLabel = new System.Windows.Forms.Label();
      this.nextStationLabel = new System.Windows.Forms.Label();
      this.prevStationLabel = new System.Windows.Forms.Label();
      this.autoLabel = new System.Windows.Forms.Label();
      this.tableLayoutPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel
      // 
      this.tableLayoutPanel.AutoSize = true;
      this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel.ColumnCount = 2;
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel.Controls.Add(this.lockBox, 1, 6);
      this.tableLayoutPanel.Controls.Add(this.autoBox, 1, 7);
      this.tableLayoutPanel.Controls.Add(this.autoLabel, 0, 7);
      this.tableLayoutPanel.Controls.Add(this.lockLabel, 0, 6);
      this.tableLayoutPanel.Controls.Add(this.loadPosBox, 1, 1);
      this.tableLayoutPanel.Controls.Add(this.savePosLabel, 0, 0);
      this.tableLayoutPanel.Controls.Add(this.savePosBox, 1, 0);
      this.tableLayoutPanel.Controls.Add(this.loadPosLabel, 0, 1);
      this.tableLayoutPanel.Controls.Add(this.teleportBox, 1, 8);
      this.tableLayoutPanel.Controls.Add(this.teleportLabel, 0, 8);
      this.tableLayoutPanel.Controls.Add(this.prevMapLabel, 0, 2);
      this.tableLayoutPanel.Controls.Add(this.nextMapLabel, 0, 3);
      this.tableLayoutPanel.Controls.Add(this.prevStationLabel, 0, 4);
      this.tableLayoutPanel.Controls.Add(this.nextStationLabel, 0, 5);
      this.tableLayoutPanel.Controls.Add(this.prevMapBox, 1, 2);
      this.tableLayoutPanel.Controls.Add(this.nextMapBox, 1, 3);
      this.tableLayoutPanel.Controls.Add(this.prevStationBox, 1, 4);
      this.tableLayoutPanel.Controls.Add(this.nextStationBox, 1, 5);
      this.tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
      this.tableLayoutPanel.Name = "tableLayoutPanel";
      this.tableLayoutPanel.RowCount = 9;
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel.Size = new System.Drawing.Size(203, 234);
      this.tableLayoutPanel.TabIndex = 0;
      // 
      // lockBox
      // 
      this.lockBox.BackColor = System.Drawing.SystemColors.Control;
      this.lockBox.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.lockBox.Keys = System.Windows.Forms.Keys.None;
      this.lockBox.Location = new System.Drawing.Point(100, 159);
      this.lockBox.Name = "lockBox";
      this.lockBox.ReadOnly = true;
      this.lockBox.Size = new System.Drawing.Size(100, 20);
      this.lockBox.TabIndex = 17;
      this.lockBox.Text = "None";
      // 
      // lockLabel
      // 
      this.lockLabel.AutoSize = true;
      this.lockLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lockLabel.Location = new System.Drawing.Point(3, 156);
      this.lockLabel.Name = "lockLabel";
      this.lockLabel.Size = new System.Drawing.Size(91, 26);
      this.lockLabel.TabIndex = 16;
      this.lockLabel.Text = "Toggle Pos Lock";
      this.lockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // prevMapBox
      // 
      this.prevMapBox.BackColor = System.Drawing.SystemColors.Control;
      this.prevMapBox.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.prevMapBox.Keys = System.Windows.Forms.Keys.None;
      this.prevMapBox.Location = new System.Drawing.Point(100, 55);
      this.prevMapBox.Name = "prevMapBox";
      this.prevMapBox.ReadOnly = true;
      this.prevMapBox.Size = new System.Drawing.Size(100, 20);
      this.prevMapBox.TabIndex = 12;
      this.prevMapBox.Text = "None";
      // 
      // loadPosBox
      // 
      this.loadPosBox.BackColor = System.Drawing.SystemColors.Control;
      this.loadPosBox.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.loadPosBox.Keys = System.Windows.Forms.Keys.None;
      this.loadPosBox.Location = new System.Drawing.Point(100, 29);
      this.loadPosBox.Name = "loadPosBox";
      this.loadPosBox.ReadOnly = true;
      this.loadPosBox.Size = new System.Drawing.Size(100, 20);
      this.loadPosBox.TabIndex = 10;
      this.loadPosBox.Text = "None";
      // 
      // savePosLabel
      // 
      this.savePosLabel.AutoSize = true;
      this.savePosLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.savePosLabel.Location = new System.Drawing.Point(3, 0);
      this.savePosLabel.Name = "savePosLabel";
      this.savePosLabel.Size = new System.Drawing.Size(91, 26);
      this.savePosLabel.TabIndex = 0;
      this.savePosLabel.Text = "Save Position";
      this.savePosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // savePosBox
      // 
      this.savePosBox.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.savePosBox.Keys = System.Windows.Forms.Keys.None;
      this.savePosBox.Location = new System.Drawing.Point(100, 3);
      this.savePosBox.Name = "savePosBox";
      this.savePosBox.ReadOnly = true;
      this.savePosBox.Size = new System.Drawing.Size(100, 20);
      this.savePosBox.TabIndex = 8;
      this.savePosBox.Text = "None";
      // 
      // nextMapBox
      // 
      this.nextMapBox.BackColor = System.Drawing.SystemColors.Control;
      this.nextMapBox.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.nextMapBox.Keys = System.Windows.Forms.Keys.None;
      this.nextMapBox.Location = new System.Drawing.Point(100, 81);
      this.nextMapBox.Name = "nextMapBox";
      this.nextMapBox.ReadOnly = true;
      this.nextMapBox.Size = new System.Drawing.Size(100, 20);
      this.nextMapBox.TabIndex = 9;
      this.nextMapBox.Text = "None";
      // 
      // prevMapLabel
      // 
      this.prevMapLabel.AutoSize = true;
      this.prevMapLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.prevMapLabel.Location = new System.Drawing.Point(3, 52);
      this.prevMapLabel.Name = "prevMapLabel";
      this.prevMapLabel.Size = new System.Drawing.Size(91, 26);
      this.prevMapLabel.TabIndex = 1;
      this.prevMapLabel.Text = "Previous Map";
      this.prevMapLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // loadPosLabel
      // 
      this.loadPosLabel.AutoSize = true;
      this.loadPosLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.loadPosLabel.Location = new System.Drawing.Point(3, 26);
      this.loadPosLabel.Name = "loadPosLabel";
      this.loadPosLabel.Size = new System.Drawing.Size(91, 26);
      this.loadPosLabel.TabIndex = 4;
      this.loadPosLabel.Text = "Load Position";
      this.loadPosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // nextMapLabel
      // 
      this.nextMapLabel.AutoSize = true;
      this.nextMapLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nextMapLabel.Location = new System.Drawing.Point(3, 78);
      this.nextMapLabel.Name = "nextMapLabel";
      this.nextMapLabel.Size = new System.Drawing.Size(91, 26);
      this.nextMapLabel.TabIndex = 5;
      this.nextMapLabel.Text = "Next Map";
      this.nextMapLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // teleportBox
      // 
      this.teleportBox.BackColor = System.Drawing.SystemColors.Control;
      this.teleportBox.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.teleportBox.Keys = System.Windows.Forms.Keys.None;
      this.teleportBox.Location = new System.Drawing.Point(100, 211);
      this.teleportBox.Name = "teleportBox";
      this.teleportBox.ReadOnly = true;
      this.teleportBox.Size = new System.Drawing.Size(100, 20);
      this.teleportBox.TabIndex = 15;
      this.teleportBox.Text = "None";
      // 
      // nextStationBox
      // 
      this.nextStationBox.BackColor = System.Drawing.SystemColors.Control;
      this.nextStationBox.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.nextStationBox.Keys = System.Windows.Forms.Keys.None;
      this.nextStationBox.Location = new System.Drawing.Point(100, 133);
      this.nextStationBox.Name = "nextStationBox";
      this.nextStationBox.ReadOnly = true;
      this.nextStationBox.Size = new System.Drawing.Size(100, 20);
      this.nextStationBox.TabIndex = 13;
      this.nextStationBox.Text = "None";
      // 
      // prevStationBox
      // 
      this.prevStationBox.BackColor = System.Drawing.SystemColors.Control;
      this.prevStationBox.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.prevStationBox.Keys = System.Windows.Forms.Keys.None;
      this.prevStationBox.Location = new System.Drawing.Point(100, 107);
      this.prevStationBox.Name = "prevStationBox";
      this.prevStationBox.ReadOnly = true;
      this.prevStationBox.Size = new System.Drawing.Size(100, 20);
      this.prevStationBox.TabIndex = 11;
      this.prevStationBox.Text = "None";
      // 
      // autoBox
      // 
      this.autoBox.BackColor = System.Drawing.SystemColors.Control;
      this.autoBox.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.autoBox.Keys = System.Windows.Forms.Keys.None;
      this.autoBox.Location = new System.Drawing.Point(100, 185);
      this.autoBox.Name = "autoBox";
      this.autoBox.ReadOnly = true;
      this.autoBox.Size = new System.Drawing.Size(100, 20);
      this.autoBox.TabIndex = 14;
      this.autoBox.Text = "None";
      // 
      // teleportLabel
      // 
      this.teleportLabel.AutoSize = true;
      this.teleportLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.teleportLabel.Location = new System.Drawing.Point(3, 208);
      this.teleportLabel.Name = "teleportLabel";
      this.teleportLabel.Size = new System.Drawing.Size(91, 26);
      this.teleportLabel.TabIndex = 3;
      this.teleportLabel.Text = "Teleport";
      this.teleportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // nextStationLabel
      // 
      this.nextStationLabel.AutoSize = true;
      this.nextStationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nextStationLabel.Location = new System.Drawing.Point(3, 130);
      this.nextStationLabel.Name = "nextStationLabel";
      this.nextStationLabel.Size = new System.Drawing.Size(91, 26);
      this.nextStationLabel.TabIndex = 6;
      this.nextStationLabel.Text = "Next Terminal";
      this.nextStationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // prevStationLabel
      // 
      this.prevStationLabel.AutoSize = true;
      this.prevStationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.prevStationLabel.Location = new System.Drawing.Point(3, 104);
      this.prevStationLabel.Name = "prevStationLabel";
      this.prevStationLabel.Size = new System.Drawing.Size(91, 26);
      this.prevStationLabel.TabIndex = 2;
      this.prevStationLabel.Text = "Previous Terminal";
      this.prevStationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // autoLabel
      // 
      this.autoLabel.AutoSize = true;
      this.autoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.autoLabel.Location = new System.Drawing.Point(3, 182);
      this.autoLabel.Name = "autoLabel";
      this.autoLabel.Size = new System.Drawing.Size(91, 26);
      this.autoLabel.TabIndex = 7;
      this.autoLabel.Text = "Toggle Auto-TP";
      this.autoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // BindingForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(227, 258);
      this.Controls.Add(this.tableLayoutPanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "BindingForm";
      this.Text = "Configure Keybinds";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BindingForm_FormClosing);
      this.tableLayoutPanel.ResumeLayout(false);
      this.tableLayoutPanel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label savePosLabel;
        private System.Windows.Forms.Label prevMapLabel;
        private System.Windows.Forms.Label prevStationLabel;
        private System.Windows.Forms.Label teleportLabel;
        private System.Windows.Forms.Label loadPosLabel;
        private System.Windows.Forms.Label nextStationLabel;
        private System.Windows.Forms.Label autoLabel;
        private KeybindBox savePosBox;
        private KeybindBox prevMapBox;
        private KeybindBox loadPosBox;
        private KeybindBox autoBox;
        private KeybindBox teleportBox;
        private KeybindBox nextStationBox;
        private KeybindBox prevStationBox;
        private KeybindBox nextMapBox;
        private System.Windows.Forms.Label nextMapLabel;
        private KeybindBox lockBox;
        private System.Windows.Forms.Label lockLabel;
    }
}