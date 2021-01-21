using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lecture_9_Solutions
{
    public class SortedCollection<T> : ICollection<T> where T : IComparable
    {
        IList<T> _data = new List<T>();

        public int Count => _data.Count;

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get { return _data[index]; }
        }

        public IEnumerable<T> GetAll() 
        {
            return this;
        }

        public IEnumerable<T> GetAllReversed ()
        {
            return this.Reverse();
        }

        public void Add(T item)
        {
            int index = 0; 

            for(int i = 0; i < _data.Count; i++)
            {
                if (_data[i].CompareTo(item) > 1)
                {
                    index = i;
                    break;
                }
            }
            _data.Insert(index, item);
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(T item)
        {
            return _data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _data.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return _data.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
