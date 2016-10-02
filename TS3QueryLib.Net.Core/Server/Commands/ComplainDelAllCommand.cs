using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ComplainDelAllCommand : ExecutableValuelessCommand
    {
        public ComplainDelAllCommand(uint targetClientDatabaseId) : base("ComplainDelAll")
        {
            AddParameter("tcldbid", targetClientDatabaseId);
        }
    }
}