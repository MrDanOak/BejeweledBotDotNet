using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetBejewelledBot
{
    public partial class frmMain : Form
    {
        private BejeweledWindowManager m_BWM;
        private int tick = 0;

        public frmMain()
        {
            InitializeComponent();
            m_BWM = new BejeweledWindowManager();
            BejeweledColor.Collection = new List<Color>();
            BejeweledColor.Collection.Add(BejeweledColor.Blue);
            BejeweledColor.Collection.Add(BejeweledColor.Green);
            BejeweledColor.Collection.Add(BejeweledColor.Orange);
            BejeweledColor.Collection.Add(BejeweledColor.Purple);
            BejeweledColor.Collection.Add(BejeweledColor.Red);
            BejeweledColor.Collection.Add(BejeweledColor.White);
            BejeweledColor.Collection.Add(BejeweledColor.Yellow);
        }

        private void screenGrabTimer_Tick(object sender, EventArgs e)
        {
            tick++;
            m_BWM.GetScreenshot();
            m_BWM.GetColourGrid();
            m_BWM.CalculateMoves();
            pictureBox1.Image = m_BWM.ColourGrid;
            if (tick * screenGrabTimer.Interval == 60000)
            {
                screenGrabTimer.Stop();
                tick = 0;
                btnStart.Enabled = true;
            }
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            m_BWM.GetScreenshot();
            if (m_BWM.Calibrate())
            {
                MessageBox.Show("Calibrated");
            }
            else
            {
                MessageBox.Show("Couldn't calibrate");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            screenGrabTimer.Start();
            btnStart.Enabled = false;
        }
    }
}
