using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerGroupAddClientCommand : ExecutableValuelessCommand
    {
        public ServerGroupAddClientCommand(uint serverGroupId, uint clientDatabaseId) : base("ServerGroupAddClient")
        {
            AddParameter("sgid", serverGroupId);
            AddParameter("cldbid", clientDatabaseId);
        }
    }
}