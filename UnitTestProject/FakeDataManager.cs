namespace UnitTestProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TestQuestService;

    class FakeDataManager : IDataManager
    {
        internal List<ClientMessage> Messages { get; private set; }

        public FakeDataManager()
        {
            Messages = new List<ClientMessage>();
        }
        public void AddRecord(ClientMessage msg)
        {
            if (msg == null)
                return;
            Messages.Add(msg);
        }

        public List<ClientMessage> GetMessages(MessageLevel level, DateTime startDate, DateTime endDate)
        {
            return Messages.Where(msg => msg.Level == level)
                    .Where(msg => msg.Date.CompareTo(startDate) >= 0)
                    .Where(msg => msg.Date.CompareTo(endDate) <= 0)
                    .ToList();
        }
    }
}
