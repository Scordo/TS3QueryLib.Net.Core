using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Client.Commands
{
    /// <summary>
    /// Displays a list of all currently active server connection handlers.
    /// </summary>
    public class ServerConnectionHandlerListCommand : ExecutableValueListCommand<uint>
    {
        public ServerConnectionHandlerListCommand() : base("serverconnectionhandlerlist", "schandlerid")
        {
        }
    }
}