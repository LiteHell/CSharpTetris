﻿using System;
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
        public Form1()
        {
            InitializeComponent();
            TetrisControl tetris = new TetrisControl();
            tetris.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(tetris);
        }
    }
}
