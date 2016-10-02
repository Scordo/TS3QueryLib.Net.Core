using TS3QueryLib.Net.Core.Common;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class NamedPermissionLight : IDump
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}