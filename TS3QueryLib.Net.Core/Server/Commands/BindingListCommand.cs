using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class BindingListCommand : ExecutableValueListCommand<string>
    {
        public BindingListCommand() : base("BindingList")
        {
            
        }
        
        protected override void BeforApplyResponseText(ValueListCommandResponse<string> response, string responseText)
        {
            response.ValueName = "ip";
        }
    }
}