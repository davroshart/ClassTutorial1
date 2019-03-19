using System;
using System.Collections.Generic;

namespace Version_1_C
{
    [Serializable()] 
    public class clsWorksList : List<clsWork>
    {
       // private clsSingletonNameComparer _NameComparer = clsSingletonNameComparer.Instance;
       // private static clsDateComparer _DateComparer = new clsDateComparer();
        
        private byte _SortOrder;

        public byte SortOrder { get => _SortOrder; set => _SortOrder = value; }

        public void AddWork(char prWorkType)
        {
            clsWork lcWork = clsWork.NewWork(prWorkType);
            if (lcWork != null)
            {
                Add(lcWork);
            }
        }
       
        public void DeleteWork(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {                
                this.RemoveAt(prIndex);                
            }
        }
        
        public void EditWork(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                clsWork lcWork = (clsWork)this[prIndex];
                lcWork.EditDetails();
            }
            else
            {
                throw new Exception("No work selected");
            }
        }

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsWork lcWork in this)
            {
                lcTotal += lcWork.Value;
            }
            return lcTotal;
        }

         public void SortByName()
         {
            Sort(clsSingletonNameComparer.Instance);
            
         }
    
        public void SortByDate()
        {
            Sort(clsSingletonDateComprere.Instance);
        }
    }
}
