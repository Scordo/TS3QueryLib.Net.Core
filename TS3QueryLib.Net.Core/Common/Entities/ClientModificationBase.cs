using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Common.Entities
{
    public abstract class ClientModificationBase : ModificationBase
    {
        #region Properties

        public string Nickname { get; set; }

        #endregion

        #region Public Methods

        public virtual void AddToCommand(Command command)
        {
            AddToCommand(command, "client_nickname", Nickname);
        }

        #endregion
    }
}