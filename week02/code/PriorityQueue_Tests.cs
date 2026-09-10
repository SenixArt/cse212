using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace week02.code
{
    [TestClass]
    public class PriorityQueue_Tests
    {
        // Test Case and Result Documentation:
        // Scenario: Enqueue items with different priorities (Low, High, Medium) and dequeue them.
        // Expected Result: The item with the highest priority is removed first, followed by medium, then low.
        // Defect Found: The original code didn't remove the item or handled comparisons incorrectly.
        [TestMethod]
        public void TestPriorityQueue_StandardPriorities()
        {
            var pq = new PriorityQueue();
            pq.Enqueue("Low", 1);
            pq.Enqueue("High", 10);
            pq.Enqueue("Medium", 5);

            Assert.AreEqual("High", pq.Dequeue());
            Assert.AreEqual("Medium", pq.Dequeue());
            Assert.AreEqual("Low", pq.Dequeue());
        }

        // Test Case and Result Documentation:
        // Scenario: Enqueue multiple items with the exact same priority level.
        // Expected Result: Follows strict FIFO order (the one added first gets dequeued first).
        // Defect Found: Using >= instead of > caused the newest duplicate to be pulled instead of the oldest.
        [TestMethod]
        public void TestPriorityQueue_FIFO_TieBreaking()
        {
            var pq = new PriorityQueue();
            pq.Enqueue("First", 5);
            pq.Enqueue("Second", 5);
            pq.Enqueue("Third", 5);

            Assert.AreEqual("First", pq.Dequeue());
            Assert.AreEqual("Second", pq.Dequeue());
            Assert.AreEqual("Third", pq.Dequeue());
        }

        // Test Case and Result Documentation:
        // Scenario: Attempting to call Dequeue on an empty PriorityQueue.
        // Expected Result: Throws an InvalidOperationException with the exact message "The queue is empty."
        // Defect Found: Missing validation check for an empty list or wrong exception type/message.
        [TestMethod]
        public void TestPriorityQueue_EmptyQueueException()
        {
            var pq = new PriorityQueue();

            var exception = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
            Assert.AreEqual("The queue is empty.", exception.Message);
        }
    }
}
