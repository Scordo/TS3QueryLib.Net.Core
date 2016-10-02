using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class FileTransferListEntry : IEntity<FileTransferListEntry>
    {
        #region Properties

        public uint ClientId { get; protected set; }
        public string Path { get; protected set; }
        public string Name { get; protected set; }
        public ulong Size { get; protected set; }
        public ulong SizeDone { get; protected set; }
        public uint ClientFtFileId { get; protected set; }
        public uint ServerFtFileId { get; protected set; }
        public uint Sender { get; protected set; }
        public uint Status { get; protected set; }
        public double CurrentSpeed { get; protected set; }

        #endregion

        #region Public Methods

        FileTransferListEntry IEntity<FileTransferListEntry>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));
            
            ClientId = currentParameterGroup.GetParameterValue<uint>("clid");
            Path = currentParameterGroup.GetParameterValue("path");
            Name = currentParameterGroup.GetParameterValue("name");
            Size = currentParameterGroup.GetParameterValue<ulong>("size");
            SizeDone = currentParameterGroup.GetParameterValue<ulong>("sizedone");
            ClientFtFileId = currentParameterGroup.GetParameterValue<uint>("clientftfid");
            ServerFtFileId = currentParameterGroup.GetParameterValue<uint>("serverftfid");
            Sender = currentParameterGroup.GetParameterValue<uint>("sender");
            Status = currentParameterGroup.GetParameterValue<uint>("status");
            CurrentSpeed = currentParameterGroup.GetParameterValue<double>("current_speed");

            return this;
        }

        #endregion
    }
}