using System.Collections;

namespace _05_foreach_without_ienumerable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in new MyCollection())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            foreach (var item in new MyCollection2())
            {
                Console.WriteLine(item);
            }
        }
    }

    public class MyCollection
    {
        private int[] MyArray { get; set; } = [1, 2, 3, 4, 5];

        public IEnumerator GetEnumerator()
        {
            return MyArray.GetEnumerator();
        }
    }

    public class MyCollection2
    {
        public MyEnumerator GetEnumerator()
        {
            return new MyEnumerator();
        }
    }

    public class MyEnumerator
    {
        private int[] MyInsideCollection { get; set; } = [1, 2, 3, 5, 7, 8, 1, 2, 4];

        private int position = -1;

        public object Current
        {
            get
            {
                return MyInsideCollection[position];
            }
            set
            {
                value = MyInsideCollection[position];
            }
        }

        public bool MoveNext()
        {
            if (position == MyInsideCollection.Length - 1) return false;

            position++;

            return true;
        }
    }
}
