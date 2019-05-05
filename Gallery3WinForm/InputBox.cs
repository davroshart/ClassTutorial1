using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gallery3WinForm
{
    public partial class InputBox : Form
    {
        private string _Answer;

        public InputBox(string prQuestion)
        {
            InitializeComponent();
            lblQuestion.Text = prQuestion;
            lblError.Text = "";
            txtAnswer.Focus();
            ShowDialog();
        }

        private void btnOK_Click(object prSender, EventArgs prE)
        {
            _Answer = txtAnswer.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object prSender, EventArgs prE)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string Answer
        {
            get { return _Answer; }
            //set { mAnswer = value; }
        }
    }
}