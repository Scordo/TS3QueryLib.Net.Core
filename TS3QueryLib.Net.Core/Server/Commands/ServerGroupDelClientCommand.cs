using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerGroupDelClientCommand : ExecutableValuelessCommand
    {
        public ServerGroupDelClientCommand(uint serverGroupId, uint clientDatabaseId) : base("ServerGroupDelClient")
        {
            AddParameter("sgid", serverGroupId);
            AddParameter("cldbid", clientDatabaseId);
        }
    }
}