using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class CustomInfoEntry : CustomSearchEntry, IEntity<CustomInfoEntry>
    {
        #region Public Methods

        CustomInfoEntry IEntity<CustomInfoEntry>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            ApplyFrom(currentParameterGroup);
            return this;
        }

        #endregion
    }
}