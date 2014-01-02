namespace TestQuestService
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface ILogService
    {
        [OperationContract]
        void AddRecord(ClientMessage msg);

        [OperationContract]
        List<ClientMessage> GetMessages(MessageLevel level, DateTime startDate, DateTime endDate);
    }
}
