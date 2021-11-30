using System;
using System.Threading.Tasks;

namespace servicebusreplayer
{
    class Program
    {
        //TODO: DI queue service
        static async Task<int> Main(string[] args)
        {
            //TODO: parse input and do stuff...
            var parsedAlias = "post-dumb-message";

            var dlqMessages = GetDLQMessagesFromQueue(parsedAlias);
            
            return 0;
        }

        static List<DlqMessage> GetDLQMessagesFromQueue(string queueAlias)
        {
            
            var mockDLQMessages = new List<DlqMessage>
            {
                new DlqMessage
                {
                    MessageId = Guid.NewGuid(),
                    MessageBody = "Some message"
                }
            };

            foreach (var dlqMsg in mockDLQMessages)
            {
                Console.WriteLine($"MessageId: {dlqMsg.MessageId} MessageBody:{dlqMsg.MessageBody}");
            }
            return mockDLQMessages;
        }
    }
    class DlqMessage
    {
        public Guid MessageId { get; set; }
        public string MessageBody { get; set; }
    }

}
