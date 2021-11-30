using servicebusreplayer.Models;

namespace servicebusreplayer.Services
{
    public interface IQueueClient
    {
        Task<IEnumerable<DlqMessage>> PeekDlqMessages();
        Task FixAndResubmitDlqMessages();
    }
}