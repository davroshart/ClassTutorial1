using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gallery3WinForm
{
  /*  public partial class frmPainting : Version_1_C.frmWork
    {

        public frmPainting()
        {
            InitializeComponent();
        }

        protected override void updateForm()
        {
            base.updateForm();
            clsPainting lcWork = (clsPainting)_Work;
            txtWidth.Text = lcWork.Width.ToString();
            txtHeight.Text = lcWork.Height.ToString();
            txtType.Text = lcWork.Type;
        }

        protected override void pushData()
        {
            base.pushData();
            clsPainting lcWork = (clsPainting)_Work;
            lcWork.Width = Single.Parse(txtWidth.Text);
            lcWork.Height = Single.Parse(txtHeight.Text);
            lcWork.Type = txtType.Text;
        }

    }*/
    sealed public partial class frmPainting : Gallery3WinForm.frmWork
    {
        public static readonly frmPainting Instance =
            new frmPainting();

        private frmPainting()
        {
            InitializeComponent();
        }

        public static void Run(clsAllWork prPainting)
        {
            Instance.SetDetails(prPainting);
        }

        protected override void updateForm()
        {
            base.updateForm();
 //           clsPainting lcWork = (clsPainting)_Work;
            txtWidth.Text = _Work.Width.ToString();
            txtHeight.Text = _Work.Height.ToString();
            txtType.Text = _Work.Type;
        }

        protected override void pushData()
        {
            base.pushData();
        //    clsAllWork lcWork = (clsPainting)_Work;
            _Work.Width = Single.Parse(txtWidth.Text);
            _Work.Height = Single.Parse(txtHeight.Text);
            _Work.Type = txtType.Text;
        }
    }
}

