using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmInputBox : Form
    {
        private string _Answer;

        public frmInputBox(string prQuestion)
        {
            InitializeComponent();
            lblQuestion.Text = prQuestion;
            lblError.Text = "";
            txtAnswer.Focus();
        }

        private void btnOK_Click(object prSender, EventArgs prE)
        {
            if (txtAnswer.Text.Length > 0 && txtAnswer.Text.Length < 2)
            {
                _Answer = txtAnswer.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = "Please enter one character into the text box.";
            }
        }

        private void btnCancel_Click(object prSender, EventArgs prE)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string GetAnswer()
        {
            return _Answer;
        }
    }
}