using System;
using System.Collections;
using System.Collections.Generic;

namespace SdlSharpened.App
{
    public class RenderPipeline : IEnumerable
    {
        private List<IRenderable> _renderList;

        public RenderPipeline()
        {
            _renderList = new List<IRenderable>();
        }

        public void Push(IRenderable renderItem)
        {
            _renderList.Add(renderItem);
        }

        public IEnumerator GetEnumerator() 
        {
            foreach (IRenderable item in _renderList)
            {
                yield return item;
            }
        }
    }
}
