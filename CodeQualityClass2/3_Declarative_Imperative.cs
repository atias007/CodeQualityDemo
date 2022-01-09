using System.Collections.Generic;
using System.Linq;

namespace CodeQualityClass2
{
    public class DeclarativeImperative
    {
        List<int> collection = new List<int> { 1, 2, 3, 4, 5 };

        #region Bad

        public void Foo1()
        {
            List<int> results = new List<int>();
            foreach (var num in collection)
            {
                if (num % 2 != 0)
                    results.Add(num);
            }
        }

        #endregion

        #region Better

        public void Foo2()
        {
            var results = collection.Where(num => num % 2 != 0);
        }

        #endregion
    }
}
