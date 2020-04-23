using System.Collections.Generic;
using System.Linq;

namespace System.Collections
{
    /// <summary>
    /// Represents a prioritized collection of <see cref="IComparable{T}"/> items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private IList<T> data;

        /// <summary>
        /// Loads the queue from a binary-tree ordered list.
        /// </summary>
        /// <param name="list">The list with binary-tree ordered items.</param>
        /// <returns>The <see cref="PriorityQueue{T}"/>.</returns>
        public static PriorityQueue<T> Load(IList<T> list)
        {
            return new PriorityQueue<T>(list.ToList());
        }

        /// <summary>
        /// Creates a new instance of <see cref="PriorityQueue{T}"/>
        /// </summary>
        public PriorityQueue() : this(new List<T>())
        {
        }

        private PriorityQueue(IList<T> items)
        {
            data = items;
        }

        /// <summary>
        ///  Gets the number of elements contained in <see cref="PriorityQueue{T}"/>.
        /// </summary>
        public int Count => data.Count;

        /// <summary>
        /// Adds an object to the <see cref="PriorityQueue{T}"/>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="PriorityQueue{T}"/>.</param>
        public void Enqueue(T item)
        {
            data.Add(item);
            int ci = data.Count - 1;
            while (ci > 0)
            {
                int pi = (ci - 1) / 2;
                if (data[ci].CompareTo(data[pi]) >= 0)
                    break;
                T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
                ci = pi;
            }
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the <see cref="PriorityQueue{T}"/>.
        /// </summary>
        /// <returns>The object that is removed from the beginning of the <see cref="PriorityQueue{T}"/>.</returns>
        public T Dequeue()
        {
            // Assumes pq isn't empty
            int li = data.Count - 1;
            T frontItem = data[0];
            data[0] = data[li];
            data.RemoveAt(li);

            --li;
            int pi = 0;
            while (true)
            {
                int ci = pi * 2 + 1;
                if (ci > li) break;
                int rc = ci + 1;
                if (rc <= li && data[rc].CompareTo(data[ci]) < 0)
                    ci = rc;
                if (data[pi].CompareTo(data[ci]) <= 0) break;
                T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp;
                pi = ci;
            }
            return frontItem;
        }

        /// <summary>
        /// Returns the object at the beginning of the <see cref="PriorityQueue{T}"/> without removing it.
        /// </summary>
        /// <returns> The object at the beginning of <see cref="PriorityQueue{T}"/>.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="PriorityQueue{T}"/> is empty.</exception>
        public T Peek()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("The System.Collections.Queue is empty.");
            }

            return data[0];
        }

        /// <summary>
        /// Returns the list of queue items as a binary-tree ordered list.
        /// </summary>
        /// <returns>The list of queue items.</returns>
        public List<T> ToList()
        {
            return data.ToList();
        }

    }
}
