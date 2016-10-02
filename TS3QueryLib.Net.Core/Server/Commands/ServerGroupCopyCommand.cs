using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Entities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerGroupCopyCommand : ExecutableSingleValueCommand<uint?>
    {
        public ServerGroupCopyCommand(uint sourceGroupId, string targetGroupName, GroupDatabaseType groupType) : base("ServerGroupCopy", "sgid")
        {
            AddParameter("ssgid", sourceGroupId);
            AddParameter("tsgid", 0);
            AddParameter("name", targetGroupName);
            AddParameter("type", (int)groupType);
        }

        public ServerGroupCopyCommand(uint sourceGroupId, int targetGroupId, GroupDatabaseType groupType) : base("ServerGroupCopy", "sgid")
        {
            AddParameter("ssgid", sourceGroupId);
            AddParameter("tsgid", targetGroupId);
            AddParameter("name", "-");
            AddParameter("type", (int)groupType);
        }
    }
}