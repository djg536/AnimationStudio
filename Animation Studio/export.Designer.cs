namespace Animation_Studio
{
    partial class export
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
            this.chk_dictionaryCompression = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trk_speed = new System.Windows.Forms.TrackBar();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_browse = new System.Windows.Forms.Button();
            this.lbl_filepath = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trk_speed)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_dictionaryCompression
            // 
            this.chk_dictionaryCompression.AutoSize = true;
            this.chk_dictionaryCompression.Location = new System.Drawing.Point(22, 12);
            this.chk_dictionaryCompression.Name = "chk_dictionaryCompression";
            this.chk_dictionaryCompression.Size = new System.Drawing.Size(155, 17);
            this.chk_dictionaryCompression.TabIndex = 1;
            this.chk_dictionaryCompression.Text = "Use dictionary compression";
            this.chk_dictionaryCompression.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Exported Playback Speed";
            // 
            // trk_speed
            // 
            this.trk_speed.Location = new System.Drawing.Point(12, 51);
            this.trk_speed.Minimum = 1;
            this.trk_speed.Name = "trk_speed";
            this.trk_speed.Size = new System.Drawing.Size(198, 45);
            this.trk_speed.TabIndex = 15;
            this.trk_speed.Value = 1;
            this.trk_speed.Scroll += new System.EventHandler(this.trk_speed_Scroll);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(12, 153);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(97, 23);
            this.btn_cancel.TabIndex = 17;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_export
            // 
            this.btn_export.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.Location = new System.Drawing.Point(115, 153);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(97, 23);
            this.btn_export.TabIndex = 18;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            // 
            // btn_browse
            // 
            this.btn_browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_browse.Location = new System.Drawing.Point(12, 89);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(116, 23);
            this.btn_browse.TabIndex = 19;
            this.btn_browse.Text = "Choose Filename";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // lbl_filepath
            // 
            this.lbl_filepath.AutoSize = true;
            this.lbl_filepath.Location = new System.Drawing.Point(12, 115);
            this.lbl_filepath.Name = "lbl_filepath";
            this.lbl_filepath.Size = new System.Drawing.Size(13, 13);
            this.lbl_filepath.TabIndex = 20;
            this.lbl_filepath.Text = "  ";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 50000;
            this.toolTip.BackColor = System.Drawing.Color.LightGray;
            this.toolTip.InitialDelay = 300;
            this.toolTip.ReshowDelay = 100;
            // 
            // export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 187);
            this.Controls.Add(this.lbl_filepath);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trk_speed);
            this.Controls.Add(this.chk_dictionaryCompression);
            this.Name = "export";
            this.Text = "Export Animation";
            ((System.ComponentModel.ISupportInitialize)(this.trk_speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chk_dictionaryCompression;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trk_speed;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Label lbl_filepath;
        private System.Windows.Forms.ToolTip toolTip;
    }
}