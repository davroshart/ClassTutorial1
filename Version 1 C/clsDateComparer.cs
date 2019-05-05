using System;
using System.Collections.Generic;

namespace Version_1_C
{
    sealed class clsSingletonDateComparer : IComparer<clsWork>
    {
        public static readonly clsSingletonDateComparer Instance =
            new clsSingletonDateComparer();
        private clsSingletonDateComparer() { }

        public int Compare(clsWork prX, clsWork prY)
        {
            return prX.Date.CompareTo(prY.Date);
        }
    }
}
