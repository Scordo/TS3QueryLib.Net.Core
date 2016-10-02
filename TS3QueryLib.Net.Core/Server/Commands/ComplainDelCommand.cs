using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ComplainDelCommand : ExecutableValuelessCommand
    {
        public ComplainDelCommand(uint targetClientDatabaseId, uint sourceClientDatabaseId) : base("ComplainDel")
        {
            AddParameter("tcldbid", targetClientDatabaseId);
            AddParameter("fcldbid", sourceClientDatabaseId);
        }
    }
}