using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class GetBindingListCommand : ExecutableCommand<ValueListCommandResponse<string>>
    {
        public GetBindingListCommand() : base(CommandName.BindingList)
        {
            
        }
        
        protected override void BeforApplyResponseText(ValueListCommandResponse<string> response, string responseText)
        {
            response.ValueName = "ip";
        }
    }
}