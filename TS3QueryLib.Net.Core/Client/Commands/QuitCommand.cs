using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Client.Commands
{
    /// <summary>
    /// Closes the ClientQuery connection to the TeamSpeak 3 Client instance.
    /// </summary>
    public class QuitCommand : ExecutableValuelessCommand
    {
        public QuitCommand() : base("Quit")
        {
        }
    }
}