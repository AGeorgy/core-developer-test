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
            private readonly uint[] _yCounts;
            private readonly uint[] _xCounts;

            public ItemComparer(ItemTypes[] valuesToCompare)
            {
                _valuesToCompare = valuesToCompare;
                _count = _valuesToCompare.Length;
                _yCounts = new uint[_count];
                _xCounts = new uint[_count];
            }

            public override int Compare(ItemTypes[] x, ItemTypes[] y)
            {
                if (ReferenceEquals(x, y))
                    return 0;
                if (x == null)
                    return -1;
                if (y == null)
                    return 1;

                Array.Clear(_yCounts, 0, _count);
                Array.Clear(_xCounts, 0, _count);
                
                for (var iCounts = 0; iCounts < _count; iCounts++)
                {
                    var valueToCompare = _valuesToCompare[iCounts];
                    for (var i = 0; i < x.Length; i++)
                    {
                        if (0 == valueToCompare.CompareTo(x[i])) _xCounts[iCounts]++;
                    }

                    for (var i = 0; i < y.Length; i++)
                    {
                        if (0 == valueToCompare.CompareTo(y[i])) _yCounts[iCounts]++;
                    }
                }

                for (var i = 0; i < _count; i++)
                {
                    if (_xCounts[i] > _yCounts[i]) return 1;
                    if (_xCounts[i] < _yCounts[i]) return -1;
                }

                return 0;
            }
        }

        public class ItemOrComparer : Comparer<ItemTypes[]>
        {
            private readonly ItemTypes[] _valuesToCompare;
            private readonly int _count;
            private bool _isAnyX;
            private bool _isAnyY;

            public ItemOrComparer(ItemTypes[] valuesToCompare)
            {
                _valuesToCompare = valuesToCompare;
                _count = _valuesToCompare.Length;
            }
            
            public override int Compare(ItemTypes[] x, ItemTypes[] y)
            {
                _isAnyX = _isAnyY = false;
                
                for (var iCounts = 0; iCounts < _count; iCounts++)
                {
                    var valueToCompare = _valuesToCompare[iCounts];
                    for (var i = 0; i < x.Length; i++)
                    {
                        if (0 == valueToCompare.CompareTo(x[i])) _isAnyX = true;
                    }

                    for (var i = 0; i < y.Length; i++)
                    {
                        if (0 == valueToCompare.CompareTo(y[i])) _isAnyY = true;
                    }
                }

                if (!_isAnyX && _isAnyY) return -1;
                if (_isAnyX && !_isAnyY) return 1;

                return 0;
            }
        }

        public class ItemAndComparer : Comparer<ItemTypes[]>
        {
            private readonly ItemTypes[] _valuesToCompare;
            private readonly int _count;
            private readonly HashSet<int> _xCount;
            private readonly HashSet<int> _yCount;

            public ItemAndComparer(ItemTypes[] valuesToCompare)
            {
                _valuesToCompare = valuesToCompare;
                _count = _valuesToCompare.Length;
                _xCount = new HashSet<int>();
                _yCount = new HashSet<int>();
            }
            public override int Compare(ItemTypes[] x, ItemTypes[] y)
            {
                _xCount.Clear();
                _yCount.Clear();

                for (var iCounts = 0; iCounts < _count; iCounts++)
                {
                    var valueToCompare = _valuesToCompare[iCounts];
                    for (var i = 0; i < x.Length; i++)
                    {
                        if (0 == valueToCompare.CompareTo(x[i])) _xCount.Add(iCounts);
                    }

                    for (var i = 0; i < y.Length; i++)
                    {
                        if (0 == valueToCompare.CompareTo(y[i])) _yCount.Add(iCounts);
                    }
                }

                if (_xCount.Count > _yCount.Count) return 1;
                if (_yCount.Count > _xCount.Count) return -1;

                return 0;
            }
        }
    }
}