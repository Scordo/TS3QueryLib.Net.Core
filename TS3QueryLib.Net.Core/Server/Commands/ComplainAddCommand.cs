using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ComplainAddCommand : ExecutableValuelessCommand
    {
        public ComplainAddCommand(uint targetClientDatabaseId, string message) : base("ComplainAdd")
        {
            AddParameter("tcldbid", targetClientDatabaseId);
            AddParameter("message", message);
        }
    }
}