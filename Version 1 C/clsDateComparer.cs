using System;
using System.Collections.Generic;

namespace Version_1_C
{
    class clsDateComparer : IComparer<clsWork>
    {
        public int Compare(clsWork x, clsWork y)
        {
            DateTime lcDateX = x.Date;
            DateTime lcDateY = y.Date;

            return lcDateX.CompareTo(lcDateY);
        }
    }
}
