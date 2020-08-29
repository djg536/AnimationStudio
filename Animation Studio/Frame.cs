using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Animation_Studio
{
    public class Frame : IEquatable<Frame> //this is a child of the type IEquatable, which means it can be compared to other frame instances easily
    {
        //Declares the boolean array _grid which will store the boolean pixel values
        private bool[,] _grid;

        //This constructor for the frame allows values for _grid to be assigned
        public Frame(bool[,] grid)
        {
            this._grid = grid;
        }

        //This is the plain constructor for the frame which does not yet assign values to _grid
        public Frame()
        {
            _grid = new bool[84, 48];
        }

        //This method is used to validate whether this frame is equal to another frame
        public virtual bool Equals(Frame frame)
        {
            //these loops iterate through every pixel in the frame
            for (int x = 0; x < 84; x++)
            {
                for (int y = 0; y < 48; y++)
                {
                    //if two pixels are not equal
                    if (frame.getPixel(x, y) != getPixel(x, y))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //gets the pixel value at position (x, y)
        public bool getPixel(int x, int y)
        {
            //These if statements make sure that a location outside of the grid is not accessed, which would cause a crash
            if (x >= 0 && x < 84)
            {
                if (y >= 0 && y < 48)
                {
                    return _grid[x, y];
                }
            }
            //If the coordinates point to a location outside of the grid, return false
            return false;
        }

        //sets the pixel value at position (x, y) to colour
        public void setPixel(int x, int y, bool colour)
        {
            //These if statements make sure that a location outside of the grid is not accessed, which would cause a crash
            if (x >= 0 && x < 84)
            {
                if (y >= 0 && y < 48)
                {
                    _grid[x, y] = colour;
                }
            }
        }

        //Writes every pixel in the frame to the same colour by setting each value seperately whilst iterating through the frame
        public void clearFrame(bool colour)
        {
            for (int x = 0; x < 84; x++)
            {
                for (int y = 0; y < 48; y++)
                {
                    setPixel(x, y, colour);
                }
            }
        }

        //sets each pixel value to the opposite of itself to invert the frame
        public void invertFilter()
        {
            for (int x = 0; x < 84; x++)
            {
                for (int y = 0; y < 48; y++)
                {
                    flipPixel(x, y);
                    //sets each individual pixel to NOT the current value, essentially flipping it
                }
            }
        }

        //Distorts the frame by moving each pixel up and down by a random amount.
        public void distortFilter(int _width, Random _r)
        {
            for (int x = _width; x < 84 - _width; x++)
            {
                for (int y = _width; y < 48 - _width; y++)
                {
                    //The random value is between -_width and _width
                    setPixel(x + _r.Next(-_width, _width + 1), y + _r.Next(-_width, _width + 1), getPixel(x, y));
                }
            }
        }

        //This is the code behind the straight line tool. It draws a line between (x1,y1) and (x2,y2))
        public void lineTool(int x1, int y1, int x2, int y2, bool colour)
        {
            float gradient = (y1 - y2) / (float)(x1 - x2);
            //The gradient of the line is calculated via (change in y) / (change in x). Floating point arithmetic is forced with (float).
            //These for loops draw the pixels in the correct position by using the previously calculated gradient.
            //The if statements ensure that different algorithms are used for different gradients.
            //The different algorithms are needed to account for rounding errors which would occur which would prevent a complete line from being drawn.

            //This first if statement makes sure that if the magnitude of the gradient is smaller than one, then multiply by the gradient to draw the line
            if (gradient > -1 && gradient < 1)
            {
                for (int i = 0; i < x1 - x2; i++)
                {
                    setPixel(x1 - i, y1 + Convert.ToInt32(-i * gradient), colour);
                }
                for (int i = 0; i < x2 - x1; i++)
                {
                    setPixel(x1 + i, y1 + Convert.ToInt32(i * gradient), colour);
                }
            }
            else if (gradient <= -1 || gradient >= 1) //If the gradient has a magnitude of at least than one, then divide by gradient to draw the line
            {
                for (int i = 0; i < y1 - y2; i++)
                {
                    setPixel(x1 + Convert.ToInt32(-i / gradient), y1 - i, colour);
                }
                for (int i = 0; i < y2 - y1; i++)
                {
                    setPixel(x1 + Convert.ToInt32(i / gradient), y1 + i, colour);
                }
            }
        }

        //Toggles the value of a pixel by setting it to NOT the old value. ! denotes NOT
        public void flipPixel(int x, int y)
        {
            setPixel(x, y, !getPixel(x, y));
        }

        //These two functions are called repeatedly when the user is using the pen or spray can tool.
        public void pen(int x, int y, bool colour, int _width)
        {
            for (int X = -_width; X < _width - 1; X++)
            {
                for (int Y = -_width; Y < _width - 1; Y++)
                {
                    //These for loops allow the tool to be of varying width by accounting for pixels around the cursor
                    setPixel(x + X, y + Y, colour);
                }
            }
        }

        public void sprayCan(int x, int y, bool colour, int _width, Random _r)
        {
            //calculate a random number between -_width and _width
            int randomX = _r.Next(-_width, _width + 1);
            int randomY = _r.Next(-_width, _width + 1);

            //sets the pixel at the random corrdinates near the cursor to colour
            setPixel(x + randomX, y + randomY, colour);
        }

        //This is a recursive algorithm for the fill can tool
        public void fillCan(int x, int y, bool colour)
        {
            //These for loops allow every pixel in the frame to be accessed
            if (x >= 0 && x < 84)
            {
                if (y >= 0 && y < 48)
                {
                    //These if statements are used to check whether the value of each surrounding pixel is NOT the fill colour-
                    //i.e. it should be filled if it is not.
                    if (getPixel(x, y) != colour)
                    {
                        setPixel(x, y, colour);
                    }
                    if (getPixel(x - 1, y) != colour)
                    {
                        fillCan(x - 1, y, colour);
                    }
                    if (getPixel(x, y - 1) != colour)
                    {
                        fillCan(x, y - 1, colour);
                    }
                    if (getPixel(x + 1, y) != colour)
                    {
                        fillCan(x + 1, y, colour);
                    }
                    if (getPixel(x, y + 1) != colour)
                    {
                        fillCan(x, y + 1, colour);
                    }
                }
            }
        }

        //converts a single frame to C code format.
        public string convertToC(int index)
        {
            bool pixel;
            //The frame will be stored as a char array in the C code, hence this declaration
            string output = "const PROGMEM byte frame";
            output += Convert.ToString(index);
            output += "[] = {";

            string tempStr = "";
            byte tempByte;

            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 84; x++)
                {
                    for (int i = 8; i > 0; i--)
                    {
                        //The frames need to be stored in a particular format or will not display correctly.
                        //The frame is divided into 6 rows of 8, with each 8 pixel byte being written in the order bottom up
                        pixel = getPixel(x, y * 6 + i);
                        if (pixel)
                        {
                            tempStr += "1";
                        }
                        else
                        {
                            tempStr += "0";
                        }
                        //Writes either a 0 or 1 based on the pixel boolean value
                    }
                    //Converts the string of 8 digits to a byte
                    tempByte = Convert.ToByte(tempStr, 2);
                    output += String.Format("0x{0:X}", tempByte) + ",";
                    //Writes the byte in the format 0x0000
                    tempStr = "";

                }
                output += "\r\n";
            }
            output += "};";

            return output;
        }

    }
}
