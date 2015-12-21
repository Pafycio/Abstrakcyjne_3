using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_3
{

    class TripleList<T> : IEnumerable<T>
    {
        public List<T> list;

        public TripleList<T> PreviousElement;
        public TripleList<T> MiddleElement;
        public TripleList<T> NextElement;

        public TripleList()
        {
            list = new List<T>();

            PreviousElement = null;
            MiddleElement = null;
            NextElement = null;
        }
            
        
        public T Value
        {
            private set;
            get;
        }

        public int Count()
        {
            return list.Count;
        }

        public void Add(T value)
        {
            if ( list.Count == 0 )
                Value = value;

            if (list.Count == 1)
            {
                MiddleElement = new TripleList<T>();
                MiddleElement.Add(value);
            }
            if (list.Count == 2)
            {
                MiddleElement.MiddleElement = new TripleList<T>();
                NextElement = new TripleList<T>();
                NextElement.Add(value);
                NextElement.PreviousElement = new TripleList<T>();
            }
            if (list.Count > 2)
            {
                if (NextElement == null)
                    NextElement = new TripleList<T>();
                NextElement.Add(value);
            }
            

            list.Add(value);
        }

        public void Add(TripleList<T> tl)
        {
            if (list.Count == 1)
            {
                MiddleElement = tl;
            }
            if (list.Count == 2)
            {
                MiddleElement.MiddleElement = new TripleList<T>();
                NextElement = tl;
                NextElement.PreviousElement = new TripleList<T>();
            }

            for (int i = 0; i < tl.Count(); i++)
            {
                list.Add(tl.list[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
