using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class SetClientChannelGroupCommand : ExecutableValuelessCommand
    {
        public SetClientChannelGroupCommand(uint channelGroupId, uint channelId, uint clientDatabaseId) : base("SetClientChannelGroup")
        {
            AddParameter("cgid", channelGroupId);
            AddParameter("cid", channelId);
            AddParameter("cldbid", clientDatabaseId);
        }
    }
}