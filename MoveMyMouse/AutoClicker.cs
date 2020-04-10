using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveMyMouse
{
    public partial class AutoClicker : Form
    {
        public AutoClicker()
        {
            InitializeComponent();
        }

        private static bool flipped = false;
        private static int counter = 1;
        private static int maxcount = 10;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Win32.POINT p = new Win32.POINT();
            Win32.GetCursorPos(ref p);
            if (flipped)
            {
                p.x = p.x + 5;
                p.y = p.y + 5;
            }
            else
            {
                p.x = p.x - 5;
                p.y = p.y - 5;

            }
            flipped = !flipped;

            Win32.LeftClick();
            //counter += 1;
            //if (counter == maxcount) counter = 1;
            //const string alttab = "%{Tab}";
            //string keys = "";
            //for (int j = 0; j < counter; ++j) keys += alttab;
            //SendKeys.SendWait(keys);
            Win32.SetCursorPos(p.x, p.y);
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Interval = (int)numericUpDown1.Value;
                timer1.Start();
                button1.Text = "Stop";
            }
            else {
                timer1.Stop();
                button1.Text = "Start";
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
