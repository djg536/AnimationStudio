namespace Animation_Studio
{
    partial class main
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
            this.controlBar = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTUDIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btn_straightLine = new System.Windows.Forms.Button();
            this.pic_main = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_clearBlack = new System.Windows.Forms.Button();
            this.trk_speed = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.trk_width = new System.Windows.Forms.TrackBar();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_clearWhite = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.btn_rotateSelection = new System.Windows.Forms.Button();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_moveSelection = new System.Windows.Forms.Button();
            this.btn_selectRegion = new System.Windows.Forms.Button();
            this.btn_sprayCan = new System.Windows.Forms.Button();
            this.btn_fillCan = new System.Windows.Forms.Button();
            this.btn_pen = new System.Windows.Forms.Button();
            this.btn_togglePixel = new System.Windows.Forms.Button();
            this.btn_frameDown = new System.Windows.Forms.Button();
            this.btn_frameUp = new System.Windows.Forms.Button();
            this.cmb_filter = new System.Windows.Forms.ComboBox();
            this.btn_applyFilter = new System.Windows.Forms.Button();
            this.lst_frames = new System.Windows.Forms.ListBox();
            this.btn_copyFrame = new System.Windows.Forms.Button();
            this.btn_removeFrame = new System.Windows.Forms.Button();
            this.btn_addFromImage = new System.Windows.Forms.Button();
            this.btn_addBlankFrame = new System.Windows.Forms.Button();
            this.tmr_main = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.controlBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_width)).BeginInit();
            this.SuspendLayout();
            // 
            // controlBar
            // 
            this.controlBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.sTUDIOToolStripMenuItem});
            this.controlBar.Location = new System.Drawing.Point(0, 0);
            this.controlBar.Name = "controlBar";
            this.controlBar.Size = new System.Drawing.Size(1075, 24);
            this.controlBar.TabIndex = 0;
            this.controlBar.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // sTUDIOToolStripMenuItem
            // 
            this.sTUDIOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.sTUDIOToolStripMenuItem.Name = "sTUDIOToolStripMenuItem";
            this.sTUDIOToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sTUDIOToolStripMenuItem.Text = "STUDIO";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.configurationToolStripMenuItem.Text = "Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.btn_straightLine);
            this.splitContainer.Panel1.Controls.Add(this.pic_main);
            this.splitContainer.Panel1.Controls.Add(this.label2);
            this.splitContainer.Panel1.Controls.Add(this.btn_clearBlack);
            this.splitContainer.Panel1.Controls.Add(this.trk_speed);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.trk_width);
            this.splitContainer.Panel1.Controls.Add(this.btn_stop);
            this.splitContainer.Panel1.Controls.Add(this.btn_clearWhite);
            this.splitContainer.Panel1.Controls.Add(this.btn_pause);
            this.splitContainer.Panel1.Controls.Add(this.btn_rotateSelection);
            this.splitContainer.Panel1.Controls.Add(this.btn_play);
            this.splitContainer.Panel1.Controls.Add(this.btn_moveSelection);
            this.splitContainer.Panel1.Controls.Add(this.btn_selectRegion);
            this.splitContainer.Panel1.Controls.Add(this.btn_sprayCan);
            this.splitContainer.Panel1.Controls.Add(this.btn_fillCan);
            this.splitContainer.Panel1.Controls.Add(this.btn_pen);
            this.splitContainer.Panel1.Controls.Add(this.btn_togglePixel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.btn_frameDown);
            this.splitContainer.Panel2.Controls.Add(this.btn_frameUp);
            this.splitContainer.Panel2.Controls.Add(this.cmb_filter);
            this.splitContainer.Panel2.Controls.Add(this.btn_applyFilter);
            this.splitContainer.Panel2.Controls.Add(this.lst_frames);
            this.splitContainer.Panel2.Controls.Add(this.btn_copyFrame);
            this.splitContainer.Panel2.Controls.Add(this.btn_removeFrame);
            this.splitContainer.Panel2.Controls.Add(this.btn_addFromImage);
            this.splitContainer.Panel2.Controls.Add(this.btn_addBlankFrame);
            this.splitContainer.Size = new System.Drawing.Size(1075, 494);
            this.splitContainer.SplitterDistance = 952;
            this.splitContainer.TabIndex = 0;
            // 
            // btn_straightLine
            // 
            this.btn_straightLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_straightLine.Location = new System.Drawing.Point(4, 120);
            this.btn_straightLine.Name = "btn_straightLine";
            this.btn_straightLine.Size = new System.Drawing.Size(97, 23);
            this.btn_straightLine.TabIndex = 24;
            this.btn_straightLine.Text = "Straight Line";
            this.btn_straightLine.UseVisualStyleBackColor = true;
            this.btn_straightLine.Click += new System.EventHandler(this.btn_straightLine_Click);
            // 
            // pic_main
            // 
            this.pic_main.BackColor = System.Drawing.Color.White;
            this.pic_main.Location = new System.Drawing.Point(108, 4);
            this.pic_main.Name = "pic_main";
            this.pic_main.Size = new System.Drawing.Size(840, 480);
            this.pic_main.TabIndex = 11;
            this.pic_main.TabStop = false;
            this.pic_main.Paint += new System.Windows.Forms.PaintEventHandler(this.pic_main_Paint);
            this.pic_main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_main_MouseDown);
            this.pic_main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_main_MouseMove);
            this.pic_main.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_main_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Playback Speed";
            // 
            // btn_clearBlack
            // 
            this.btn_clearBlack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clearBlack.Location = new System.Drawing.Point(4, 281);
            this.btn_clearBlack.Name = "btn_clearBlack";
            this.btn_clearBlack.Size = new System.Drawing.Size(97, 23);
            this.btn_clearBlack.TabIndex = 7;
            this.btn_clearBlack.Text = "Clear to Black";
            this.btn_clearBlack.UseVisualStyleBackColor = true;
            this.btn_clearBlack.Click += new System.EventHandler(this.btn_clearBlack_Click);
            // 
            // trk_speed
            // 
            this.trk_speed.Location = new System.Drawing.Point(4, 460);
            this.trk_speed.Minimum = 1;
            this.trk_speed.Name = "trk_speed";
            this.trk_speed.Size = new System.Drawing.Size(97, 45);
            this.trk_speed.TabIndex = 22;
            this.trk_speed.Value = 1;
            this.trk_speed.Scroll += new System.EventHandler(this.trk_speed_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Width";
            // 
            // trk_width
            // 
            this.trk_width.Location = new System.Drawing.Point(4, 249);
            this.trk_width.Maximum = 6;
            this.trk_width.Minimum = 1;
            this.trk_width.Name = "trk_width";
            this.trk_width.Size = new System.Drawing.Size(97, 45);
            this.trk_width.TabIndex = 9;
            this.trk_width.Value = 1;
            this.trk_width.Scroll += new System.EventHandler(this.trk_width_Scroll);
            // 
            // btn_stop
            // 
            this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stop.Location = new System.Drawing.Point(4, 413);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(97, 23);
            this.btn_stop.TabIndex = 19;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_clearWhite
            // 
            this.btn_clearWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clearWhite.Location = new System.Drawing.Point(3, 310);
            this.btn_clearWhite.Name = "btn_clearWhite";
            this.btn_clearWhite.Size = new System.Drawing.Size(97, 23);
            this.btn_clearWhite.TabIndex = 8;
            this.btn_clearWhite.Text = "Clear to White";
            this.btn_clearWhite.UseVisualStyleBackColor = true;
            this.btn_clearWhite.Click += new System.EventHandler(this.btn_clearWhite_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pause.Location = new System.Drawing.Point(4, 384);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(97, 23);
            this.btn_pause.TabIndex = 18;
            this.btn_pause.Text = "Pause";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // btn_rotateSelection
            // 
            this.btn_rotateSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rotateSelection.Location = new System.Drawing.Point(4, 207);
            this.btn_rotateSelection.Name = "btn_rotateSelection";
            this.btn_rotateSelection.Size = new System.Drawing.Size(97, 23);
            this.btn_rotateSelection.TabIndex = 6;
            this.btn_rotateSelection.Text = "Rotate Selection";
            this.btn_rotateSelection.UseVisualStyleBackColor = true;
            this.btn_rotateSelection.Click += new System.EventHandler(this.btn_rotateSelection_Click);
            // 
            // btn_play
            // 
            this.btn_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_play.Location = new System.Drawing.Point(4, 355);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(97, 23);
            this.btn_play.TabIndex = 17;
            this.btn_play.Text = "Play";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // btn_moveSelection
            // 
            this.btn_moveSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_moveSelection.Location = new System.Drawing.Point(4, 178);
            this.btn_moveSelection.Name = "btn_moveSelection";
            this.btn_moveSelection.Size = new System.Drawing.Size(97, 23);
            this.btn_moveSelection.TabIndex = 5;
            this.btn_moveSelection.Text = "Move Selection";
            this.btn_moveSelection.UseVisualStyleBackColor = true;
            this.btn_moveSelection.Click += new System.EventHandler(this.btn_moveSelection_Click);
            // 
            // btn_selectRegion
            // 
            this.btn_selectRegion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selectRegion.Location = new System.Drawing.Point(4, 149);
            this.btn_selectRegion.Name = "btn_selectRegion";
            this.btn_selectRegion.Size = new System.Drawing.Size(98, 23);
            this.btn_selectRegion.TabIndex = 4;
            this.btn_selectRegion.Text = "Select Region";
            this.btn_selectRegion.UseVisualStyleBackColor = true;
            this.btn_selectRegion.Click += new System.EventHandler(this.btn_selectRegion_Click);
            // 
            // btn_sprayCan
            // 
            this.btn_sprayCan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sprayCan.Location = new System.Drawing.Point(4, 91);
            this.btn_sprayCan.Name = "btn_sprayCan";
            this.btn_sprayCan.Size = new System.Drawing.Size(97, 23);
            this.btn_sprayCan.TabIndex = 3;
            this.btn_sprayCan.Text = "Spray Can";
            this.btn_sprayCan.UseVisualStyleBackColor = true;
            this.btn_sprayCan.Click += new System.EventHandler(this.btn_sprayCan_Click);
            // 
            // btn_fillCan
            // 
            this.btn_fillCan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fillCan.Location = new System.Drawing.Point(4, 62);
            this.btn_fillCan.Name = "btn_fillCan";
            this.btn_fillCan.Size = new System.Drawing.Size(97, 23);
            this.btn_fillCan.TabIndex = 2;
            this.btn_fillCan.Text = "Fill Can";
            this.btn_fillCan.UseVisualStyleBackColor = true;
            this.btn_fillCan.Click += new System.EventHandler(this.btn_fillCan_Click);
            // 
            // btn_pen
            // 
            this.btn_pen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pen.Location = new System.Drawing.Point(4, 33);
            this.btn_pen.Name = "btn_pen";
            this.btn_pen.Size = new System.Drawing.Size(97, 23);
            this.btn_pen.TabIndex = 1;
            this.btn_pen.Text = "Pen";
            this.btn_pen.UseVisualStyleBackColor = true;
            this.btn_pen.Click += new System.EventHandler(this.btn_pen_Click);
            // 
            // btn_togglePixel
            // 
            this.btn_togglePixel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_togglePixel.Location = new System.Drawing.Point(4, 4);
            this.btn_togglePixel.Name = "btn_togglePixel";
            this.btn_togglePixel.Size = new System.Drawing.Size(97, 23);
            this.btn_togglePixel.TabIndex = 0;
            this.btn_togglePixel.Text = "Toggle Pixel";
            this.btn_togglePixel.UseVisualStyleBackColor = true;
            this.btn_togglePixel.Click += new System.EventHandler(this.btn_togglePixel_Click);
            // 
            // btn_frameDown
            // 
            this.btn_frameDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_frameDown.Location = new System.Drawing.Point(3, 392);
            this.btn_frameDown.Name = "btn_frameDown";
            this.btn_frameDown.Size = new System.Drawing.Size(109, 23);
            this.btn_frameDown.TabIndex = 20;
            this.btn_frameDown.Text = "Move Frame Down";
            this.btn_frameDown.UseVisualStyleBackColor = true;
            this.btn_frameDown.Click += new System.EventHandler(this.btn_frameDown_Click);
            // 
            // btn_frameUp
            // 
            this.btn_frameUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_frameUp.Location = new System.Drawing.Point(3, 363);
            this.btn_frameUp.Name = "btn_frameUp";
            this.btn_frameUp.Size = new System.Drawing.Size(109, 23);
            this.btn_frameUp.TabIndex = 19;
            this.btn_frameUp.Text = "Move Frame Up";
            this.btn_frameUp.UseVisualStyleBackColor = true;
            this.btn_frameUp.Click += new System.EventHandler(this.btn_frameUp_Click);
            // 
            // cmb_filter
            // 
            this.cmb_filter.FormattingEnabled = true;
            this.cmb_filter.Items.AddRange(new object[] {
            "Invert",
            "Distort"});
            this.cmb_filter.Location = new System.Drawing.Point(3, 423);
            this.cmb_filter.Name = "cmb_filter";
            this.cmb_filter.Size = new System.Drawing.Size(109, 21);
            this.cmb_filter.TabIndex = 18;
            // 
            // btn_applyFilter
            // 
            this.btn_applyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_applyFilter.Location = new System.Drawing.Point(3, 455);
            this.btn_applyFilter.Name = "btn_applyFilter";
            this.btn_applyFilter.Size = new System.Drawing.Size(109, 23);
            this.btn_applyFilter.TabIndex = 17;
            this.btn_applyFilter.Text = "Apply Filter";
            this.btn_applyFilter.UseVisualStyleBackColor = true;
            this.btn_applyFilter.Click += new System.EventHandler(this.btn_applyFilter_Click);
            // 
            // lst_frames
            // 
            this.lst_frames.FormattingEnabled = true;
            this.lst_frames.Location = new System.Drawing.Point(3, 3);
            this.lst_frames.Name = "lst_frames";
            this.lst_frames.ScrollAlwaysVisible = true;
            this.lst_frames.Size = new System.Drawing.Size(109, 238);
            this.lst_frames.TabIndex = 16;
            this.lst_frames.SelectedIndexChanged += new System.EventHandler(this.lst_frames_SelectedIndexChanged);
            // 
            // btn_copyFrame
            // 
            this.btn_copyFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_copyFrame.Location = new System.Drawing.Point(3, 334);
            this.btn_copyFrame.Name = "btn_copyFrame";
            this.btn_copyFrame.Size = new System.Drawing.Size(109, 23);
            this.btn_copyFrame.TabIndex = 15;
            this.btn_copyFrame.Text = "Copy Frame";
            this.btn_copyFrame.UseVisualStyleBackColor = true;
            this.btn_copyFrame.Click += new System.EventHandler(this.btn_copyFrame_Click);
            // 
            // btn_removeFrame
            // 
            this.btn_removeFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_removeFrame.Location = new System.Drawing.Point(3, 305);
            this.btn_removeFrame.Name = "btn_removeFrame";
            this.btn_removeFrame.Size = new System.Drawing.Size(109, 23);
            this.btn_removeFrame.TabIndex = 14;
            this.btn_removeFrame.Text = "Remove Frame";
            this.btn_removeFrame.UseVisualStyleBackColor = true;
            this.btn_removeFrame.Click += new System.EventHandler(this.btn_removeFrame_Click);
            // 
            // btn_addFromImage
            // 
            this.btn_addFromImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addFromImage.Location = new System.Drawing.Point(3, 276);
            this.btn_addFromImage.Name = "btn_addFromImage";
            this.btn_addFromImage.Size = new System.Drawing.Size(109, 23);
            this.btn_addFromImage.TabIndex = 13;
            this.btn_addFromImage.Text = "Add from Image";
            this.btn_addFromImage.UseVisualStyleBackColor = true;
            this.btn_addFromImage.Click += new System.EventHandler(this.btn_addFromImage_Click);
            // 
            // btn_addBlankFrame
            // 
            this.btn_addBlankFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addBlankFrame.Location = new System.Drawing.Point(3, 247);
            this.btn_addBlankFrame.Name = "btn_addBlankFrame";
            this.btn_addBlankFrame.Size = new System.Drawing.Size(109, 23);
            this.btn_addBlankFrame.TabIndex = 12;
            this.btn_addBlankFrame.Text = "Add Blank Frame";
            this.btn_addBlankFrame.UseVisualStyleBackColor = true;
            this.btn_addBlankFrame.Click += new System.EventHandler(this.btn_addBlankFrame_Click);
            // 
            // tmr_main
            // 
            this.tmr_main.Interval = 500;
            this.tmr_main.Tick += new System.EventHandler(this.tmr_main_Tick);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 50000;
            this.toolTip.BackColor = System.Drawing.Color.LightGray;
            this.toolTip.InitialDelay = 300;
            this.toolTip.ReshowDelay = 100;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 518);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.controlBar);
            this.MainMenuStrip = this.controlBar;
            this.Name = "main";
            this.Text = "Animation Studio";
            this.controlBar.ResumeLayout(false);
            this.controlBar.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip controlBar;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTUDIOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btn_togglePixel;
        private System.Windows.Forms.Button btn_pen;
        private System.Windows.Forms.Button btn_sprayCan;
        private System.Windows.Forms.Button btn_fillCan;
        private System.Windows.Forms.Button btn_rotateSelection;
        private System.Windows.Forms.Button btn_moveSelection;
        private System.Windows.Forms.Button btn_selectRegion;
        private System.Windows.Forms.Button btn_clearWhite;
        private System.Windows.Forms.Button btn_clearBlack;
        private System.Windows.Forms.TrackBar trk_width;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic_main;
        private System.Windows.Forms.Button btn_addBlankFrame;
        private System.Windows.Forms.Button btn_addFromImage;
        private System.Windows.Forms.Button btn_copyFrame;
        private System.Windows.Forms.Button btn_removeFrame;
        private System.Windows.Forms.ListBox lst_frames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trk_speed;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Timer tmr_main;
        private System.Windows.Forms.Button btn_straightLine;
        private System.Windows.Forms.ComboBox cmb_filter;
        private System.Windows.Forms.Button btn_applyFilter;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btn_frameDown;
        private System.Windows.Forms.Button btn_frameUp;
    }
}

