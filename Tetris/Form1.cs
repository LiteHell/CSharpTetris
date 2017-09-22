using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        TetrisControl tetris = new TetrisControl();
        public Form1()
        {
            InitializeComponent();
            tetris.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(tetris);
            tetris.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tetris.HoldTetrimino();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tetris.UnholdTetrimino();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tetris.RotateTetrimino(TetriminoRotation.Left);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tetris.RotateTetrimino(TetriminoRotation.Right);
        }
    }
}
