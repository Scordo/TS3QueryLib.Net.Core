using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Client.Commands
{
    /// <summary>
    /// Read help files
    /// </summary>
    public class HelpCommand : ExecutableCommand<HelpCommandResponse>
    {
        public HelpCommand(string commandName = null) : base("Help")
        {
            if (commandName != null)
                AddParameter(commandName);
        }
    }
}