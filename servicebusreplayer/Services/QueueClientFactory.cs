namespace servicebusreplayer.Services
{
    public class QueueClientFactory
    {
        public QueueClient Create(string connectionString)
        {
            return new QueueClient(connectionString);
        }
    }
}