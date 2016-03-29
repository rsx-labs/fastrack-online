using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASTWeb.Common
{
    public static class ExtensionMethods
    {
        public static int ToInteger(this String str)
        {
            int val = 0;
            if (Int32.TryParse(str, out val))
            {
                return val;
            }

            return val;
        }
    }
}