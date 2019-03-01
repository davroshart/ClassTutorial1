using System;

namespace Version_1_C
{
    [Serializable()] 
    public abstract class clsWork
    {
        protected string _WorkType;
        protected string _Name;
        protected DateTime _Date = DateTime.Now;
        protected decimal _Value;

        public clsWork()
        {
            EditDetails();
        }

        public abstract void EditDetails();

         public static clsWork NewWork()//string prType)
         {
 
             char lcReply;
             frmInputBox lcInputBox = new frmInputBox("Enter P for Painting, S for Sculpture and H for Photograph");
 
             //if (inputBox.getAction() == true)
             if (lcInputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                 lcReply = Convert.ToChar(lcInputBox.GetAnswer());

                 switch (char.ToUpper(lcReply))
                 {
                     case 'P': return new clsPainting();
                     case 'S': return new clsSculpture();
                     case 'H': return new clsPhotograph();
                     default: return null;
                 }
             }
             else
             {
                 lcInputBox.Close();
                 return null;
             }
        }

        public override string ToString()
        {
            return _Name + "\t" + _Date.ToShortDateString();  
        }
        
        public string GetName()
        {
            return _Name;
        }

        public DateTime GetDate()
        {
            return _Date;
        }

        public decimal GetValue()
        {
            return _Value;
        }
    }
}
