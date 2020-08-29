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
    public class Animation
    {
        /*Here I am declaring the fields which will be used in the animation class. These include a random number generator, the pen width,
        the index of the frame being edited, the selection rectangle and the lists which are used to store the animation frames.*/

        private List<Frame> _frames;
        private List<Frame> _compressionList;
        private Rectangle _selection;
        private int _currentFrame;
        private int _width;
       
        //This method is the constructor of the class. It is being used to define some of the values above and also to assign a default
        //value of 1 for the pen width.
        public Animation()
        {
            _frames = new List<Frame>();
            _compressionList = new List<Frame>();
            _selection = new Rectangle(0, 0, 0, 0);
            _width = 1;
        }

        //This returns the selected region, which is stored as a Rectangle.
        public Rectangle getSelection()
        {
            return _selection;
        }

        //Returns the pen width value
        public int getWidth()
        {
            return _width;
        }

        //This function is used when exporting animations. The exported C code needs to have the pin values defined via #define
        // statements. These values do not change based on the contents of the animation as they are needed in every animation.
        public string getArduinoHeaders()
        {
            return @"
//These statements are used to assign the pins and their states a formal name so that it is clearer when we access them later.
//The LCD_X and LCD_Y define statements are used to indicate that this animation is for a screen with this resolution.
#define PIN_SCE   7
#define PIN_RESET 6
#define PIN_DC    5
#define PIN_SDIN  4
#define PIN_SCLK  3
#define LCD_C     LOW
#define LCD_D     HIGH
#define LCD_X     84
#define LCD_Y     48
";
        }

        //Just like the method above, the method getArduinoCode() is used to output C code that remains constant and needs to be
        // exported with every animation, no matter what the contents. The actual C code which it exports are the procedures which output
        // the stored frames and set the pixel values.
        public string getArduinoCode()
        {
            //the @ symbol here tells the compiler to use multiline string
            return @"  
//This routine is used to set up the screen and is only run once when the Arduino is powered on
void LcdInitialise(void)
{
  pinMode(PIN_SCE, OUTPUT);
  pinMode(PIN_RESET, OUTPUT);
  pinMode(PIN_DC, OUTPUT);
  pinMode(PIN_SDIN, OUTPUT);
  pinMode(PIN_SCLK, OUTPUT);
  digitalWrite(PIN_RESET, LOW);
  digitalWrite(PIN_RESET, HIGH);
  LcdWrite(LCD_C, 0x21 );  // LCD Extended Commands.
  LcdWrite(LCD_C, 0xB1 );  // Set LCD VOP (Contrast). 
  LcdWrite(LCD_C, 0x04 );  // Set Temp coefficient. //0x04
  LcdWrite(LCD_C, 0x14 );  // LCD bias mode 1:48. //0x13
  LcdWrite(LCD_C, 0x0C );  // LCD in normal mode.
  LcdWrite(LCD_C, 0x20 );
  LcdWrite(LCD_C, 0x0C );
}

void gotoXY(int x, int y)
{
  LcdWrite( 0, 0x80 | x);  // Column.
  LcdWrite( 0, 0x40 | y);  // Row. 
}

//This routine tells the screen to display a group of 8 pixels, which are stored in the byte 'data'.
//To display complete frames at a time, we need to call this for every byte in the frame arrays.
void LcdWrite(byte dc, byte data)
{
  digitalWrite(PIN_DC, dc);
  digitalWrite(PIN_SCE, LOW);
  shiftOut(PIN_SDIN, PIN_SCLK, MSBFIRST, data);
  digitalWrite(PIN_SCE, HIGH);
}

//This routine calls the LcdWrite routine multiple times so that the entire frame can be displayed.
void LcdBitmap(const byte my_array[]){
  for (int index = 0 ; index < (LCD_X * LCD_Y / 8) ; index++)   
    LcdWrite(LCD_D, pgm_read_byte((uint32_t)my_array + index));
    //the pgm_read_byte function retrieves a group of 8 pixels from a frame which is stored in the flash memory
}

void setup(void)
{
  LcdInitialise();
  gotoXY(0,0);
}";
        }

        // This function is used to generate a subroutine in C code for the export function. The task of the subroutine is to iterate
        // through the frames in the animation indefinately, displaying the frames with a delay between then.
        public string getCompressedPlaybackRoutine()
        {
            string output = "";
            int temp;
            //The for loop iterates through the frame list
            for (int i = 0; i < getLength(); i++)
            {
                //The time that each frame is shown for is customisable by the user. The delay function prevents the next frame
                //from being shown for a certain amount of time. The amount of time is stored in playbackDelay, which is defined
                //earlier
                output += "         delay(playbackDelay);\r\n";
                temp = _compressionList.IndexOf(getFrame(i));

                if (temp == -1)
                {
                    output += "         LcdBitmap(frame" + Convert.ToString(i) + ");\r\n";
                    //If there are no frames in _compressionList which match the frame at index i in frames, 
                    //then write the code to display the frame stored at index i in frames
                }
                else
                {
                    //If there is a frame in _compressionList which matches index i in frames, then there is
                    //a repeated frame and so the value stored in temp should be written. This allows repeated frames
                    //to be stored only once and then displayed simply by referencing the frame index.
                    output += "         LcdBitmap(frame" + Convert.ToString(temp) + ");\r\n";
                }
            }
            return output;
        }

        //This function generates a C code subroutine for the export function. This is different to the function above
        //since it outputs the code to playback the frames without dictionary compression.
        public string getPlaybackRoutine()
        {
            string output = "";
            //This allows the exported code to iterate through all the frames in order
            for (int i = 0; i < getLength(); i++)
            {
                //Displays each frame for the time specificed in playbackDelay by delaying
                output += "         delay(playbackDelay);\r\n";
                //outputs the frame stored at index i
                output += "         LcdBitmap(frame" + Convert.ToString(i) + ");\r\n";
            }
            return output;
        }

        //Returns the frame object at the index
        public Frame getFrame(int index)
        {
            return _frames.ElementAt(index);
        }

        //returns the frame which is at the index _currentframe
        public Frame getCurrentFrame()
        {
            return getFrame(_currentFrame);
        }

        //sets the field width value, which is used in some editing tools
        public void setWidth(int width)
        {
            _width = width;
        }

        //sets the frame to edit / view
        public void setCurrentFrame(int newIndex)
        {
            _currentFrame = newIndex;
        }

        //used to define the field _selection, useful for when the user uses their cursor to select a rectangle of pixels
        public void setSelection(Rectangle _selection)
        {
            this._selection = _selection;
        }

        //this procedure calculates what the values in the field _selection should be. When the user selects a region with the cursor,
        //4 values will be produced with will identify the two opposite corners of the rectangle. In order to display this, these values
        //have to be converted to the Rectangle type which means that the width and height need to be calculated. The if statements are
        //used to make sure that the values of rectangle are calculated correctly even if the user selected the region backwards
        public void selectRegion(int oldx, int oldy, int x, int y)
        {
            if (x > oldx)
            {
                _selection.Width = (x - oldx) * 10;
                oldx *= 10;
                //we are multiplying these by 10 as each pixel on the grid is actually displayed as 10 pixels wide in the editor.
                //This allows use to convert from pixel coordinates to the screen coordinates where they are displayed.
            }
            else
            {
                _selection.Width = Math.Abs((x - oldx) * 10);
                oldx = x * 10;
            }

            if (y > oldy)
            {
                _selection.Height = (y - oldy) * 10;
                oldy *= 10;
            }
            else
            {
                _selection.Height = Math.Abs((y - oldy) * 10);
                oldy = y * 10;
            }

            _selection.X = oldx;
            _selection.Y = oldy;
        }

        //This function translates the selected region of pixels stored in _selection to the coordinate (x,y).
        public void selectionMove(int x, int y)
        {
            int oldx = _selection.X / 10;
            int oldy = _selection.Y / 10;
            int height = _selection.Height / 10;
            int width = _selection.Width / 10;
            //Division by 10 as each pixel in the editor is displayed as 10 pixels wide on the screen

            bool[,] temp = new bool[width, height];
            //The pixels in the selected region are stored in temp
            //These for loops iterate through all of the pixels in the selected region so each can be dealt with seperately
            for (int X = 0; X < width; X++)
            {
                for (int Y = 0; Y < height; Y++)
                {
                    //copies the pixel in the selected region to temp
                    temp[X, Y] = getCurrentFrame().getPixel(oldx + X, oldy + Y);
                    //sets the old position of the pixels to white
                    getCurrentFrame().setPixel(oldx + X, oldy + Y, false);
                    //copies the original pixel value in temp to the new location
                    getCurrentFrame().setPixel(X + x, Y + y, temp[X, Y]);
                }
            }
        }

        //The next to procedures are used to rotate the pixels inside the region _selection.
        public void selectionRotateLeft()
        {
            //Declare a temporary array to store the rotated matrix in
            bool[,] newSelection = new bool[_selection.Height / 10, _selection.Width / 10];
            int newY = 0;
            int newX = 0;
            //These loops iterate through the pixels in the selected region
            for (int x = _selection.Height / 10 - 1; x >= 0; x--)
            {
                newY = 0;
                for (int y = 0; y < _selection.Width / 10; y++)
                {
                    //copy the pixels to the array, but store them at the position (newX, newY) to effecitvely rotate them
                    newSelection[newX, newY] = getCurrentFrame().getPixel(x + _selection.X / 10, y + _selection.Y / 10);
                    newY++;
                }
                newX++;
            }

            for (int x = 0; x < _selection.Width / 10; x++)
            {
                for (int y = 0; y < _selection.Height / 10; y++)
                {
                    //copy the pixels from the temporary array back to the main grid
                    getCurrentFrame().setPixel(x + _selection.X / 10, y + _selection.Y / 10, newSelection[y, x]);
                }
            }
        }

        //This procedure is almost identical to the one above but rotates the pixels in the opposite direction
        public void selectionRotateRight()
        {
            bool[,] newSelection = new bool[_selection.Height / 10, _selection.Width / 10];
            int newY = 0;
            int newX = 0;
            for (int y = _selection.Width / 10 - 1; y >= 0; y--)
            {
                newX = 0;
                for (int x = 0; x < _selection.Height / 10; x++)
                {
                    newSelection[newX, newY] = getCurrentFrame().getPixel(x + _selection.X / 10, y + _selection.Y / 10);
                    newX++;
                }
                newY++;
            }

            for (int x = 0; x < _selection.Width / 10; x++)
            {
                for (int y = 0; y < _selection.Height / 10; y++)
                {
                    getCurrentFrame().setPixel(x + _selection.X / 10, y + _selection.Y / 10, newSelection[y, x]);
                }
            }
        }

        //Inserts the a frame to a certain position in the List _frames
        public void insertFrame(int index, Frame frame)
        {
            //The if statement is used to avoid crashes caused by inserting a frame outside the list.
            if (index > 0 && index <= _frames.Count)
            {
                _frames.Insert(index, frame);
            }
        }

        //Adds a frame to the end of the _frames list
        public void addFrame(Frame frame)
        {
            _frames.Add(frame);
        }

        //Deletes a frame at the index
        public void deleteFrame(int index)
        {
            _frames.RemoveAt(index);
        }

        //Moves a frame from the position oldindex to newindex
        public void moveFrame(int oldIndex, int newIndex)
        {
            //These if statements make sure that the positions are not outside of the list
            if (oldIndex > 0 && oldIndex < getLength())
            {
                if (newIndex > 0 && newIndex <= getLength())
                {
                    Frame temp = _frames.ElementAt(oldIndex);
                    deleteFrame(oldIndex);
                    insertFrame(newIndex, temp);
                    //load the frame into memory, delete the old frame, then copy it back to the new position
                }
            }
        }

        //returns the length of the _frame list
        public int getLength()
        {
            return _frames.Count;
        }    

        //writes frames to _compressionList, writing repeated frames only once to save space. Outputs these frames in C code format
        public string compressFramesToC()
        {
            string output = "";
            int count = 0;

            for (int i = 0; i < getLength(); i++)
            {
                //checks that the current frame is not already in the list
                //we can only use the .Contains method because the frame has the isEqual method.
                if (!_compressionList.Contains(getFrame(i)))
                {
                    _compressionList.Add(getFrame(i));
                    output += getFrame(i).convertToC(count) + "\r\n";
                    //converts the frame to C code format
                    count++;
                }
            }

            return output;
        }

        //outputs all of the frames in C code format without compression, so repeated frames are ignored and potentially defined multiple times.
        public string framesToC()
        {
            string output = "";
            for (int i = 0; i < getLength(); i++)
            {
                output += getFrame(i).convertToC(i) + "\r\n";
            }
            return output;
        }

        //This method is the master export method which calls the other export methods in the correct order. It writes what these
        //methods return to a C code source file.
        public void exportToC(string filepath, bool useDictionaryCompression, int speed)
        {
            //The try statement allows for exception handling to prevent the program crashing
            try
            {
                //open the file for writing
                StreamWriter sr = new StreamWriter(filepath);
                //defines C code playbackDelay variable as being 1000/speed, since the greater the speed the smaller
                //the delay between frames. Writes this to the file.
                sr.WriteLine("const int playbackDelay = {0};", Convert.ToString(1000 / speed));
                sr.WriteLine(@"//this is the delay between frames in milliseconds.
//A higher value will mean that each frame will be displayed for longer and so the animation will play more slowly.");


                //writes the list of #define statements necessary for the C code program to function
                sr.WriteLine(getArduinoHeaders());
                //calls different functions depending on whether dictionary compression is enabled or not.

                sr.WriteLine(@"//The frames are stored here as byte arrays. They are also constant since they do not need to change and have the PROGMEM attribute which allows
//the frames to be stored in the 32KB flash memory rather than the smaller 2KB SRAM, so there is room for more frames.");

                //convert the frames to C code format and write them to the file, calling different methods depending on whether compression is being used.
                if (useDictionaryCompression)
                {
                    sr.WriteLine(compressFramesToC());
                }
                else
                {
                    sr.WriteLine(framesToC());
                }

                //writes several C code methods needed to playback the animation.
                sr.WriteLine(getArduinoCode());

                //The C code subroutine will be given the name "loop". The while loop below ensures that the code inside runs indefinitely.
                sr.WriteLine("void loop(void)");
                sr.WriteLine("{");
                sr.WriteLine(@"//This while loop will run forever because of the 'true'.
//This will allow animations to play repeatedly");
                sr.WriteLine("  while (true)");
                sr.WriteLine("  {");
                sr.WriteLine(@"	//Each frame here is displayed using the LcdBitmap function.
//There is then a delay which makes sure that the frame is displayed for a set amount of time.");

                //writes different code to playback the animation based on whether dictionary compression is enabled or not.
                if (useDictionaryCompression)
                {
                    sr.WriteLine(getCompressedPlaybackRoutine());
                }
                else
                {
                    sr.WriteLine(getPlaybackRoutine());
                }

                sr.WriteLine("  }");
                sr.WriteLine("}");
                //Closes the file for writing
                sr.Close();
                //Clears the values temporarily stored in _compressionList to free up memory
                _compressionList.Clear();
                //Display a message to confirm to the user that the animation successfully exported
                MessageBox.Show("The animation has been successfully exported as C Code.");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("You need to enter a file name first!");
            }
            catch (Exception e)
            {
                //If an exception occurs, catch it and display the error message behind it.
                MessageBox.Show("Failed to export the animation as C Code: " + e.Message);
            }

        }
    }
}
