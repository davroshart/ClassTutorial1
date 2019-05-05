using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gallery3WinForm
{
    sealed public partial class frmMain : Form
    {
        /// <summary>
        /// Matthias Otto, NMIT, 2010-2016
        /// </summary>
        /// 
        private static readonly frmMain _Instance =
            new frmMain();

        private frmMain()
        {
            InitializeComponent();
        }

    //    private clsArtistList _ArtistList = new clsArtistList();

        public static frmMain Instance => _Instance;

        // old form:
        //public static frmMain Instance
        //{
        //    get
        //    {
        //        return _Instance;
        //    }

        //}
        public delegate void Notify(string prGalleryName);
        public event Notify GalleryNameChanged;

        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Gallery - " + prGalleryName;
        }

        async public void UpdateDisplay()
        {
            /*           string[] lcDisplayList = new string[_ArtistList.Count];

                       lstArtists.DataSource = null;
                       _ArtistList.Keys.CopyTo(lcDisplayList, 0);
                       lstArtists.DataSource = lcDisplayList;
                       lblValue.Text = Convert.ToString(_ArtistList.GetTotalValue());*/
            try
            {
                lstArtists.DataSource = null;
                lstArtists.DataSource = await ServiceClient.GetArtistNamesAsync();
            }
            catch
            {
                lstArtists.Text = "Error";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmArtist.Run("");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Error");
            }
            UpdateDisplay();
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey = Convert.ToString(lstArtists.SelectedItem);

            try
            {
                /*_ArtistList.EditArtist(lcKey);
                updateDisplay();*/
                frmArtist.Run(lstArtists.SelectedItem as string);
            }
            catch(Exception ex)
            {                
                MessageBox.Show(ex.Message, "Edit Error");
            }
               
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
/*            try
            {
                _ArtistList.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "File Save Error");
            }*/
            Close();
        }

        private async void btnDelete_ClickAsync(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null && MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lstArtists.ClearSelected();
                MessageBox.Show(await ServiceClient.DeleteArtist(lcKey));
                frmMain.Instance.UpdateDisplay();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //_Retrieve();
 /*           try
            {
                _ArtistList = clsArtistList.Retrieve();*/
                UpdateDisplay();
 /*           }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "File Retrieve Error");
            }

            GalleryNameChanged += new Notify(updateTitle);
            GalleryNameChanged(_ArtistList.GalleryName);*/
        }

        private void btnGalleryName_Click(object sender, EventArgs e)
        {
 /*           frmInputBox lcInputBox = new frmInputBox("Gallery Name = "+ _ArtistList.GalleryName +". Enter new gallery name");
            
            if (lcInputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _ArtistList.GalleryName = lcInputBox.GetAnswer();
                GalleryNameChanged(_ArtistList.GalleryName);
            }
            else
            {
                lcInputBox.Close();
            }*/
        }
    }
}