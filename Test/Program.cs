namespace Test
{
    public struct Test : IDisposable
    {
        public Guid guid;
        private bool val;

        public void Dispose()
        {
            val = true;
        }

        public void Show()
        {
            Console.WriteLine(val);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var test = new Test() { guid = Guid.NewGuid()};

            var too = test.GetHashCode();

            using (test)
            {
                var t1oo = test.GetHashCode();
                test.Show();
            }

            var to2o = test.GetHashCode();
            test.Show();
        }
    }
}