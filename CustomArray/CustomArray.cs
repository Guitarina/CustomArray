using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomArray
{
    public class CustomArray<T> : IEnumerable<T>
    {

        private readonly T[] array;
        private int first;
        private int length;

        /// <summary>
        /// Should return first index of array
        /// </summary>
        public int First
        {
            get => first;
            private set => first = value;
        }

        /// <summary>
        /// Should return last index of array
        /// </summary>
        public int Last
        {
            get => first + length - 1;
        }

        /// <summary>
        /// Should return length of array
        /// <exception cref="ArgumentException">Thrown when value was smaller than 0</exception>
        /// </summary>
        public int Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("value was smaller than 0");
                }
                else
                {
                    length = value;
                }
            }
        }

        /// <summary>
        /// Should return array 
        /// </summary>
        public T[] Array
        {
            get => array;
        }


        /// <summary>
        /// Constructor with first index and length
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="length">Length</param>
        public CustomArray(int first, int length)
        {
            this.first = first;
            Length = length;
            this.array = new T[length];
        }


        /// <summary>
        /// Constructor with first index and collection  
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Collection</param>
        ///  <exception cref="ArgumentNullException">Thrown when list is null</exception>
        public CustomArray(int first, IEnumerable<T> list)
        {
            
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            this.first = first;
            Length = list.Count();
            array = list.ToArray();
        }

        /// <summary>
        /// Constructor with first index and params
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Params</param>
        ///  <exception cref="ArgumentNullException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when list without elements </exception>
        public CustomArray(int first, params T[] list)
        {
            if (list == null)
                throw new ArgumentNullException("list is null");
            if (!list.Any())
                throw new ArgumentException("List without elements");
            this.first = first;
            length = list.Length;
            array = list;
        }

        /// <summary>
        /// Indexer with get and set  
        /// </summary>
        /// <param name="item">Int index</param>        
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when index out of array range</exception> 
        /// <exception cref="ArgumentNullException">Thrown in set  when value passed in indexer is null</exception>
        public T this[int item]
        {
            get
            {
                if (item > Last || item < first)
                    throw new ArgumentException("index out of array range");

                return array[item - first];
            }
            set
            {
                if (item > Last || item < first)
                    throw new ArgumentException("index out of array range");
                if (value == null)
                    throw new ArgumentNullException("value passed in indexer is null");
                array[item - first] = value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }
    }
}
