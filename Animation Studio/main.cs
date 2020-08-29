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
    public partial class main : Form
    {
        //These are all of the fields which are used by the main class.
        private Animation animation; //Stores the currently loaded animation
        private int tool; //Identifies index of the tool which is currently being used
        private string currentSavePath = ""; //If a project has been previously saved, the filepath is stored here so it can be saved again without displaying any dialogs
        private int oldx, oldy;
        private bool sizeWarnOnExport;
        private const string filePath = "studio.cfg"; //stores the fixed path of the config file location
        private int defaultSpeed;
        private bool colour = true; //Since there are only two colours stored as a boolean. Used by some tools.
        private Random _r; //This is used to generate random numbers.

        //This is the constructor of the main form which is executed when the program is started
        public main()
        {
            InitializeComponent();
            _r = new Random();
            animation = new Animation(); //create a new animation
            animation.addFrame(new Frame());
            lst_frames.Items.Add("Frame 1");
            lst_frames.SelectedIndex = 0; //set the selected timeline frame to 0
            tool = 0;
            oldx = 0;
            oldy = 0;
            defaultSpeed = 1;
            loadConfig(); //loads the program config stored in the constant filePath

            //These statements are used to assign tooltips to GUI elements in the form, which explain their function
            toolTip.SetToolTip(btn_togglePixel, "Toggle the value of only one pixel at a time.");
            toolTip.SetToolTip(btn_pen, "Draw a continuous curve, with a variable width.");
            toolTip.SetToolTip(btn_fillCan, "Change the colour of an entire region.");
            toolTip.SetToolTip(btn_sprayCan, "Draws at a random position from the cursor, maximum distance variable with the width slider.");
            toolTip.SetToolTip(btn_straightLine, "Click and drag to draw a straight line between the start and end position of the mouse.");
            toolTip.SetToolTip(btn_selectRegion, "Select a rectangular region of pixels.");
            toolTip.SetToolTip(btn_moveSelection, "Move a selected region of pixels.");
            toolTip.SetToolTip(btn_rotateSelection, "Rotate the contents of a selected region by 90 degrees at a time.");
            toolTip.SetToolTip(trk_width, "Set the width of certain tools.");
            toolTip.SetToolTip(btn_clearBlack, "Sets the entire contents of the current frame to black.");
            toolTip.SetToolTip(btn_clearWhite, "Sets the entire contents of the current frame to white.");
            toolTip.SetToolTip(btn_play, "Play the animation.");
            toolTip.SetToolTip(btn_pause, "Pause the animation playback.");
            toolTip.SetToolTip(btn_stop, "Stop playing the animation and go back to the first frame.");
            toolTip.SetToolTip(trk_speed, "Sets the playback speed of the animation.");
            toolTip.SetToolTip(lst_frames, "Select a frame to edit it or apply a filter.");
            toolTip.SetToolTip(btn_addBlankFrame, "Creates a new frame with empty contents.");
            toolTip.SetToolTip(btn_addFromImage, "Converts an image file and displays it as a new frame.");
            toolTip.SetToolTip(btn_removeFrame, "Deletes the currently selected frame.");
            toolTip.SetToolTip(btn_copyFrame, "Duplicates the currently selected frame.");
            toolTip.SetToolTip(btn_applyFilter, "Select a filter from the dropdown and click to apply it to the currently selected frame.");
            toolTip.SetToolTip(btn_frameUp, "Move the selected frame forward in the animation.");
            toolTip.SetToolTip(btn_frameDown, "Move the selected frame backwards in the animation.");
        }
        private void loadConfig()
        {
            //This try statement is used to prevent any exceptions from crashing the program
            try
            {
                //The config file is in binary format, so is opened for reading in binary format.
                BinaryReader br = new BinaryReader(File.OpenRead(filePath));
                defaultSpeed = trk_speed.Value = br.ReadInt32();
                sizeWarnOnExport = br.ReadBoolean();
                br.Close();
            }
            catch (Exception) { }
            //Nothing happens if there is an exception since this function is run automatically and not by the user
        }
        private void saveConfig()
        {
            //try statement prevents exceptions from crashing the program
            try
            {
                BinaryWriter bw = new BinaryWriter(File.Create(filePath));
                bw.Write(defaultSpeed);
                bw.Write(sizeWarnOnExport);
                bw.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                //Since the user runs this function, the exception details are displayed
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //When the user presses the exit program button, this prompts the user.
            DialogResult dr_exit = MessageBox.Show("Are you sure that you want to exit the program?",
                                                "Confirmation", MessageBoxButtons.YesNo);

            //The user's decision is stored in dr_exit and appropriate action can then be taken if necessary
            if (dr_exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //This code is run when the user chooses to open the studio configuration form.
            config frm_config = new config();
            //A new instance of the form is created, and these two values are passed to it
            frm_config.speed = defaultSpeed;
            frm_config.sizeWarnOnExport = sizeWarnOnExport;

            //If the form has been submitted by the user
            if (frm_config.ShowDialog() == DialogResult.OK)
            {
                defaultSpeed = frm_config.speed;
                sizeWarnOnExport = frm_config.sizeWarnOnExport;
                saveConfig();
                //The values are retrieved from the form in case the user changed then and then written to the file
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //When the user decides to create a new blank animation, all of the values have to be reset or cleared
            currentSavePath = "";
            animation = new Animation();
            lst_frames.Items.Clear();

            //adds a single blank frame for the new project
            animation.addFrame(new Frame());
            lst_frames.Items.Add("Frame 1");
            lst_frames.SelectedIndex = 0;
            pic_main.Refresh();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If the currently loaded project has been saved before, the path will be stored in currentSavePath and
            //so saving can instantly be initiated. If this is not the case and the save path is empty, prompt the user.
            if (currentSavePath == "")
            {
                showSaveDialog();
            }
            saveToFile();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If the user selects save as, this forces the save dialog to be shown
            showSaveDialog();
            saveToFile();
        }
        private void showSaveDialog()
        {
            //This shows the save dialog. The filter makes sure that only files of the correct type are displayed.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Studio Project Files|*.ani";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                currentSavePath = sfd.FileName;
                //If the user successfully choose a save location, store it.
            }
        }
        private void showLoadDialog()
        {
            //This shows the load dialog. The filter makes sure that only files of the correct type are displayed.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Studio Project Files|*.ani";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentSavePath = ofd.FileName;
                //If a file is successfully choosen the path is stored
            }
        }
        private void saveToFile()
        {
            //This routine handles the saving of projects to a file. It makes use of exception handling to help prevent crashes
            try
            {
                //Open the file for writing
                BinaryWriter bw = new BinaryWriter(File.Create(currentSavePath));
                //Write the value of some variables
                bw.Write(animation.getLength());
                bw.Write(trk_speed.Value);

                //Iterate through all of the frames in the animation
                for (int i = 0; i < animation.getLength(); i++)
                {
                    //Iterate through every pixel of each frame
                    for (int x = 0; x < 84; x++)
                    {
                        for (int y = 0; y < 48; y++)
                        {
                            bw.Write(animation.getFrame(i).getPixel(x, y));
                            //Write the pixel at (x,y) to the file. These for loops ensure that every pixel of every frame is written.
                        }
                    }
                }
                //Close the file for writing
                bw.Close();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("You need to enter a file name first!");
            }
            catch (Exception e)
            {
                //If an exception happens, display the error message associated with it.
                MessageBox.Show("An error occurred when trying to save the file: " + e.Message);
            }
        }
        private void loadFromFile()
        {
            //This routine is used to load animation project files.

            if (currentSavePath != "")
            {
                //The try catch statements are used to handle any exceptions and prevent a crash
                try
                {
                    //clear any data from previously loaded projects
                    animation = new Animation();
                    lst_frames.Items.Clear();

                    //open the file for reading
                    BinaryReader br = new BinaryReader(File.OpenRead(currentSavePath));
                    int numberOfFrames = br.ReadInt32();
                    trk_speed.Value = br.ReadInt32();

                    //a temporary array to load the frame data into
                    bool[,] grid;
                    //Iterate through every frame in the animation.
                    //The number of frames to load is determined by the value numberOfFrames which is the first thing loaded from the file
                    for (int i = 0; i < numberOfFrames; i++)
                    {
                        //the twodimensional array grid has the same number of values as the screen has pixels
                        grid = new bool[84, 48];
                        for (int x = 0; x < 84; x++)
                        {
                            for (int y = 0; y < 48; y++)
                            {
                                grid[x, y] = br.ReadBoolean();
                                //Load each frame value into the temporary array
                            }
                        }
                        //Add a new frame once the frame has been loaded into the array.
                        //Add this frame to the timeline.
                        animation.addFrame(new Frame(grid));
                        lst_frames.Items.Add("Frame " + Convert.ToString(animation.getLength()));
                    }

                    //Close the file for reading
                    br.Close();
                    //Set the current frame to the first frame in the animation
                    lst_frames.SelectedIndex = 0;
                    pic_main.Refresh();
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("You need to enter a file name first!");
                }
                catch (Exception e)
                {
                    //If an exception occurs, display the associated error message
                    MessageBox.Show("An error occurred when trying to load the file: " + e.Message);
                }
            }
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //When the user decides to load a project, they are prompted with a load dialog and then the loading procedure is called
            showLoadDialog();
            loadFromFile();
        }
        public void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //This handles the exporting of projects to C code.
            //Firstly, display the export form so the user can set the export settings
            export frm_export = new export();
            frm_export.speed = defaultSpeed;

            //If the user submits the form for export
            if (frm_export.ShowDialog() == DialogResult.OK)
            {
                //Calculate an estimate of the file size of the animation
                int estimatedFileSize = 4032 * (animation.getLength() + 4);
                DialogResult dr_size;

                //If the animation is estimated to be larger than the internal memory of the Arduino and the warning
                //feature is enabled
                if ((estimatedFileSize > 32000 * 8) && sizeWarnOnExport)
                {
                    //Send the user a warning message about the file size
                    dr_size = MessageBox.Show("The exported file may be too large to transfer to the Arduino. Are you sure that you want to export?",
                                                        "Warning", MessageBoxButtons.YesNo);

                    //If the user chooses to procede with export, call the export routine
                    if (dr_size == DialogResult.Yes)
                    {
                        animation.exportToC(frm_export.filepath,
                                            frm_export.useDictionaryCompression, frm_export.speed);
                    }
                }
                else
                {
                    //If the animation is not estimated to be too large, or the warning feature is disabled, just export anyway
                    animation.exportToC(frm_export.filepath,
                                        frm_export.useDictionaryCompression, frm_export.speed);
                }
            }
        }
        private void btn_addBlankFrame_Click(object sender, EventArgs e)
        {
            //Add a blank frame to the frames List and the timeline
            animation.addFrame(new Frame());
            lst_frames.Items.Add("Frame " + Convert.ToString(animation.getLength()));
        }
        private int average(int[] numbers)
        {
            //Find the mean of an array of integers
            int total = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                total += numbers[i];
            }
            return (total) / numbers.Length;
        }
        private void btn_addFromImage_Click(object sender, EventArgs e)
        {
            //Here is the code which is executed when the user chooses to add an image file as a frame
            int X, Y;
            Image img;
            Bitmap bmp;
            Color c;
            bool[,] grid = new bool[84, 48];
            OpenFileDialog ofd = new OpenFileDialog();
            //The filter means that only common image file formats are visible to the user
            ofd.Filter = "Image File|*.png;*.jpg;*.bmp";

            //If the user successfully chooses a file
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Load the file and convert it to a bitmap
                img = Image.FromFile(ofd.FileName);
                bmp = new Bitmap(img);

                //Iterate through every pixel in the image
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        //Get the pixel at (x,y) from the bitmap
                        c = bmp.GetPixel(x, y);
                        //Since the frame and image are likely to have different resolutions, determine the scale factors and multiply the coordinates by these.
                        X = Convert.ToInt32(x * ((float)83 / bmp.Width));
                        Y = Convert.ToInt32(y * ((float)47 / bmp.Height));

                        //If the average of the red, green and blue values in the pixel (i.e the brightness) are in the upper half
                        if (average(new int[] { c.R, c.G, c.B }) >= 128)
                        {
                            //Set the frame pixel to white
                            grid[X, Y] = false;
                        }
                        else
                        {
                            //Set the frame pixel to black
                            grid[X, Y] = true;
                        }

                    }
                }

                //Add the frame to the frames List and the timeline.
                lst_frames.Items.Add("Frame " + Convert.ToString(animation.getLength() + 1));
                animation.addFrame(new Frame(grid));
                lst_frames.SelectedIndex++;
                pic_main.Refresh();
            }
        }
        private void btn_removeFrame_Click(object sender, EventArgs e)
        {
            //Get the index of the currently selected frame
            int index = lst_frames.SelectedIndex;
            //Make sure that the animation is at least 2 frames long so once the frame is removed the animation is not empty but there is still at least single frame
            if (animation.getLength() >= 2)
            {
                //delete the frame from the frame List and the timeline
                animation.deleteFrame(index);
                lst_frames.Items.RemoveAt(index);
                //set the first frame as the current frame
                lst_frames.SelectedIndex = 0;
                pic_main.Refresh();
            }
        }
        private void btn_copyFrame_Click(object sender, EventArgs e)
        {
            //get the currently selected frame and store it in oldFrame
            Frame oldFrame = animation.getCurrentFrame();
            //create a new boolean array
            bool[,] grid = new bool[84, 48];
            for (int x = 0; x < 84; x++)
            {
                for (int y = 0; y < 48; y++)
                {
                    //copy each pixel value
                    grid[x, y] = oldFrame.getPixel(x, y);
                }
            }
            //create a new frame using the grid
            Frame newFrame = new Frame(grid);
            //add a new frame using the data from the selected frame
            animation.addFrame(newFrame);
            //add a reference to the new frame in the timeline
            lst_frames.Items.Add("Frame " + Convert.ToString(animation.getLength()));
        }
        private void lst_frames_SelectedIndexChanged(object sender, EventArgs e)
        {
            //This method is run every time that the selected frame in the timeline is changed
            //A value of -1 is returned if no frame in the timeline is selected, so check for this to prevent an error
            if (lst_frames.SelectedIndex != -1)
            {
                int tmp = lst_frames.SelectedIndex;
                //update the current frame value in animation to match the timeline
                animation.setCurrentFrame(tmp);
                //refresh the pictureBox so that the newly selected frame is displayed
                pic_main.Refresh();
            }
        }
        private void pic_main_Paint(object sender, PaintEventArgs e)
        {
            //This routine handles the drawing of the main picturebox so that it can display frames
            //Use the picturebox graphics and store a reference to them in g
            Graphics g = e.Graphics;
            //Clear the picturebox to white
            g.Clear(Color.White);
            Rectangle rect;

            //Iterate through every pixel in the frame
            for (int x = 0; x < 84; x++)
            {
                for (int y = 0; y < 48; y++)
                {
                    //Retrieve the pixel data for the point (x, y) in the current frame
                    if (animation.getCurrentFrame().getPixel(x, y))
                    {
                        //Define a rectangle which will be the visual representation of a frame pixel
                        rect = new Rectangle(x * 10, y * 10, 10, 10);
                        //Draw the rectangle the colour black
                        g.FillRectangle(Brushes.Black, rect);
                    }
                }
            }

            //These two loops are used to draw the grid lines which make editing the grid a little easier since they show the border between pixels.
            for (int i = 10; i < 480; i += 10)
            {
                g.DrawLine(Pens.LightGray, 0, i, 840, i);
            }
            for (int i = 10; i < 840; i += 10)
            {
                g.DrawLine(Pens.LightGray, i, 0, i, 480);
            }

            //This draws the selection rectangle as a red outline.
            g.DrawRectangle(Pens.Red, animation.getSelection());
        }
        private void pic_main_MouseDown(object sender, MouseEventArgs e)
        {
            //The X and Y coordinate of the frame pixel currently being edited are found by dividing by 10 since each frame pixel is displayed as 10 pixels wide in the studio
            oldx = e.X / 10;
            oldy = e.Y / 10;

            //Some tools make use of a colour which is applied to the frame. This code changes the colour
            //depending on whether the left or right mouse button is being pressed
            if (e.Button == MouseButtons.Left)
            {
                colour = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                colour = false;
            }

            //This switch statement is used to run a different procedure depending on the currently selected tool (the index of which is stored in tool)
            switch (tool)
            {
                case 0:
                    animation.getCurrentFrame().flipPixel(oldx, oldy);
                    break;
                case 2:
                    animation.getCurrentFrame().fillCan(oldx, oldy, colour);
                    break;
                case 7: //For the selection rotate tool, clicking left or right will rotate the selection in different directions
                    if (e.Button == MouseButtons.Left)
                    {
                        animation.selectionRotateLeft();
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                       animation.selectionRotateRight();
                    }
                    break;
            }

            //Redraw the main picturebox to display any changes to the frame
            pic_main.Refresh();
        }
        private void pic_main_MouseUp(object sender, MouseEventArgs e)
        {
            //Get the x and y coordinate of the frame pixel being edited
            int x = e.X / 10;
            int y = e.Y / 10;

            //The switch statement allows procedures to be run for the different tools to produce different behaviors.
            //The tools here work in a click and drag style. The original coordinates of the mouse at the start of the
            //drag are stored in oldx and oldy. The end coordinates of the mouse are stored in x and y.
            switch (tool)
            {
                case 4:
                    animation.getCurrentFrame().lineTool(oldx, oldy, x, y, colour);
                    break;
                case 5:
                    animation.selectRegion(oldx, oldy, x, y);
                    break;
                case 6:
                    animation.selectionMove(x, y);
                    break;
            }

            pic_main.Refresh();
        }
        //The list of routines below are used to set the value of the variable tool depending on which tool the user selects by clicking its button
        private void btn_togglePixel_Click(object sender, EventArgs e)
        {
            tool = 0;
        }
        private void btn_pen_Click(object sender, EventArgs e)
        {
            tool = 1;
        }
        private void btn_fillCan_Click(object sender, EventArgs e)
        {
            tool = 2;
        }
        private void btn_sprayCan_Click(object sender, EventArgs e)
        {
            tool = 3;
        }
        private void btn_straightLine_Click(object sender, EventArgs e)
        {
            tool = 4;
        }
        private void btn_selectRegion_Click(object sender, EventArgs e)
        {
            tool = 5;
        }
        private void btn_moveSelection_Click(object sender, EventArgs e)
        {
            tool = 6;
        }
        private void btn_rotateSelection_Click(object sender, EventArgs e)
        {
            tool = 7;
        }
        //These next two routines instantly colour the entire grid either black or white and are run when the user clicks the clear to buttons
        private void btn_clearBlack_Click(object sender, EventArgs e)
        {
            animation.getCurrentFrame().clearFrame(true);
            pic_main.Refresh();
        }
        private void btn_clearWhite_Click(object sender, EventArgs e)
        {
            animation.getCurrentFrame().clearFrame(false);
            pic_main.Refresh();
        }
        private void btn_play_Click(object sender, EventArgs e)
        {
            //This routine is run when the user clicks the play button. The interval for which frames are displayed for is calculated and the playback time started
            tmr_main.Interval = (11 - trk_speed.Value) * 100;
            tmr_main.Start();
        }
        private void btn_pause_Click(object sender, EventArgs e)
        {
            //clicking the pause button stops the timer
            tmr_main.Stop();
        }
        private void btn_stop_Click(object sender, EventArgs e)
        {
            //clicking the stop button stops the timer and also resets the current frame to be the first frame
            lst_frames.SelectedIndex = 0;
            tmr_main.Stop();
            pic_main.Refresh();
        }
        private void tmr_main_Tick(object sender, EventArgs e)
        {
            //This is the playback timer tick event. Navigates to the next frame along unless it has reached the end of the animation where it will go back to the start
            if (lst_frames.SelectedIndex < animation.getLength() - 1)
            {
                lst_frames.SelectedIndex++;
            }
            else
            {
                lst_frames.SelectedIndex = 0;
            }
            //Redraw the main picturebox to display the current frame
            pic_main.Refresh();
        }
        private void btn_applyFilter_Click(object sender, EventArgs e)
        {
            //This code handles the frame filter functionality of the studio.
            //The user can select different filters from a listbox, with the selected filter being stored in mode
            int mode = cmb_filter.SelectedIndex;

            //This switch statement calls different filter routines depending on which filter is selected
            switch (mode)
            {
                case 0:
                    animation.getCurrentFrame().invertFilter();
                    break;
                case 1:
                    animation.getCurrentFrame().distortFilter(animation.getWidth(), _r);
                    break;
            }
            //Redraw the main picturebox to display the changes
            pic_main.Refresh();
        }
        private void trk_speed_Scroll(object sender, EventArgs e)
        {
            //If the playback speed slider is adjusted, even in playback, the timer interval is updated so the changes take effect
            tmr_main.Interval = (11 - trk_speed.Value) * 100;
        }
        private void trk_width_Scroll(object sender, EventArgs e)
        {
            //When the user adjusts the tool width slider, update the value stored in the animation class
            animation.setWidth(trk_width.Value);
        }
        private void pic_main_MouseMove(object sender, MouseEventArgs e)
        {
            //This routine is run repeatedly when the user moves their cursor over the picturebox where the user edits a frame.
            //This is useful for some editing tools that draw repeatedly which allows for the drawing of continuous lines.

            //This line checks that the user is holding down the left or right mouse button
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                //These lines retrieve the x and y coordinates of the mouse in the pixel grid. The division by 10 is needed
                //since every pixel in the grid is actually displayed as 10 pixels wide, so effectively converts screen
                //coordinates to the actual pixel coordinates. The position of the mouse is given via Cursor.Position, but
                //this returns the absolute position on the screen. To get the mouse position relative to the picturebox,
                //we subtract the location of the window and the location of the picturebox and the location of the
                //splitContainer which allow the different areas of the window to be resized.
                int x = (Cursor.Position.X - this.Location.X - pic_main.Location.X - splitContainer.Location.X) / 10;
                int y = (Cursor.Position.Y - this.Location.Y - pic_main.Location.Y - splitContainer.Location.Y) / 10;

                //The switch statement allows for different algorithms to be selected depending on the currently selected tool
                switch (tool)
                {
                    case 1:
                        animation.getCurrentFrame().pen(x, y, colour, animation.getWidth());
                        break;
                    case 3:
                        animation.getCurrentFrame().sprayCan(x, y, colour, animation.getWidth(), _r);
                        break;
                }

                //Redraw the picturebox to reflect any changes to the frame
                pic_main.Refresh();
            }
        }
        private void btn_frameUp_Click(object sender, EventArgs e)
        {
            //This is run when the user clicks the button to move a frame up in the animation.

            //Returns the index of the selected frame
            int oldIndex = lst_frames.SelectedIndex;
            //Make sure that the frame is not the first in the animation so it can be moved up
            if (oldIndex > 0 && oldIndex != -1)
            {
                //move the frame up one in the _frames list
                animation.moveFrame(oldIndex, oldIndex - 1);
                //get the corresponding timeline object
                object frame = lst_frames.Items[oldIndex].ToString();
                //remove the old timeline object
                lst_frames.Items.RemoveAt(oldIndex);
                //add the object back to the timeline at a different position
                lst_frames.Items.Insert(oldIndex - 1, frame);
                lst_frames.SelectedIndex = oldIndex - 1;
            }
        }
        private void btn_frameDown_Click(object sender, EventArgs e)
        {
            //This works similarly to the procedure above, except that it moves frames in the opposite direction
            int oldIndex = lst_frames.SelectedIndex;
            //Make sure that the frame is not the last in the animation
            if (oldIndex < animation.getLength() - 1 && oldIndex != -1)
            {
                animation.moveFrame(oldIndex, oldIndex + 1);
                object frame = lst_frames.Items[oldIndex].ToString();
                lst_frames.Items.RemoveAt(oldIndex);
                lst_frames.Items.Insert(oldIndex + 1, frame);
                lst_frames.SelectedIndex = oldIndex + 1;
            }
        }
    }
}
