using System;
using System.Collections.Generic;
//using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtistList : SortedList<string, clsArtist>
    {
        private const string _FileName = "gallery.xml";
        private string _GalleryName;
        
        public string GalleryName { get => _GalleryName; set => _GalleryName = value; }

        /*   public string EditArtist(string prKey)
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
           }*/

        /*   public void NewArtist()
           {
               if (!string.IsNullOrEmpty(N))

               clsArtist lcArtist = new clsArtist(this);
               try
               {
                   if (lcArtist.GetKey() != "")
                   {
                       Add(lcArtist.GetKey(), lcArtist);
                   }
               }
               catch (Exception)
               {
                   System.ArgumentException lcEx = new System.ArgumentException("Duplicate key", "New Artist Error");
                   throw lcEx;
               }
           }*/

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsArtist lcArtist in Values)
            {
                lcTotal += lcArtist.GetWorksValue();
            }
            return lcTotal;
        }

        public void Save()
        {
        
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                lcFormatter.Serialize(lcFileStream, this);
                lcFileStream.Close();
            }
            catch (Exception e)
            {
                System.ArgumentException lcEx = new System.ArgumentException("Save Error", e);
                throw lcEx;
            }
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
