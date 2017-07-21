using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Client.Responses
{
    public class HelpCommandResponse : CommandResponse
    {
        public string HelpText => BodyText;
    }
}