using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery4Universal
{
    static class clsUtil
    {
        public static string EmptyIfNull(this string prString)
        {
            return prString == null ? string.Empty : prString;
        }
    }
}
