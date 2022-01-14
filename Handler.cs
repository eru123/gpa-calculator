using System.Windows.Forms;
using System;

namespace GPACalculator
{
    class Handler
    {
        enum STATE { INVALID, VALID }

        NumericUpDown[] g;
        NumericUpDown[] c;

        // array of state enum
        STATE[] valid = new STATE[8];
        Label r;

        public Handler(NumericUpDown[] grades, NumericUpDown[] credits, Label result)
        {   
            // give the handler access to the grades, credits and result objects
            g = grades;
            c = credits;
            r = result;
            
            // event handlers for each grade and credits
            for (int i = 0; i < g.Length; i++)
            {
                g[i].ValueChanged += new EventHandler(grade_ValueChanged);
                c[i].ValueChanged += new EventHandler(credits_ValueChanged);
            }
        }

        private void valueChanged(int i){
            valid[i] = g[i].Value > 0 && c[i].Value > 0 ? STATE.VALID : STATE.INVALID;
        }

        private void grade_ValueChanged(object sender, EventArgs e)
        {
            // get the index of the grade that changed
            int index = Array.IndexOf(g, sender);

            // update the state of the grade
            valueChanged(index);
        }

        private void credits_ValueChanged(object sender, EventArgs e)
        {
            // get the index of the grade that changed
            int index = Array.IndexOf(c, sender);

            // update the state of the grade
            valueChanged(index);
        }

        

        public void reset(int id)
        {   
            // clear row
            g[id - 1].Value = 0;
            c[id - 1].Value = 0;

            // clear result
            r.Text = "GPA Result: 0";
        }

        public void clear()
        {   
            // clear all grades and credits
            for (int i = 0; i < g.Length; i++)
            {
                g[i].Value = 0;
                c[i].Value = 0;
            }

            // clear result
            r.Text = "GPA Result: 0";
        }

        public void calculate()
        {   
            double gpa = 0;
            double credits = 0;

            // calculate GPA
            for (int i = 0; i < g.Length; i++)
            {
                // check if valid state
                if (valid[i] == STATE.VALID)
                {
                    // add grade to GPA
                    gpa += (double)g[i].Value * (double)c[i].Value;

                    // add credits to total
                    credits += (double)c[i].Value;
                }
            }
            
            // make sure that the credits are not 0
            if (credits > 0)
            {
                gpa /= credits;
            }


            // display GPA
            r.Text = "GPA Result: " + gpa.ToString();
        }

        public void setMaxGrade(int max)
        {
            // change all grades maximum to max
            for (int i = 0; i < g.Length; i++)
            {
                g[i].Maximum = max;
            }
        }

        public void setMaxCredit(int max)
        {
            // change all credits maximum to max
            for (int i = 0; i < c.Length; i++)
            {
                c[i].Maximum = max;
            }
        }

    }
}
