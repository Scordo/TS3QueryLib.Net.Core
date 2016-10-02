using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ChannelGroup : IEntity<ChannelGroup>
    {
        #region Properties

        public uint Id { get; set; }
        public string Name { get; set; }
        public ushort Type { get; protected set; }
        public uint IconId { get; protected set; }
        public bool SaveDb { get; protected set; }
        public uint SortId { get; protected set; }
        public uint NameMode { get; protected set; }

        #endregion
        
        #region Public Methods

        ChannelGroup IEntity<ChannelGroup>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));
            
            Id = currentParameterGroup.GetParameterValue<uint>("cgid");
            Name = currentParameterGroup.GetParameterValue("name");
            Type = currentParameterGroup.GetParameterValue<ushort>("type");
            IconId = currentParameterGroup.GetParameterValue<uint>("iconid");
            SaveDb = currentParameterGroup.GetParameterValue("savedb").ToBool();
            SortId = currentParameterGroup.GetParameterValue<uint>("sortid");
            NameMode = currentParameterGroup.GetParameterValue<uint>("namemode");

            return this;
        }

        #endregion        
    }
}
