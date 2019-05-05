using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gallery3WinForm
{
    public partial class frmWork : Form
    {
        protected clsAllWork _Work;

        public delegate void LoadWorkFormDelegate(clsAllWork prWork);
        public static Dictionary<char, Delegate> _WorksForm = new Dictionary<char, Delegate>
        {
            {'P', new LoadWorkFormDelegate(frmPainting.Run)},
            {'H', new LoadWorkFormDelegate(frmPhotograph.Run)},
            {'S', new LoadWorkFormDelegate(frmSculpture.Run)}
        };
        public static void DispatchWorkForm(clsAllWork prWork)
        {
            _WorksForm[prWork.WorkType].DynamicInvoke(prWork);
        }


        public frmWork()
        {
            InitializeComponent();
        }

        protected virtual void updateForm()
        {
            txtName.Enabled = string.IsNullOrEmpty(_Work.Name);
            txtName.Text = _Work.Name;
            txtCreation.Text = _Work.Date.ToShortDateString();
            txtValue.Text = _Work.Value.ToString();
        }

        protected virtual void pushData()
        {
            _Work.Name = txtName.Text;
            _Work.Date = DateTime.Parse(txtCreation.Text);
            _Work.Value = decimal.Parse(txtValue.Text);
        }

        public void SetDetails(clsAllWork prWork)
        {
            _Work = prWork;
            updateForm();
            ShowDialog();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (IsValid() == true)
            {
                pushData();
                if (txtName.Enabled)
                    MessageBox.Show(await ServiceClient.InsertWorkAsync(_Work));
                else
                    MessageBox.Show(await ServiceClient.UpdateWorkAsync(_Work));
                Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        public virtual bool IsValid()
        {
            return true;
        }

    }
}