using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ServerGroupClient : IEntity<ServerGroupClient>
    {
        #region Properties

        public uint DatabaseId { get; protected set; }
        public string Nickname { get; protected set; }
        public string UniqueId { get; protected set; }

        #endregion

        #region Public Methods

        ServerGroupClient IEntity<ServerGroupClient>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {

            DatabaseId = currentParameterGroup.GetParameterValue<uint>("cldbid");
            Nickname = currentParameterGroup.GetParameterValue("client_nickname");
            UniqueId = currentParameterGroup.GetParameterValue("client_unique_identifier");

            return this;
        }

        #endregion
    }
}