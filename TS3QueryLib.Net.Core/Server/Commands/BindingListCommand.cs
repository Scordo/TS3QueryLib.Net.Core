using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class BindingListCommand : ExecutableValueListCommand<string>
    {
        public BindingListCommand() : base("BindingList", "ip")
        {
            
        }
    }
}