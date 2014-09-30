using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HodorTutor.Infrastructure.Helpers
{
    public static class OperatorHelper
    {
        public static bool Equal(object x, object y)
        {
            if (x != null)
                return x.Equals(y);

            if (y != null)
                return y.Equals(x);

            return true;
        }

        public static bool Unequal(object x, object y)
        {
            return !Equal(x, y);
        }

        public static bool Greater(IComparable x, IComparable y)
        {
            if (x != null)
                return (x.CompareTo(y) > 0);

            if (y != null)
                return (y.CompareTo(x) < 0);

            return false;
        }

        public static bool GreaterOrEqual(IComparable x, IComparable y)
        {
            if (x != null)
                return (x.CompareTo(y) >= 0);

            if (y != null)
                return (y.CompareTo(x) <= 0);

            return true;
        }

        public static bool Less(IComparable x, IComparable y)
        {
            if (x != null)
                return (x.CompareTo(y) < 0);

            if (y != null)
                return (y.CompareTo(x) > 0);

            return false;
        }

        public static bool LessOrEqual(IComparable x, IComparable y)
        {
            if (x != null)
                return (x.CompareTo(y) <= 0);

            if (y != null)
                return (y.CompareTo(x) >= 0);

            return true;
        }

        public static int Compare(IComparable x, IComparable y)
        {
            if (x != null)
                return x.CompareTo(y);

            if (y != null)
                return y.CompareTo(x) * -1;

            return 0;
        }
    }
}
