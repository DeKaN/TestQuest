namespace TestQuestService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DefaultDataManager : IDataManager
    {
        public void AddRecord(ClientMessage msg)
        {
            if (msg == null)
                return;
            using (ModelContext dbContext = new ModelContext())
            {
                dbContext.ClientMessageSet.Add(msg);
                dbContext.SaveChanges();
            }
        }

        public List<ClientMessage> GetMessages(MessageLevel level, DateTime startDate, DateTime endDate)
        {
            using (ModelContext dbContext = new ModelContext())
            {
                return dbContext.ClientMessageSet.Where(msg => msg.Level == level)
                    .Where(msg => msg.Date.CompareTo(startDate) >= 0)
                    .Where(msg => msg.Date.CompareTo(endDate) <= 0)
                    .ToList();
            }
        }
    }
}