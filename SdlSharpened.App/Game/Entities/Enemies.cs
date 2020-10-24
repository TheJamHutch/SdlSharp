using System;
using System.Collections;
using System.Collections.Generic;

namespace SdlSharpened.App
{
    class Enemies : IEnumerable
    {
        private List<Enemy> _enemiesList;

        public Enemies()
        {
            _enemiesList = new List<Enemy>();
        }

        public IEnumerator GetEnumerator()
        {
            foreach (IRenderable item in _enemiesList)
            {
                yield return item;
            }
        }
    }
}
