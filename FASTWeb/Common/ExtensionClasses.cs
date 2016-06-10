using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASTWeb.Common
{
    public static class ExtensionClasses
    {
        public static int ToInteger(this String str)
        {
            int val = 0;

            if ( Int32.TryParse(str,out val))
            {
                return val;
            }


            //Lets return negative 1 to signify error
            return -1;
        }

    }
}