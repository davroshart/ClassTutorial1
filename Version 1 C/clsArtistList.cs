using System;
using System.Collections.Generic;
//using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtistList : SortedList<string, clsArtist>
    {
        private const string _FileName = "gallery.xml";

        public string EditArtist(string prKey)
        {
            string lcOutcome = "";
            clsArtist lcArtist;

            lcArtist = this[prKey];
            if (lcArtist != null)
            {
                lcArtist.EditDetails();
                lcOutcome = "done";
            }
            else
            {
                //              MessageBox.Show("Sorry no artist by this name");
                lcOutcome = "nokey";
            }
            return lcOutcome;
        }
       
        public string NewArtist()
        {
            string lcOutcome = "";

            clsArtist lcArtist = new clsArtist(this);
            try
            {
                if (lcArtist.GetKey() != "")
                {
                    Add(lcArtist.GetKey(), lcArtist);
                    lcOutcome = "done";
                }
            }
            catch (Exception)
            {
                lcOutcome = "dupkey";
            }
            return lcOutcome;
        }
        
        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsArtist lcArtist in Values)
            {
                lcTotal += lcArtist.GetWorksValue();
            }
            return lcTotal;
        }

        public string Save()
        {
            string lcOutcome = "";

            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                lcFormatter.Serialize(lcFileStream, this);
                lcFileStream.Close();
                lcOutcome = "done";
            }
            catch (Exception e)
            {
                lcOutcome = e.Message;
                //MessageBox.Show(e.Message, "File Save Error");
            }
            return lcOutcome;
        }

        public static clsArtistList Retrieve()
        {
            clsArtistList lcArtistList = new clsArtistList();

            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                lcArtistList = (clsArtistList)lcFormatter.Deserialize(lcFileStream);
                lcFileStream.Close();
            }

            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "File Retrieve Error");
                //lcArtistList = null;
                System.ArgumentException lcEx = new System.ArgumentException("File load error", e);
                throw lcEx;
            }
            return lcArtistList;
        }

    }
}
