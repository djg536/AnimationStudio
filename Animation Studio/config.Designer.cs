namespace Animation_Studio
{
    partial class config
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
            this.label1 = new System.Windows.Forms.Label();
            this.trk_speed = new System.Windows.Forms.TrackBar();
            this.chk_sizeWarn = new System.Windows.Forms.CheckBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_saveSettings = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trk_speed)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Default Playback Speed";
            // 
            // trk_speed
            // 
            this.trk_speed.Location = new System.Drawing.Point(10, 25);
            this.trk_speed.Minimum = 1;
            this.trk_speed.Name = "trk_speed";
            this.trk_speed.Size = new System.Drawing.Size(218, 45);
            this.trk_speed.TabIndex = 13;
            this.trk_speed.Value = 1;
            // 
            // chk_sizeWarn
            // 
            this.chk_sizeWarn.AutoSize = true;
            this.chk_sizeWarn.Location = new System.Drawing.Point(19, 76);
            this.chk_sizeWarn.Name = "chk_sizeWarn";
            this.chk_sizeWarn.Size = new System.Drawing.Size(209, 17);
            this.chk_sizeWarn.TabIndex = 15;
            this.chk_sizeWarn.Text = "Warn if animation is too large on export";
            this.chk_sizeWarn.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(10, 119);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(97, 23);
            this.btn_cancel.TabIndex = 16;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_saveSettings
            // 
            this.btn_saveSettings.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_saveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveSettings.Location = new System.Drawing.Point(131, 119);
            this.btn_saveSettings.Name = "btn_saveSettings";
            this.btn_saveSettings.Size = new System.Drawing.Size(97, 23);
            this.btn_saveSettings.TabIndex = 17;
            this.btn_saveSettings.Text = "Save Settings";
            this.btn_saveSettings.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 50000;
            this.toolTip.BackColor = System.Drawing.Color.LightGray;
            this.toolTip.InitialDelay = 300;
            this.toolTip.ReshowDelay = 100;
            // 
            // config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 152);
            this.Controls.Add(this.btn_saveSettings);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.chk_sizeWarn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trk_speed);
            this.Name = "config";
            this.Text = "Studio Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.trk_speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trk_speed;
        private System.Windows.Forms.CheckBox chk_sizeWarn;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_saveSettings;
        private System.Windows.Forms.ToolTip toolTip;
    }
}