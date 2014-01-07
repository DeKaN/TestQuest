namespace UnitTestProject
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestQuestService;

    [TestClass]
    public class UnitTest
    {
        private const int maxDiff = 10, count = 5;

        private const MessageLevel level = MessageLevel.Error;

        private DateTime baseDate = DateTime.Now;
        Random rg = new Random();

        private ClientMessage GenerateMessage()
        {
            return new ClientMessage { Date = baseDate.AddDays(rg.Next(-maxDiff, maxDiff + 1)), Level = level };
        }

        [TestMethod]
        public void TestAdd()
        {
            var manager = new FakeDataManager();
            var msg = GenerateMessage();
            var service = new LogService(manager);
            service.AddRecord(msg);
            var found = manager.Messages.Where(m => m.Date.Equals(msg.Date)).ToList();
            Assert.AreEqual(1, found.Count);
        }

        [TestMethod]
        public void TestGet()
        {
            var manager = new FakeDataManager();
            for (int i = 0; i < count; i++)
            {
                manager.Messages.Add(GenerateMessage());
            }
            var service = new LogService(manager);
            var loaded = service.GetMessages(level, baseDate.AddDays(-maxDiff), baseDate.AddDays(maxDiff));
            Assert.AreEqual(count, loaded.Count);
        }
    }
}
