using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerSnapshotDeployCommand : ExecutableValuelessCommand
    {
        public ServerSnapshotDeployCommand(string snapshotData) : base("ServerSnapshotDeploy")
        {
            if (snapshotData.IsNullOrTrimmedEmpty())
                throw new ArgumentException("snapshotData is null or trimmed empty", nameof(snapshotData));
            
            AddParameter(snapshotData);
        }
    }
}
