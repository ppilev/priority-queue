using System.Collections.Generic;

namespace System.Collections
{
    /// <summary>
    /// Represents a prioritized collection of <see cref="IComparable{T}"/> items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;

        public PriorityQueue()
        {
            data = new List<T>();
        }

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
        /// Removes and returns the object at the beginning of the <see cref="PriorityQueue{T}"./>
        /// </summary>
        /// <returns>The object that is removed from the beginning of the queue.</returns>
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
    }
}
