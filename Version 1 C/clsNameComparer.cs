using System.Collections.Generic;

namespace Version_1_C
{
    /*class clsNameComparer : IComparer<clsWork>
    {
        public int Compare(clsWork x, clsWork y)
        {
            string lcNameX = x.Name;
            string lcNameY = y.Name;

            return lcNameX.CompareTo(lcNameY);
        }
    }*/
    sealed class clsSingletonNameComparer : IComparer<clsWork>
    {
        public static readonly clsSingletonNameComparer Instance =
            new clsSingletonNameComparer();
        private clsSingletonNameComparer() {}

        public int Compare(clsWork prX, clsWork prY)
        {
            return prX.Name.CompareTo(prY.Name);
        }
    }
}
