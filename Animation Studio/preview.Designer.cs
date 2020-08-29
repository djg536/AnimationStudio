namespace Animation_Studio
{
    partial class preview
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
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_fastForward = new System.Windows.Forms.Button();
            this.btn_rewind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trk_speed = new System.Windows.Forms.TrackBar();
            this.pic_preview = new System.Windows.Forms.PictureBox();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trk_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_preview)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_play
            // 
            this.btn_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_play.Location = new System.Drawing.Point(12, 12);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(97, 23);
            this.btn_play.TabIndex = 1;
            this.btn_play.Text = "Play";
            this.btn_play.UseVisualStyleBackColor = true;
            // 
            // btn_pause
            // 
            this.btn_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pause.Location = new System.Drawing.Point(12, 41);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(97, 23);
            this.btn_pause.TabIndex = 2;
            this.btn_pause.Text = "Pause";
            this.btn_pause.UseVisualStyleBackColor = true;
            // 
            // btn_stop
            // 
            this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stop.Location = new System.Drawing.Point(12, 70);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(97, 23);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            // 
            // btn_fastForward
            // 
            this.btn_fastForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fastForward.Location = new System.Drawing.Point(12, 150);
            this.btn_fastForward.Name = "btn_fastForward";
            this.btn_fastForward.Size = new System.Drawing.Size(97, 23);
            this.btn_fastForward.TabIndex = 4;
            this.btn_fastForward.Text = "Fast-Forward";
            this.btn_fastForward.UseVisualStyleBackColor = true;
            // 
            // btn_rewind
            // 
            this.btn_rewind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rewind.Location = new System.Drawing.Point(12, 179);
            this.btn_rewind.Name = "btn_rewind";
            this.btn_rewind.Size = new System.Drawing.Size(97, 23);
            this.btn_rewind.TabIndex = 5;
            this.btn_rewind.Text = "Rewind";
            this.btn_rewind.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Playback Speed";
            // 
            // trk_speed
            // 
            this.trk_speed.Location = new System.Drawing.Point(12, 117);
            this.trk_speed.Name = "trk_speed";
            this.trk_speed.Size = new System.Drawing.Size(97, 45);
            this.trk_speed.TabIndex = 11;
            // 
            // pic_preview
            // 
            this.pic_preview.Location = new System.Drawing.Point(116, 13);
            this.pic_preview.Name = "pic_preview";
            this.pic_preview.Size = new System.Drawing.Size(379, 399);
            this.pic_preview.TabIndex = 13;
            this.pic_preview.TabStop = false;
            // 
            // btn_export
            // 
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.Location = new System.Drawing.Point(12, 229);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(97, 23);
            this.btn_export.TabIndex = 14;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            // 
            // btn_close
            // 
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Location = new System.Drawing.Point(12, 258);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(97, 23);
            this.btn_close.TabIndex = 15;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 429);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.pic_preview);
            this.Controls.Add(this.btn_fastForward);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trk_speed);
            this.Controls.Add(this.btn_rewind);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_play);
            this.Name = "preview";
            this.Text = "Animation Preview";
            ((System.ComponentModel.ISupportInitialize)(this.trk_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_fastForward;
        private System.Windows.Forms.Button btn_rewind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trk_speed;
        private System.Windows.Forms.PictureBox pic_preview;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_close;
    }
}