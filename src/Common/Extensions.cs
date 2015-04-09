// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/9/2013 9:47:46 AM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Extensions
    {
        public static Exception MostInnerException(this Exception exception)
        {
            var ex = exception;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
    }
}
