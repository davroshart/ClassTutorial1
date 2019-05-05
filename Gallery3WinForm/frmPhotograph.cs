using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gallery3WinForm
{
    sealed public partial class frmPhotograph : Gallery3WinForm.frmWork
    {
        public static readonly frmPhotograph Instance =
            new frmPhotograph();

        public frmPhotograph()
        {
            InitializeComponent();
        }

        public static void Run(clsAllWork prPhotograph)
        {
            Instance.SetDetails(prPhotograph);
        }

        protected override void updateForm()
        {
            base.updateForm();
            //clsPhotograph lcWork = (clsPhotograph)_Work;
            txtWidth.Text = _Work.Width.ToString();
            txtHeight.Text = _Work.Height.ToString();
            txtType.Text = _Work.Type;
        }

        protected override void pushData()
        {
            base.pushData();
         //   clsPhotograph lcWork = (clsPhotograph)_Work;
            _Work.Width = Single.Parse(txtWidth.Text);
            _Work.Height = Single.Parse(txtHeight.Text);
            _Work.Type = txtType.Text;
        }

    }
}

