namespace UnitTestProject
{
    using System;
    using System.Data.Common;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestQuestService;

    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void TestAdd()
        {
            FakeDataManager manager = new FakeDataManager();
            ClientMessage msg = new ClientMessage { Date = DateTime.Now, Level = MessageLevel.Error };
            LogService service = new LogService(manager);
            service.AddRecord(msg);
            var found = manager.Messages.Where(m => m.Date.Equals(msg.Date)).ToList();
            Assert.AreEqual(1, found.Count);
        }
    }
}
