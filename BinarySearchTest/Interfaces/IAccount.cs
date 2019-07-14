using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTest.Interfaces
{
    public interface IBank<out T>
    {
        T Create(int sum);
    }

    public class Account
    {
        public virtual void Do()
        {
            Console.WriteLine("DO Account");
        }
    }

    public class DerivedAccount : Account
    {
        public override void Do()
        {
            Console.WriteLine("DO DerivedAccount");
        }
    }

    public class Bank<T> : IBank<T> where T : Account, new()
    {
        public T Create(int sum)
        {
            T acc = new T();
            acc.Do();
            return acc;
        }
    }
}
