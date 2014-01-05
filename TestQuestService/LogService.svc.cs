namespace TestQuestService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LogService : ILogService
    {
        private IDataManager manager;
        public LogService(IDataManager dataManager)
        {
            manager = dataManager;
        }

        public LogService()
            : this(new DefaultDataManager())
        {
        }
        public void AddRecord(ClientMessage msg)
        {
            manager.AddRecord(msg);
        }

        public List<ClientMessage> GetMessages(MessageLevel level, DateTime startDate, DateTime endDate)
        {
            return manager.GetMessages(level, startDate, endDate);
        }
    }
}
