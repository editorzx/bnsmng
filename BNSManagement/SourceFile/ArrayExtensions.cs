using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BNSManagement.SourceFile
{
    public static class ArrayExtensions
    {
        public static T[] MergeArrays<T>(this T[] sourceArray, params T[][] additionalArrays)
        {
            List<T> elements = sourceArray.ToList();

            if (additionalArrays != null)
            {
                foreach (var array in additionalArrays)
                    elements.AddRange(array.ToList());
            }

            return elements.ToArray();
        }
    }
}
