using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeAugmentor
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        public string InputText
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        public static string Show(string title, string promptText)
        {
            InputBox form = new InputBox();
            form.Text = title;
            form.lblPrompt.Text = promptText;
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
                return form.InputText;
            else
                return null;
        }
    }

}
