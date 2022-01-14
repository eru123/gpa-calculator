using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GPACalculator
{
    public partial class Main : Form
    {
        Handler handler;

        public Main()
        {
            InitializeComponent();

            NumericUpDown[] grades = {g1, g2, g3, g4, g5, g6, g7, g8};
            NumericUpDown[] credits = {c1, c2, c3, c4, c5, c6, c7, c8};

            handler = new Handler(grades, credits, result);
        }

        private void r1_Click(object sender, EventArgs e)
        {
            handler.reset(1);
        }
        
        private void r2_Click(object sender, EventArgs e)
        {
            handler.reset(2);
        }

        private void r3_Click(object sender, EventArgs e)
        {
            handler.reset(3);
        }

        private void r4_Click(object sender, EventArgs e)
        {
            handler.reset(4);
        }

        private void r5_Click(object sender, EventArgs e)
        {
            handler.reset(5);
        }

        private void r6_Click(object sender, EventArgs e)
        {
            handler.reset(6);
        }

        private void r7_Click(object sender, EventArgs e)
        {
            handler.reset(7);
        }

        private void r8_Click(object sender, EventArgs e)
        {
            handler.reset(8);
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            handler.calculate();
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            handler.clear();
        }
    }
}
