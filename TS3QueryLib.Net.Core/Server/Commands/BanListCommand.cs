using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class BanListCommand : ExecutableEntityListCommand<BanListEntry>
    {
        public BanListCommand() : base("BanList")
        {
        }
    }
}