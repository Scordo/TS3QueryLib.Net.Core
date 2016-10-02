using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Entities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelGroupCopyCommand : ExecutableSingleValueCommand<uint?>
    {
        public ChannelGroupCopyCommand(uint sourceGroupId, string targetGroupName, GroupDatabaseType groupType) : base("ChannelGroupCopy", "sgid")
        {
            AddParameter("scgid", sourceGroupId);
            AddParameter("tcgid", 0);
            AddParameter("name", targetGroupName);
            AddParameter("type", (int)groupType);
        }

        public ChannelGroupCopyCommand(uint sourceGroupId, int targetGroupId, GroupDatabaseType groupType) : base("ChannelGroupCopy", "sgid")
        {
            AddParameter("scgid", sourceGroupId);
            AddParameter("tcgid", targetGroupId);
            AddParameter("name", "-");
            AddParameter("type", (int)groupType);
        }
    }
}