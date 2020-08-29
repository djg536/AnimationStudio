using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Animation_Studio
{
    public partial class config : Form
    {
        //This is the constructor which is run when the form is created
        public config()
        {
            InitializeComponent();

            //These statements are used to assign tooltips to GUI elements in the form, which explain their function
            toolTip.SetToolTip(btn_cancel, "Discard any setting changes, reverting to the previous configuration.");
            toolTip.SetToolTip(btn_saveSettings, "Save the settings shown in this window.");
            toolTip.SetToolTip(trk_speed, "This slider sets the playback speed which is used by default on new animations.");
            toolTip.SetToolTip(chk_sizeWarn, "Enabling this will turn on warning notifications about the file size of exported animations, which may be too large for the internal memory in the Ardunino to store.");
        }

        //These functions handle the setter and getter routines that allow values to be passed to or retrieved from the main form.
        //When the form is submitted, these values are retrieved by the main form for use elsewhere.
        public int speed
        {
            get { return trk_speed.Value; }
            set
            {
                trk_speed.Value = value;
            }
        }
        public bool sizeWarnOnExport
        {
            get { return chk_sizeWarn.Checked; }
            set
            {
                chk_sizeWarn.Checked = value;
            }
        }
    }
}
