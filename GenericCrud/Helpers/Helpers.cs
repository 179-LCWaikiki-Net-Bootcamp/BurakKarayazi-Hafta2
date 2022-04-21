using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GenericCrud.Helpers
{
    public static class Helper
    {

        public static long TurnPositive(long value)
        {
            if (value<0)
            {
                return value*(-1);
            }
            return value;
        }

    }
}
