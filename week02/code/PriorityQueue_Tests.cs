using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with varying priorities (low, high, medium) and dequeue all of them.
    // Expected Result: Items come out in order of highest priority first: "high", "medium", "low"
    // Defect(s) Found: The loop used 'index < _queue.Count - 1', which skipped checking the last 
    // item in the list, so the highest-priority item was missed whenever it was last in the queue.
    public void TestPriorityQueue_HighestPriorityFirst()
        {
            var priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue("low", 1);
            priorityQueue.Enqueue("high", 10);
            priorityQueue.Enqueue("medium", 5);

            Assert.AreEqual("high", priorityQueue.Dequeue());
            Assert.AreEqual("medium", priorityQueue.Dequeue());
            Assert.AreEqual("low", priorityQueue.Dequeue());
        }

    [TestMethod]
    // Scenario: Enqueue several items that share the same highest priority value, in a known order.
    // Expected Result: The item enqueued first among the tied items is dequeued first (FIFO tie-break).
    // Defect(s) Found: The comparison used '>=' instead of '>', so later-enqueued items with an 
    // equal priority incorrectly replaced earlier ones as the "winner," breaking the tie-break rule.
    public void TestPriorityQueue_TieBreaksByFIFOOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 5);
        priorityQueue.Enqueue("third", 5);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items, then Dequeue the highest priority one, then try to Dequeue again.
    // Expected Result: The highest-priority item should not be returned a second time; the next 
    // highest item should come out instead.
    // Defect(s) Found: Dequeue never removed the item from the internal list after returning it, 
    // so the same highest-priority item would be returned repeatedly on every call.
    public void TestPriorityQueue_DequeueRemovesItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 1);
        priorityQueue.Enqueue("b", 2);

        Assert.AreEqual("b", priorityQueue.Dequeue());
        Assert.AreEqual("a", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Call Dequeue on a queue with no items in it.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: None - this behavior was already implemented correctly.
    public void TestPriorityQueue_EmptyQueueThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}