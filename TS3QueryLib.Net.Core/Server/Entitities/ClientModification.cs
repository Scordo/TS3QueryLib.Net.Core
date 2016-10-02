using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Entities;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ClientModification : ClientModificationBase
    {
        #region Properties

        public string Description { get; set; }
        public bool? IsTalker { get; set; }

        #endregion

        #region Public Methods

        public override void AddToCommand(Command command)
        {
            base.AddToCommand(command);
            AddToCommand(command, "client_description", Description);
            AddToCommand(command, "client_is_talker", IsTalker);
        }

        #endregion
    }
}