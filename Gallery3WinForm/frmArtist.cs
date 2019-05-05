using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gallery3WinForm
{
    public partial class frmArtist : Form
    {      
        private clsArtist _Artist;
  //      private clsWorksList _WorksList;
        private char _WorkType;

        private static Dictionary<string, frmArtist> _ArtistFormList =
            new Dictionary<string, frmArtist>();

        public frmArtist()
        {
            InitializeComponent();
        }

        public static void Run(string prArtistName)
        {
            frmArtist lcArtistForm;
            if ((string.IsNullOrEmpty(prArtistName) ||!_ArtistFormList.TryGetValue(prArtistName, out lcArtistForm)))
            {
                lcArtistForm = new frmArtist();
                if (string.IsNullOrEmpty(prArtistName))
                    lcArtistForm.SetDetails(new clsArtist());
                else
                {
                    _ArtistFormList.Add(prArtistName, lcArtistForm);
                    lcArtistForm.refreshFormFromDB(prArtistName);
                }
            }
            else
            {
                lcArtistForm.Show();
                lcArtistForm.Activate();
            }
        }

        private async void refreshFormFromDB(string  prArtistName)
        {
            SetDetails(await ServiceClient.GetArtistAsync(prArtistName));
        }

        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Artist Details - " + prGalleryName;
        }

        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtPhone.Text = _Artist.Phone;
            txtSpeciality.Text = _Artist.Speciality;
 /*           lblTotal.Text = Convert.ToString(_Artist.TotalValue);
            _WorksList = _Artist.WorksList;*/
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
            lstWorks.DataSource = null;
            if (_Artist.WorksList != null)
                lstWorks.DataSource = _Artist.WorksList;

            /*                    if (_WorksList.SortOrder == 0)
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
                                lstWorks.DataSource = _Artist.WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());

                     changeWorkType(txtSpeciality.Text);*/
        }

        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            updateForm();
            updateDisplay();
            Show();
            frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
     //       updateTitle(_Artist.ArtistList.GalleryName);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show(await ServiceClient.DeleteArtworkAsync(lstWorks.SelectedItem as clsAllWork));
                refreshFormFromDB(_Artist.Name);
                frmMain.Instance.UpdateDisplay();
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string lcReply = new InputBox(clsAllWork.FACTORY_PROMPT).Answer;
                if (!string.IsNullOrEmpty(lcReply)) // not cancelled?
                {
                    clsAllWork lcWork = clsAllWork.NewWork(lcReply[0]);
                    if (lcWork != null) // valid artwork created?
                    {
                        if (txtName.Enabled)       // new artist not saved?
                        {
                            pushData();
                            await ServiceClient.InsertArtistAsync(_Artist);
                            txtName.Enabled = false;
                        }
                        lcWork.ArtistName = _Artist.Name;
                        frmWork.DispatchWorkForm(lcWork);
                        if (!string.IsNullOrEmpty(lcWork.Name)) // not cancelled?
                        {
                            refreshFormFromDB(_Artist.Name);
                            frmMain.Instance.UpdateDisplay();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
            { 
                try
                {
                    pushData();
                    if (txtName.Enabled)
                    {
                        MessageBox.Show(await ServiceClient.InsertArtistAsync(_Artist));
                        frmMain.Instance.UpdateDisplay();
                        txtName.Enabled = false;
                    }
                    else
                        MessageBox.Show(await ServiceClient.UpdateArtistAsync(_Artist));
                    Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
 /*               if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else*/
                    return true;
            else
                return true;
        }

        private void changeWorkType(string prDescription)
        {
            switch (prDescription.ToLower())
            {
                case "painting":
                    _WorkType = 'p';
                    break;
                case "photograph":
                    _WorkType = 'h';
                    break;
                case "sculpture":
                    _WorkType = 's';
                    break;
                default:
                    _WorkType = 'p';
                    break;
            }
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            try
            {
                //_WorksList.EditWork(lcIndex);
                frmWork.DispatchWorkForm(lstWorks.SelectedValue as clsAllWork);
                updateDisplay();
            }
            catch (Exception)
            { 
                MessageBox.Show("Sorry no work selected #" + Convert.ToString(lcIndex));
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
 //           _WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            updateDisplay();
        }
    }
}