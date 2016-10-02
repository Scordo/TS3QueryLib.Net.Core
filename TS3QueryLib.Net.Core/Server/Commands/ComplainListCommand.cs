using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ComplainListCommand : ExecutableEntityListCommand<ComplainListEntry>
    {
        public ComplainListCommand(uint? targetClientDatabaseId = null) : base("ComplainList")
        {
            if (targetClientDatabaseId.HasValue)
                AddParameter("tcldbid", targetClientDatabaseId.Value);
        }
    }
}