using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ServerGroupClientListCommand : ExecutableEntityListCommand<ServerGroupClient>
    {
        public ServerGroupClientListCommand(uint serverGroupId, bool includeNicknamesAndUid = false) : base("ServerGroupClientList")
        {
            AddParameter("sgid", serverGroupId);

            if (includeNicknamesAndUid)
                AddOption("names");
        }
    }
}