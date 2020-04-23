using NUnit.Framework;
using System.Collections;

namespace PriorityQueue.Tests
{
    public class Tests
    {
        PriorityQueue<int> queue;

        [SetUp]
        public void Setup()
        {
            queue = new PriorityQueue<int>();
        }

        [Test]
        public void EnqueueItemsInOrderTest()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(queue.Dequeue(), 1);
            Assert.AreEqual(queue.Dequeue(), 2);
            Assert.AreEqual(queue.Dequeue(), 3);
        }

        [Test]
        public void EnqueueItemsInReverseOrderTest()
        {
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);

            Assert.AreEqual(queue.Dequeue(), 1);
            Assert.AreEqual(queue.Dequeue(), 2);
            Assert.AreEqual(queue.Dequeue(), 3);
        }

        [Test]
        public void EnqueueMissedItemInOrderedQueue()
        {
            queue.Enqueue(1);

            // parent 1
            queue.Enqueue(2);
            queue.Enqueue(3);

            // parent 2
            queue.Enqueue(5);
            queue.Enqueue(6);

            // parent 3
            queue.Enqueue(7);
            queue.Enqueue(8);

            queue.Enqueue(4);

            Assert.AreEqual(queue.Dequeue(), 1);
            Assert.AreEqual(queue.Dequeue(), 2);
            Assert.AreEqual(queue.Dequeue(), 3);
            Assert.AreEqual(queue.Dequeue(), 4);
            Assert.AreEqual(queue.Dequeue(), 5);
            Assert.AreEqual(queue.Dequeue(), 6);
            Assert.AreEqual(queue.Dequeue(), 7);
            Assert.AreEqual(queue.Dequeue(), 8);
        }

        [Test]
        public void EnqueueMissedItemInOrderedQueueWithSwappedChildren()
        {
            queue.Enqueue(1);

            // parent 1
            queue.Enqueue(3);
            queue.Enqueue(2);

            // parent 2
            queue.Enqueue(6);
            queue.Enqueue(5);

            // parent 3
            queue.Enqueue(8);
            queue.Enqueue(7);

            queue.Enqueue(4);

            Assert.AreEqual(queue.Dequeue(), 1);
            Assert.AreEqual(queue.Dequeue(), 2);
            Assert.AreEqual(queue.Dequeue(), 3);
            Assert.AreEqual(queue.Dequeue(), 4);
            Assert.AreEqual(queue.Dequeue(), 5);
            Assert.AreEqual(queue.Dequeue(), 6);
            Assert.AreEqual(queue.Dequeue(), 7);
            Assert.AreEqual(queue.Dequeue(), 8);
        }

        [Test]
        public void EnqueueMissedItemInInversedQueue()
        {
            queue.Enqueue(8);
            queue.Enqueue(7);
            queue.Enqueue(6);
            queue.Enqueue(5);

            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);

            queue.Enqueue(4);

            Assert.AreEqual(queue.Dequeue(), 1);
            Assert.AreEqual(queue.Dequeue(), 2);
            Assert.AreEqual(queue.Dequeue(), 3);
            Assert.AreEqual(queue.Dequeue(), 4);
            Assert.AreEqual(queue.Dequeue(), 5);
            Assert.AreEqual(queue.Dequeue(), 6);
            Assert.AreEqual(queue.Dequeue(), 7);
            Assert.AreEqual(queue.Dequeue(), 8);
        }

        [Test]
        public void EnqueueInRotation()
        {
            var length = 5;
            for (int i = 0; i < length; i++)
            {
                queue = new PriorityQueue<int>();
                queue.Enqueue(i + 1);

                for (int j = 0; j < length; j++)
                {
                    if (i != j)
                    {
                        queue.Enqueue(j + 1);
                    }
                }

                for (int j = 0; j < length; j++)
                {
                    Assert.AreEqual(queue.Dequeue(), j + 1);
                }
            }
        }

        [Test]
        public void EnqueueInReversedRotation()
        {
            var length = 5;
            for (int i = length - 1; i >= 0; i--)
            {
                queue = new PriorityQueue<int>();
                queue.Enqueue(i + 1);

                for (int j = length - 1; j >= 0; j--)
                {
                    if (i != j)
                    {
                        queue.Enqueue(j + 1);
                    }
                }

                for (int j = 0; j < length; j++)
                {
                    Assert.AreEqual(queue.Dequeue(), j + 1);
                }
            }
        }

        [Test]
        public void QueueToListAndLoadFromTest()
        {
            queue.Enqueue(1);

            // parent 1
            queue.Enqueue(3);
            queue.Enqueue(2);

            // parent 2
            queue.Enqueue(6);
            queue.Enqueue(5);

            // parent 3
            queue.Enqueue(8);
            queue.Enqueue(7);

            queue.Enqueue(4);

            var binaryTreeList = queue.ToList();
            queue = PriorityQueue<int>.Load(binaryTreeList);

            Assert.AreEqual(queue.Dequeue(), 1);
            Assert.AreEqual(queue.Dequeue(), 2);
            Assert.AreEqual(queue.Dequeue(), 3);
            Assert.AreEqual(queue.Dequeue(), 4);
            Assert.AreEqual(queue.Dequeue(), 5);
            Assert.AreEqual(queue.Dequeue(), 6);
            Assert.AreEqual(queue.Dequeue(), 7);
            Assert.AreEqual(queue.Dequeue(), 8);
        }
    }
}