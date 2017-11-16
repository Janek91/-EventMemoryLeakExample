using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MemoryLeak.Test
{
    [TestClass]
    public class WeakAggregatorTests
    {
        [TestMethod]
        public void TestWeakAggregator()
        {
            string message1 = "x";
            string message2 = "y";
            string message3 = "z";

            WeakEventAggregator weakAggregator = new WeakEventAggregator();
            weakAggregator.Subscribe<string>(s => message1 = "Subscriber 1 got " + s);
            weakAggregator.Subscribe<string>(s => message2 = "Subscriber 2 got " + s);
            weakAggregator.Subscribe<DateTime>(s => message3 = "Subscriber 3 got called");
            weakAggregator.Publish("hello world");
            Assert.AreEqual("Subscriber 1 got hello world", message1);
            Assert.AreEqual("Subscriber 2 got hello world", message2);
            Assert.AreEqual("z", message3);
        }
    }
}