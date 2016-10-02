using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class CustomSearchCommand : ExecutableEntityListCommand<CustomSearchEntry>
    {
        public CustomSearchCommand(string ident, string pattern) : base("CustomSearch")
        {
            AddParameter("ident", ident);
            AddParameter("pattern", pattern);
        }
    }
}