using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class HelpCommandResponse : CommandResponse
    {
        public string HelpText => BodyText;
    }
}