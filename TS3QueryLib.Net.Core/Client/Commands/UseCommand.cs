using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Client.Commands
{
    /// <summary>
    /// Selects the server connection handler scHandlerID or, if no parameter is given, the currently active server connection handler is selected.
    /// </summary>
    public class UseCommand : ExecutableSingleValueCommand<int>
    {
        public UseCommand(int? serverConnectionHandlerId = null) : base("use", "schandlerid")
        {
            if (serverConnectionHandlerId.HasValue)
                AddParameter("schandlerid", serverConnectionHandlerId.Value);
        }
    }
}