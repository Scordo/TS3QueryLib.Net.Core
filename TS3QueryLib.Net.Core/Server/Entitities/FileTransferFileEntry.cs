using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class FileTransferFileEntry : IEntity<FileTransferFileEntry>
    {
        #region Properties

        public uint ChannelId { get; protected set; }
        public string Name { get; protected set; }
        public ulong Size { get; protected set; }
        public DateTime Created { get; protected set; }
        public uint? Type { get; protected set; }

        #endregion

        #region Public Methods

        FileTransferFileEntry IEntity<FileTransferFileEntry>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));

            ChannelId = firstParameterGroup.GetParameterValue<uint>("cid");
            Name = currentParameterGroup.GetParameterValue("name");
            Size = currentParameterGroup.GetParameterValue<ulong>("size");
            Created = new DateTime(1970, 1, 1).AddSeconds(currentParameterGroup.GetParameterValue<ulong>("datetime"));
            Type = currentParameterGroup.GetParameterValue<uint?>("type");

            return this;
        }

        #endregion
    }
}