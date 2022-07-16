using System.Collections.Generic;
using _PROJECT.Code.ProductCatalog.Data;

namespace _PROJECT.Code.ProductCatalog
{
    public class ItemComparer : Comparer<ItemTypes[]>
    {
        public override int Compare(ItemTypes[] x, ItemTypes[] y)
        {
            if (x != null && y != null)
            {
                for (var i = 0; i < x.Length; i++)
                {
                    for (var j = 0; j < y.Length; j++)
                    {
                        var comparisionResult = x[i].CompareTo(y[j]);
                        if (comparisionResult != 0) return comparisionResult;
                    }
                }
            }

            return 0;
        }
    }
}