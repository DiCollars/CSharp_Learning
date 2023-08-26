using System.Collections;

namespace IEnumeratorTest
{
    public class Colors
    {
        public ColorEnumerator GetEnumerator()
        {
            return new ColorEnumerator();
        }
    }

    public class ColorEnumerator
    {
        public List<string> ColorCollextion { get; set; } = new List<string> { "Red", "Green", "Yellow" };

        private int index = -1;

        public string Current => ColorCollextion[index];

        public bool MoveNext()
        {
            index++;

            if (ColorCollextion.Count - 1 < index)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
