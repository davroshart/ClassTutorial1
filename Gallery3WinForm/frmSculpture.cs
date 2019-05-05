using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gallery3WinForm
{
    sealed public partial class frmSculpture : Gallery3WinForm.frmWork
    {
        public static readonly frmSculpture Instance =
            new frmSculpture();

        public frmSculpture()
        {
            InitializeComponent();
        }

        public static void Run(clsAllWork prSculpture)
        {
            Instance.SetDetails(prSculpture);
        }

        protected override void updateForm()
        {
            base.updateForm();
            //clsSculpture lcWork = (clsSculpture)_Work;
            txtWeight.Text = _Work.Weight.ToString();
            txtMaterial.Text = _Work.Material;
        }

        protected override void pushData()
        {
            base.pushData();
            //clsSculpture lcWork = (clsSculpture)_Work;
            _Work.Weight = Single.Parse(txtWeight.Text);
            _Work.Material = txtMaterial.Text;
        }

    }
}

