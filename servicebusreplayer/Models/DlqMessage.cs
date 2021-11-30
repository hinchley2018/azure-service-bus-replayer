namespace servicebusreplayer.Models
{
    public class DlqMessage
    {
        public Guid MessageId { get; set; }
        public string MessageBody { get; set; }
    }
}