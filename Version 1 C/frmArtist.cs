using System;
//using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {      
        private clsArtist _Artist;
        private clsWorksList _WorksList;
        private char _WorkType;

        public frmArtist()
        {
            InitializeComponent();
        }

        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtPhone.Text = _Artist.Phone;
            txtSpeciality.Text = _Artist.Speciality;
            lblTotal.Text = Convert.ToString(_Artist.TotalValue);
            _WorksList = _Artist.WorksList;
        }

        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Phone = txtPhone.Text;
            _Artist.Speciality = txtSpeciality.Text;
        }

        private void updateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (_WorksList.SortOrder == 0)
            {
                _WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _WorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());

            switch (txtSpeciality.Text.ToLower())
            {
                case "painting":
                    _WorkType = 'p';
                    lboWorkType.SelectedIndex = 0;
                    break;
                case "photography":
                    _WorkType = 'h';
                    lboWorkType.SelectedIndex = 1;
                    break;
                case "sculpture":
                    _WorkType = 's';
                    lboWorkType.SelectedIndex = 2;
                    break;
                default:
                    _WorkType = 'p';
                    lboWorkType.SelectedIndex = 0;
                    break;
            }
        }

        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            updateForm();
            updateDisplay();
            ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _WorksList.DeleteWork(lstWorks.SelectedIndex);
                updateDisplay();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string lcOutcome;

            switch (lboWorkType.Text)
            {
                case "painting":
                    _WorkType = 'p';
                    break;
                case "photography":
                    _WorkType = 'h';
                    break;
                case "sculpture":
                    _WorkType = 's';
                    break;
            }
            _WorksList.AddWork(_WorkType);
            updateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
                if (_WorksList.EditWork(lcIndex) == "done")
                    updateDisplay();
                else
                    MessageBox.Show("Sorry no work selected #" + Convert.ToString(lcIndex));
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            updateDisplay();
        }

    }
}