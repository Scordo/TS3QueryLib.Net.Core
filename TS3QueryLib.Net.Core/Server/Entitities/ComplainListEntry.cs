using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ComplainListEntry : IEntity<ComplainListEntry>
    {
        #region Properties

        public uint TargetClientDatabaseId { get; protected set; }
        public string TargetName { get; protected set; }
        public uint SourceClientDatabaseId { get; protected set; }
        public string SourceName { get; protected set; }
        public string Message { get; protected set; }
        public DateTime Created { get; protected set; }

        #endregion

        #region Public Methods

        public ComplainListEntry ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));
            
            TargetClientDatabaseId = currentParameterGroup.GetParameterValue<uint>("tcldbid");
            TargetName = currentParameterGroup.GetParameterValue("tname");
            SourceClientDatabaseId = currentParameterGroup.GetParameterValue<uint>("fcldbid");
            SourceName = currentParameterGroup.GetParameterValue("fname");
            Message = currentParameterGroup.GetParameterValue("message");
            Created = new DateTime(1970, 1, 1).AddSeconds(currentParameterGroup.GetParameterValue<ulong>("timestamp"));

            return this;
        }

        #endregion
    }
}