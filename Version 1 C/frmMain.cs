using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    sealed public partial class frmMain : Form
    {
        /// <summary>
        /// Matthias Otto, NMIT, 2010-2016
        /// </summary>
        /// 
        private static readonly frmMain _Instance =
            new frmMain();

        public frmMain()
        {
            InitializeComponent();
        }

        private clsArtistList _ArtistList = new clsArtistList();

        public static frmMain Instance => _Instance;

        public void UpdateDisplay()
        {
            string[] lcDisplayList = new string[_ArtistList.Count];

            lstArtists.DataSource = null;
            _ArtistList.Keys.CopyTo(lcDisplayList, 0);
            lstArtists.DataSource = lcDisplayList;
            lblValue.Text = Convert.ToString(_ArtistList.GetTotalValue());
        }

        public void UpdateDisplay(clsArtistList prArtistList)
        {
            string[] lcDisplayList = new string[prArtistList.Count];

            lstArtists.DataSource = null;
            prArtistList.Keys.CopyTo(lcDisplayList, 0);
            lstArtists.DataSource = lcDisplayList;
            lblValue.Text = Convert.ToString(prArtistList.GetTotalValue());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmArtist.Run(new clsArtist(_ArtistList));
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
                frmArtist.Run(_ArtistList[lcKey]);
            }
            catch(Exception ex)
            {                
                MessageBox.Show(ex.Message, "Edit Error");
            } 
               
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            try
            {
                _ArtistList.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "File Save Error");
            }
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                lstArtists.ClearSelected();
                _ArtistList.Remove(lcKey);
                UpdateDisplay();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //_Retrieve();
            try
            {
                _ArtistList = clsArtistList.Retrieve();
                UpdateDisplay();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "File Retrieve Error");
            }
        }
    }
}