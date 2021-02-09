namespace BL3TP {
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
      this.xInput = new System.Windows.Forms.NumericUpDown();
      this.yInput = new System.Windows.Forms.NumericUpDown();
      this.zInput = new System.Windows.Forms.NumericUpDown();
      this.zLock = new System.Windows.Forms.CheckBox();
      this.xLock = new System.Windows.Forms.CheckBox();
      this.yLock = new System.Windows.Forms.CheckBox();
      this.positionTable = new System.Windows.Forms.TableLayoutPanel();
      this.positionLabel = new System.Windows.Forms.Label();
      this.lockLabel = new System.Windows.Forms.Label();
      this.saveButtton = new System.Windows.Forms.Button();
      this.loadButton = new System.Windows.Forms.Button();
      this.presetList = new System.Windows.Forms.ListView();
      this.deleteButton = new System.Windows.Forms.Button();
      this.prevLabel = new System.Windows.Forms.Label();
      this.bindsTable = new System.Windows.Forms.TableLayoutPanel();
      this.nextLabel = new System.Windows.Forms.Label();
      this.saveKeybind = new BL3TP.KeybindBox();
      this.loadKeybind = new BL3TP.KeybindBox();
      this.deleteKeybind = new BL3TP.KeybindBox();
      this.nextKeybind = new BL3TP.KeybindBox();
      this.prevKeybind = new BL3TP.KeybindBox();
      this.worldTable = new System.Windows.Forms.TableLayoutPanel();
      this.worldHeaderLabel = new System.Windows.Forms.Label();
      this.worldNameLabel = new System.Windows.Forms.Label();
      this.presetNameBox = new BL3TP.HintTextBox();
      this.emptyHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      ((System.ComponentModel.ISupportInitialize)(this.xInput)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.yInput)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.zInput)).BeginInit();
      this.positionTable.SuspendLayout();
      this.bindsTable.SuspendLayout();
      this.worldTable.SuspendLayout();
      this.SuspendLayout();
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
      this.xInput.Size = new System.Drawing.Size(155, 20);
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
      this.yInput.Size = new System.Drawing.Size(155, 20);
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
      this.zInput.Size = new System.Drawing.Size(155, 20);
      this.zInput.TabIndex = 9;
      this.zInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.zInput.ValueChanged += new System.EventHandler(this.Position_ValueChanged);
      this.zInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Position_KeyDown);
      // 
      // zLock
      // 
      this.zLock.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.zLock.AutoSize = true;
      this.zLock.Location = new System.Drawing.Point(173, 73);
      this.zLock.Name = "zLock";
      this.zLock.Size = new System.Drawing.Size(15, 14);
      this.zLock.TabIndex = 14;
      this.zLock.UseVisualStyleBackColor = true;
      // 
      // xLock
      // 
      this.xLock.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.xLock.AutoSize = true;
      this.xLock.Location = new System.Drawing.Point(173, 21);
      this.xLock.Name = "xLock";
      this.xLock.Size = new System.Drawing.Size(15, 14);
      this.xLock.TabIndex = 15;
      this.xLock.UseVisualStyleBackColor = true;
      // 
      // yLock
      // 
      this.yLock.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.yLock.AutoSize = true;
      this.yLock.Location = new System.Drawing.Point(173, 47);
      this.yLock.Name = "yLock";
      this.yLock.Size = new System.Drawing.Size(15, 14);
      this.yLock.TabIndex = 16;
      this.yLock.UseVisualStyleBackColor = true;
      // 
      // positionTable
      // 
      this.positionTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
      this.positionTable.Location = new System.Drawing.Point(215, 181);
      this.positionTable.Name = "positionTable";
      this.positionTable.RowCount = 4;
      this.positionTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.positionTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.positionTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.positionTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.positionTable.Size = new System.Drawing.Size(200, 93);
      this.positionTable.TabIndex = 20;
      // 
      // positionLabel
      // 
      this.positionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.positionLabel.AutoSize = true;
      this.positionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.positionLabel.Location = new System.Drawing.Point(55, 0);
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
      this.lockLabel.Location = new System.Drawing.Point(164, 0);
      this.lockLabel.Name = "lockLabel";
      this.lockLabel.Size = new System.Drawing.Size(33, 15);
      this.lockLabel.TabIndex = 1;
      this.lockLabel.Text = "Lock";
      // 
      // saveButtton
      // 
      this.saveButtton.Location = new System.Drawing.Point(3, 3);
      this.saveButtton.Name = "saveButtton";
      this.saveButtton.Size = new System.Drawing.Size(94, 22);
      this.saveButtton.TabIndex = 29;
      this.saveButtton.Text = "Save";
      this.saveButtton.UseVisualStyleBackColor = true;
      this.saveButtton.Click += new System.EventHandler(this.SaveButton_Click);
      // 
      // loadButton
      // 
      this.loadButton.Enabled = false;
      this.loadButton.Location = new System.Drawing.Point(3, 31);
      this.loadButton.Name = "loadButton";
      this.loadButton.Size = new System.Drawing.Size(94, 22);
      this.loadButton.TabIndex = 30;
      this.loadButton.Text = "Load";
      this.loadButton.UseVisualStyleBackColor = true;
      this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
      // 
      // presetList
      // 
      this.presetList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.presetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.emptyHeader});
      this.presetList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.presetList.HideSelection = false;
      this.presetList.Location = new System.Drawing.Point(12, 38);
      this.presetList.Name = "presetList";
      this.presetList.ShowGroups = false;
      this.presetList.ShowItemToolTips = true;
      this.presetList.Size = new System.Drawing.Size(197, 236);
      this.presetList.TabIndex = 32;
      this.presetList.UseCompatibleStateImageBehavior = false;
      this.presetList.View = System.Windows.Forms.View.Details;
      // 
      // deleteButton
      // 
      this.deleteButton.Location = new System.Drawing.Point(3, 59);
      this.deleteButton.Name = "deleteButton";
      this.deleteButton.Size = new System.Drawing.Size(94, 22);
      this.deleteButton.TabIndex = 34;
      this.deleteButton.Text = "Delete";
      this.deleteButton.UseVisualStyleBackColor = true;
      this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
      // 
      // prevLabel
      // 
      this.prevLabel.AutoSize = true;
      this.prevLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.prevLabel.Location = new System.Drawing.Point(3, 110);
      this.prevLabel.Name = "prevLabel";
      this.prevLabel.Size = new System.Drawing.Size(94, 26);
      this.prevLabel.TabIndex = 36;
      this.prevLabel.Text = "Previous Preset";
      this.prevLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // bindsTable
      // 
      this.bindsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bindsTable.AutoSize = true;
      this.bindsTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.bindsTable.ColumnCount = 2;
      this.bindsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.bindsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.bindsTable.Controls.Add(this.saveButtton, 0, 0);
      this.bindsTable.Controls.Add(this.loadButton, 0, 1);
      this.bindsTable.Controls.Add(this.deleteButton, 0, 2);
      this.bindsTable.Controls.Add(this.nextLabel, 0, 3);
      this.bindsTable.Controls.Add(this.prevLabel, 0, 4);
      this.bindsTable.Controls.Add(this.saveKeybind, 1, 0);
      this.bindsTable.Controls.Add(this.loadKeybind, 1, 1);
      this.bindsTable.Controls.Add(this.deleteKeybind, 1, 2);
      this.bindsTable.Controls.Add(this.nextKeybind, 1, 3);
      this.bindsTable.Controls.Add(this.prevKeybind, 1, 4);
      this.bindsTable.Location = new System.Drawing.Point(215, 39);
      this.bindsTable.Name = "bindsTable";
      this.bindsTable.RowCount = 5;
      this.bindsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.bindsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.bindsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.bindsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.bindsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.bindsTable.Size = new System.Drawing.Size(200, 136);
      this.bindsTable.TabIndex = 37;
      // 
      // nextLabel
      // 
      this.nextLabel.AutoSize = true;
      this.nextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nextLabel.Location = new System.Drawing.Point(3, 84);
      this.nextLabel.Name = "nextLabel";
      this.nextLabel.Size = new System.Drawing.Size(94, 26);
      this.nextLabel.TabIndex = 37;
      this.nextLabel.Text = "Next Preset";
      this.nextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // saveKeybind
      // 
      this.saveKeybind.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.saveKeybind.Keys = System.Windows.Forms.Keys.None;
      this.saveKeybind.Location = new System.Drawing.Point(103, 3);
      this.saveKeybind.Name = "saveKeybind";
      this.saveKeybind.ReadOnly = true;
      this.saveKeybind.Size = new System.Drawing.Size(94, 20);
      this.saveKeybind.TabIndex = 38;
      this.saveKeybind.Text = "None";
      // 
      // loadKeybind
      // 
      this.loadKeybind.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.loadKeybind.Keys = System.Windows.Forms.Keys.None;
      this.loadKeybind.Location = new System.Drawing.Point(103, 31);
      this.loadKeybind.Name = "loadKeybind";
      this.loadKeybind.ReadOnly = true;
      this.loadKeybind.Size = new System.Drawing.Size(94, 20);
      this.loadKeybind.TabIndex = 39;
      this.loadKeybind.Text = "None";
      // 
      // deleteKeybind
      // 
      this.deleteKeybind.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.deleteKeybind.Keys = System.Windows.Forms.Keys.None;
      this.deleteKeybind.Location = new System.Drawing.Point(103, 59);
      this.deleteKeybind.Name = "deleteKeybind";
      this.deleteKeybind.ReadOnly = true;
      this.deleteKeybind.Size = new System.Drawing.Size(94, 20);
      this.deleteKeybind.TabIndex = 40;
      this.deleteKeybind.Text = "None";
      // 
      // nextKeybind
      // 
      this.nextKeybind.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.nextKeybind.Keys = System.Windows.Forms.Keys.None;
      this.nextKeybind.Location = new System.Drawing.Point(103, 87);
      this.nextKeybind.Name = "nextKeybind";
      this.nextKeybind.ReadOnly = true;
      this.nextKeybind.Size = new System.Drawing.Size(94, 20);
      this.nextKeybind.TabIndex = 41;
      this.nextKeybind.Text = "None";
      // 
      // prevKeybind
      // 
      this.prevKeybind.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.prevKeybind.Keys = System.Windows.Forms.Keys.None;
      this.prevKeybind.Location = new System.Drawing.Point(103, 113);
      this.prevKeybind.Name = "prevKeybind";
      this.prevKeybind.ReadOnly = true;
      this.prevKeybind.Size = new System.Drawing.Size(94, 20);
      this.prevKeybind.TabIndex = 42;
      this.prevKeybind.Text = "None";
      // 
      // worldTable
      // 
      this.worldTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.worldTable.ColumnCount = 2;
      this.worldTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.worldTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.worldTable.Controls.Add(this.worldHeaderLabel, 0, 0);
      this.worldTable.Controls.Add(this.worldNameLabel, 1, 0);
      this.worldTable.Location = new System.Drawing.Point(215, 12);
      this.worldTable.Name = "worldTable";
      this.worldTable.RowCount = 1;
      this.worldTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.worldTable.Size = new System.Drawing.Size(200, 21);
      this.worldTable.TabIndex = 38;
      // 
      // worldHeaderLabel
      // 
      this.worldHeaderLabel.AutoSize = true;
      this.worldHeaderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.worldHeaderLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.worldHeaderLabel.Location = new System.Drawing.Point(3, 0);
      this.worldHeaderLabel.Name = "worldHeaderLabel";
      this.worldHeaderLabel.Size = new System.Drawing.Size(94, 21);
      this.worldHeaderLabel.TabIndex = 0;
      this.worldHeaderLabel.Text = "Current World";
      this.worldHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // worldNameLabel
      // 
      this.worldNameLabel.AutoSize = true;
      this.worldNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.worldNameLabel.Location = new System.Drawing.Point(103, 0);
      this.worldNameLabel.Name = "worldNameLabel";
      this.worldNameLabel.Size = new System.Drawing.Size(94, 21);
      this.worldNameLabel.TabIndex = 1;
      this.worldNameLabel.Text = "Unknown";
      this.worldNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // presetNameBox
      // 
      this.presetNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.presetNameBox.HintText = "Preset Name";
      this.presetNameBox.Location = new System.Drawing.Point(12, 12);
      this.presetNameBox.Name = "presetNameBox";
      this.presetNameBox.Size = new System.Drawing.Size(197, 20);
      this.presetNameBox.TabIndex = 33;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(427, 286);
      this.Controls.Add(this.worldTable);
      this.Controls.Add(this.bindsTable);
      this.Controls.Add(this.presetNameBox);
      this.Controls.Add(this.presetList);
      this.Controls.Add(this.positionTable);
      this.MaximizeBox = false;
      this.MinimumSize = new System.Drawing.Size(443, 325);
      this.Name = "MainForm";
      this.Text = "BL3TP";
      ((System.ComponentModel.ISupportInitialize)(this.xInput)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.yInput)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.zInput)).EndInit();
      this.positionTable.ResumeLayout(false);
      this.positionTable.PerformLayout();
      this.bindsTable.ResumeLayout(false);
      this.bindsTable.PerformLayout();
      this.worldTable.ResumeLayout(false);
      this.worldTable.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion


        private System.Windows.Forms.TableLayoutPanel positionTable;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Label lockLabel;
    private System.Windows.Forms.Button saveButtton;
    private System.Windows.Forms.Button loadButton;
        internal System.Windows.Forms.CheckBox zLock;
        internal System.Windows.Forms.CheckBox xLock;
        internal System.Windows.Forms.CheckBox yLock;
        private System.Windows.Forms.NumericUpDown xInput;
        private System.Windows.Forms.NumericUpDown yInput;
        private System.Windows.Forms.NumericUpDown zInput;
    private System.Windows.Forms.ListView presetList;
    private System.Windows.Forms.Button deleteButton;
    private System.Windows.Forms.Label prevLabel;
    private System.Windows.Forms.TableLayoutPanel bindsTable;
    private System.Windows.Forms.Label nextLabel;
    private KeybindBox saveKeybind;
    private KeybindBox loadKeybind;
    private KeybindBox deleteKeybind;
    private KeybindBox nextKeybind;
    private KeybindBox prevKeybind;
    private System.Windows.Forms.TableLayoutPanel worldTable;
    private System.Windows.Forms.Label worldHeaderLabel;
    private System.Windows.Forms.Label worldNameLabel;
    private HintTextBox presetNameBox;
    private System.Windows.Forms.ColumnHeader emptyHeader;
  }
}

