using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowStocks
{
    public class NumericUpDownEx : NumericUpDown
    {
        protected override void OnTextBoxTextChanged(object source, EventArgs e)
        {
            decimal textBoxVal;
            if (decimal.TryParse((source as TextBox).Text, out textBoxVal)
                && textBoxVal >= Minimum && textBoxVal <= Maximum)
                Value = textBoxVal;
            base.OnTextBoxTextChanged(source, e);
        }
    }
}
