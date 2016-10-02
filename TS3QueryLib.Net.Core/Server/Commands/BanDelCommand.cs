using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class BanDelCommand : ExecutableValuelessCommand
    {
        public BanDelCommand(uint banId) : base("BanDel")
        {
            AddParameter("banid", banId);
        }
    }
}