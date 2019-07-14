using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTest
{
    public class BinarySearchGenericHelper<T> where T : IComparable<T>
    {
        public int IterationCounter
        {
            get;
            private set;
        }
        public BinarySearchGenericHelper()
        {
            IterationCounter = 0;
        }

        public int Search(T[] sortedArray, T searchValue, int firstIndex, int lastIndex)
        {
            IterationCounter++;
            if (firstIndex > lastIndex)
            {
                return -1;
            }

            var middle = (firstIndex + lastIndex)/2;
            var middleValue = sortedArray[middle];

            if (middleValue.CompareTo(searchValue) == 0)
            {
                return middle;
            }

            if (middleValue.CompareTo(searchValue) > 0)
            {
                return Search(sortedArray, searchValue, firstIndex, middle - 1);
            }
            else
            {
                return Search(sortedArray, searchValue, middle + 1, lastIndex);
            }
        }
    }
}
