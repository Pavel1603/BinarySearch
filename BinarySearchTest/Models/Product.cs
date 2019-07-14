using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTest.Models
{
    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public int Age { get; set; }

        public int CompareTo(Product other)
        {
            if (Id > other.Id)
            {
                return 1;
            }

            if (Id < other.Id)
            {
                return -1;
            }

            return 0;
        }

        public override string ToString()
        {
            return string.Format("Id: {0} - Age: {1}", Id, Age);
        }
    }
}
