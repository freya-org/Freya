using System;
using System.Linq;
using System.Collections.Generic;

namespace Freya.Utils
{
    public class ListExt
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
