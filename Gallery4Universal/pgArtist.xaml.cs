using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Gallery4Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgArtist : Page
    {
        private clsArtist _Artist;

        public pgArtist()
        {
            this.InitializeComponent();
        }

        private void updateDisplay()
        {
            txtName.Text = _Artist.Name;
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
            txtName.IsEnabled = txtName.Text == "";
            
            lstWorks.ItemsSource = null;
            if (_Artist.WorksList != null)
                lstWorks.ItemsSource = _Artist.WorksList;
        }

        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                string lcArtistName = e.Parameter.ToString();
                _Artist = await ServiceClient.GetArtistAsync(lcArtistName);
                updateDisplay();
            }
            else // no parameter -> new artist!
                _Artist = new clsArtist();
        }

        private async void saveArtist()
        {
            try
            {
                pushData();
                if (txtName.IsEnabled)
                {
                    txbMessage.Text +=
                        await ServiceClient.InsertArtistAsync(_Artist) + '\n';
                    txtName.IsEnabled = false;
                }
                else
                    txbMessage.Text +=
                        await ServiceClient.UpdateArtistAsync(_Artist) + '\n';
            }
            catch (Exception ex)
            {
                txbMessage.Text = ex.Message;
            }
        }

        private void saveClick(object sender, RoutedEventArgs e)
        {
            saveArtist();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            saveArtist();
            base.OnNavigatingFrom(e);
        }

        private void editWork(clsAllWork prWork)
        {
            if (prWork != null)
                Frame.Navigate(typeof(pgWork), prWork);
        }

        private void btnEditClick(object sender, RoutedEventArgs e)
        {
            editWork(lstWorks.SelectedItem as clsAllWork);
        }

        private void dblTapWork(object sender, DoubleTappedRoutedEventArgs e)
        {
            editWork(lstWorks.SelectedItem as clsAllWork);
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            Popup lcArtworkChoicesPopup = new Popup();
            ucArtworkChoices lcArtworkChoices = new ucArtworkChoices();
            lcArtworkChoicesPopup.Child = lcArtworkChoices;
            lcArtworkChoicesPopup.HorizontalOffset = 130;
            lcArtworkChoicesPopup.VerticalOffset = 300;
            lcArtworkChoicesPopup.IsOpen = true;
            lcArtworkChoicesPopup.Closed += (s, e1) =>
            {
                clsAllWork lcWork = clsAllWork.NewWork((char)lcArtworkChoices.Tag);
                lcWork.ArtistName = _Artist.Name;
                editWork(lcWork);
            };
        }

        private async void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            if (lstWorks.SelectedIndex >= 0)
            {
                MessageDialog lcMessageBox = new MessageDialog("Are you sure?");
                lcMessageBox.Commands.Add(new UICommand("Yes", async x =>
                {
                    txbMessage.Text += await ServiceClient.DeleteArtworkAsync(
                    lstWorks.SelectedItem as clsAllWork) + '\n';
                }));
                lcMessageBox.Commands.Add(new UICommand("No"));
                await lcMessageBox.ShowAsync();
                _Artist = await ServiceClient.GetArtistAsync(_Artist.Name);
                updateDisplay();
            }

        }
    }
}
