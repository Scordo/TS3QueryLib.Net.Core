using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class PermGetCommand : ExecutableCommand<PermGetCommandResponse>
    {
        public PermGetCommand(uint permid) : base("PermGet")
        {
            AddParameter("permid", permid);
        }

        public PermGetCommand(string permsid) : base("PermGet")
        {
            AddParameter("permsid", permsid);
        }
    }
}