using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    sealed public partial class frmPhotograph : Version_1_C.frmWork
    {
        public static readonly frmPhotograph Instance =
            new frmPhotograph();

        public frmPhotograph()
        {
            InitializeComponent();
        }

        public static void Run(clsPhotograph prPhotograph)
        {
            Instance.SetDetails(prPhotograph);
        }

        protected override void updateForm()
        {
            base.updateForm();
            clsPhotograph lcWork = (clsPhotograph)_Work;
            txtWidth.Text = lcWork.Width.ToString();
            txtHeight.Text = lcWork.Height.ToString();
            txtType.Text = lcWork.Type;
        }

        protected override void pushData()
        {
            base.pushData();
            clsPhotograph lcWork = (clsPhotograph)_Work;
            lcWork.Width = Single.Parse(txtWidth.Text);
            lcWork.Height = Single.Parse(txtHeight.Text);
            lcWork.Type = txtType.Text;
        }

    }
}

