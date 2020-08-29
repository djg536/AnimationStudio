using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation_Studio
{
    public partial class export : Form
    {
        //These fields store values such as the animation speed.
        private int _speed;
        private string _filepath;

        public export()
        {
            InitializeComponent();

            //These statements are used to assign tooltips to GUI elements in the form, which explain their function
            toolTip.SetToolTip(btn_cancel, "Go back to editing this animation without exporting it.");
            toolTip.SetToolTip(btn_export, "Export the animation as C code source file. This can be compiled for use on an Arduino.");
            toolTip.SetToolTip(btn_browse, "Choose the name and location of the file which the animation will be exported to.");
            toolTip.SetToolTip(trk_speed, "Set the playback speed for when the exported animation is played back on an Arduino.");
            toolTip.SetToolTip(chk_dictionaryCompression, "Dictionary compression may allow animations to take up less space when compiled for an Arduino, meaning that longer animations can be stored in the limited internal memory.");
        }

        //These functions handle the setter and getter routines that allow values to be passed to or retrieved from the main form.
        //When the form is submitted, these values are retrieved by the main form for use elsewhere.
        public int speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                trk_speed.Value = _speed;
            }
        }
        public string filepath
        {
            get { return _filepath; }
        }
        public bool useDictionaryCompression
        {
            get { return chk_dictionaryCompression.Checked; }
        }

        //This allows the user to choose a file name and location to export to project to.
        private void btn_browse_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "C Code Source Files|*.C";
            //The filter makes sure that only relevent file types (identified by the .C extension) are displayed
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lbl_filepath.Text = _filepath = sfd.FileName;
                //If a file name and location is successfully choosen, write this to _filepath and display the path via the filepath label
            }
        }

        private void trk_speed_Scroll(object sender, EventArgs e)
        {
            _speed = trk_speed.Value;
        }
    }
}
