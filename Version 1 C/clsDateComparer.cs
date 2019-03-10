using System;
using System.Collections.Generic;

namespace Version_1_C
{
    sealed class clsSingletonDateComprere : IComparer<clsWork>
    {
        public static readonly clsSingletonDateComprere Instance =
            new clsSingletonDateComprere();
        private clsSingletonDateComprere() { }

        public int Compare(clsWork prX, clsWork prY)
        {
            return prX.Date.CompareTo(prY.Date);
        }
    }
}
