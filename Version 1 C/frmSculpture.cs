using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    sealed public partial class frmSculpture : Version_1_C.frmWork
    {
        public static readonly frmSculpture Instance =
            new frmSculpture();

        public frmSculpture()
        {
            InitializeComponent();
        }

        public static void Run(clsSculpture prSculpture)
        {
            Instance.SetDetails(prSculpture);
        }

        protected override void updateForm()
        {
            base.updateForm();
            clsSculpture lcWork = (clsSculpture)_Work;
            txtWeight.Text = lcWork.Weight.ToString();
            txtMaterial.Text = lcWork.Material;
        }

        protected override void pushData()
        {
            base.pushData();
            clsSculpture lcWork = (clsSculpture)_Work;
            lcWork.Weight = Single.Parse(txtWeight.Text);
            lcWork.Material = txtMaterial.Text;
        }

    }
}

