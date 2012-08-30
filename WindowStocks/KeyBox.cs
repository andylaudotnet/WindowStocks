using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowStocks
{
    public class KeyBox : TextBox
    {
        private Keys _ShortKeyCode;

        public Keys ShortKeyCode
        {
            get { return _ShortKeyCode; }
            set { _ShortKeyCode = value; }
        }
        private Keys _ShortKeyModifiers;

        public Keys ShortKeyModifiers
        {
            get { return _ShortKeyModifiers; }
            set { _ShortKeyModifiers = value; }
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            Text = string.Empty;
            _ShortKeyModifiers = Keys.None;
            _ShortKeyCode = Keys.None;

            if ((e.Modifiers & Keys.Control) == Keys.Control)
            {
                Text += "Ctrl+";
                _ShortKeyModifiers |= Keys.Control;
            }

            if ((e.Modifiers & Keys.Alt) == Keys.Alt)
            {
                Text += "Alt+";
                _ShortKeyModifiers |= Keys.Alt;
            }

            if ((e.Modifiers & Keys.Shift) == Keys.Shift)
            {
                Text += "Shift+";
                _ShortKeyModifiers |= Keys.Shift;
            }

            if (e.KeyCode != Keys.Menu
                && e.KeyCode != Keys.ShiftKey
                && e.KeyCode != Keys.ControlKey)
            {
                Text += e.KeyCode.ToString();
                _ShortKeyCode = e.KeyCode;
            }

            if (e.KeyCode == Keys.Back)
            {
                Text = "无";
                _ShortKeyModifiers = Keys.None;
                _ShortKeyCode = Keys.None;
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (Text.EndsWith("+"))
            {
                Text = "无";
                _ShortKeyModifiers = Keys.None;
                _ShortKeyCode = Keys.None;
            }
            base.OnKeyUp(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (Text.EndsWith("+"))
            {
                Text = "无";
                _ShortKeyModifiers = Keys.None;
                _ShortKeyCode = Keys.None;
            }
            base.OnLeave(e);
        }
    }
}
