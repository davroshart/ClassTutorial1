using System;

namespace Version_1_C
{
    [Serializable()] 
    public abstract class clsWork
    {
        private string workType;
        private string name;
        private DateTime date = DateTime.Now;
        private decimal value;

        public string WorkType { get => workType; set => workType = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal Value { get => value; set => this.value = value; }

        public clsWork()
        {
            EditDetails();
        }

        public abstract void EditDetails();

         public static clsWork NewWork(char prWorkType)//string prType)
         {
 
            switch (char.ToUpper(prWorkType))
            { 
                case 'P': return new clsPainting();
                case 'S': return new clsSculpture();
                case 'H': return new clsPhotograph();
                default: return null;
            }
        }

        public override string ToString()
        {
            return Name + "\t" + Date.ToShortDateString();  
        }
 
    }
}
