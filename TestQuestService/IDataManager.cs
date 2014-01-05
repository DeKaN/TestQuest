namespace TestQuestService
{
    using System;
    using System.Collections.Generic;

    public interface IDataManager
    {
        void AddRecord(ClientMessage msg);

        List<ClientMessage> GetMessages(MessageLevel level, DateTime startDate, DateTime endDate);
    }
}
