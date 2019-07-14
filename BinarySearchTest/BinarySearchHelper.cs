using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTest
{
    public class BinarySearchHelper
    {
        public int IterationCounter
        {
            get;
            private set;
        }
        public BinarySearchHelper()
        {
            IterationCounter = 0;
        }

        public int Search(int[] sortedArray, int searchValue, int firstIndex, int lastIndex)
        {
            IterationCounter++;
            if (firstIndex > lastIndex)
            {
                return -1;
            }

            var middle = (firstIndex + lastIndex)/2;
            var middleValue = sortedArray[middle];

            if (middleValue == searchValue)
            {
                return middle;
            }

            if (searchValue > middleValue)
            {
                return Search(sortedArray, searchValue, middle + 1, lastIndex);
            }
            else
            {
                return Search(sortedArray, searchValue, firstIndex, middle - 1);
            }
        }
    }
}
