using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowStocks
{
    internal class FrmBase : Form
    {
        protected void Program_ConfigChanged(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
                c.Font = Program.Config.GenericFont;
        }
    }
}
