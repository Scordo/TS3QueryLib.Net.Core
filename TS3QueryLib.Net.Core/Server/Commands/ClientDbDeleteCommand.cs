using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientDbDeleteCommand : ExecutableValuelessCommand
    {
        public ClientDbDeleteCommand(uint clientDatabaseId) : base("ClientDbDelete")
        {
            AddParameter("cldbid", clientDatabaseId);
        }
    }
}