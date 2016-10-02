using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerGroupDelCommand : ExecutableValuelessCommand
    {
        public ServerGroupDelCommand(uint serverGroupId, bool forceDeleteWhenClientsExist = false) : base("ServerGroupDel")
        {
            AddParameter("sgid", serverGroupId);
            AddParameter("force", forceDeleteWhenClientsExist);
        }
    }
}