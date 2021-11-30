using servicebusreplayer.Models;

namespace servicebusreplayer.Services
{
    public class QueueClient : IQueueClient
    {
        private string connectionString;

        public QueueClient(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// //https://github.com/Azure/azure-service-bus/blob/master/samples/DotNet/Microsoft.Azure.ServiceBus/DeadletterQueue/Program.cs#L172
        public Task<IEnumerable<DlqMessage>> PeekDlqMessages()
        {
            var mockDLQMessages = new List<DlqMessage>
            {
                new DlqMessage
                {
                    MessageId = Guid.NewGuid(),
                    MessageBody = "Some message"
                }
            }.AsEnumerable();

            foreach (var dlqMsg in mockDLQMessages)
            {
                Console.WriteLine($"MessageId: {dlqMsg.MessageId} MessageBody:{dlqMsg.MessageBody}");
            }
            return Task.FromResult(mockDLQMessages);
        }

        //https://github.com/Azure/azure-service-bus/blob/master/samples/DotNet/Microsoft.Azure.ServiceBus/DeadletterQueue/Program.cs#L229
        public Task FixAndResubmitDlqMessages()
        {
            throw new NotImplementedException();
        }
    }
}