using System;
using System.Collections.Generic;
using _PROJECT.Code.ProductCatalog.Data;

namespace _PROJECT.Code.ProductCatalog
{
    public static partial class ProductCatalogComparers
    {
        public class ItemComparer : Comparer<ItemTypes[]>
        {
            private readonly ItemTypes[] _valuesToCompare;
            private readonly int _count;

            public ItemComparer(ItemTypes[] valuesToCompare)
            {
                _valuesToCompare = valuesToCompare;
                _count = _valuesToCompare.Length;
            }
            
            public override int Compare(ItemTypes[] x, ItemTypes[] y)
            {
                if (ReferenceEquals(x, y))
                    return 0;
                if (x == null)
                    return -1;
                if (y == null)
                    return 1;
                
                var yCounts = new uint[_count];
                var xCounts = new uint[_count];

                for (var iCounts = 0; iCounts < _count; iCounts++)
                {
                    var valueToCompare = _valuesToCompare[iCounts];
                    for (var i = 0; i < x.Length; i++)
                    {
                        if (0 == valueToCompare.CompareTo(x[i])) xCounts[iCounts]++;
                    }

                    for (var i = 0; i < y.Length; i++)
                    {
                        if (0 == valueToCompare.CompareTo(y[i])) yCounts[iCounts]++;
                    }
                }

                for (var i = 0; i < _count; i++)
                {
                    if (xCounts[i] > yCounts[i]) return 1;
                    if (xCounts[i] < yCounts[i]) return -1;
                }

                return 0;
            }
        }

    public class ItemOrComparer : Comparer<ItemTypes[]>
        {
            public override int Compare(ItemTypes[] x, ItemTypes[] y)
            {
                var comparisionCount = 0;
                if (x != null && y != null)
                {
                    for (var i = 0; i < x.Length; i++)
                    {
                        for (var j = 0; j < y.Length; j++)
                        {
                            if (0 == x[i].CompareTo(y[j])) comparisionCount++;
                        }
                    }
                    
                    if (comparisionCount == 1) return 0;
                    if (comparisionCount > 1) return 1;
                }

                return -1;
            }
        }

        public class ItemAndComparer : Comparer<ItemTypes[]>
        {
            public override int Compare(ItemTypes[] x, ItemTypes[] y)
            {
                var comparisionCount = 0;
                if (x != null && y != null)
                {
                    for (var i = 0; i < x.Length; i++)
                    {
                        for (var j = 0; j < y.Length; j++)
                        {
                            if (0 == x[i].CompareTo(y[j])) comparisionCount++;
                        }
                    }
                    
                    if (comparisionCount == x.Length && comparisionCount == y.Length) return 0;
                    if (comparisionCount == Math.Min(x.Length, y.Length) && comparisionCount < Math.Max(x.Length, y.Length)) return 1;
                }

                return -1;
            }
        }
    }
}