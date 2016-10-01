namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public static class VirtualServerStatusHelper
    {
        public static VirtualServerStatus Parse(string value)
        {
            switch (value?.ToLower())
            {
                case "online":
                    return VirtualServerStatus.Online;
                case "virtual":
                    return VirtualServerStatus.Virtual;
                case "other_instance":
                    return VirtualServerStatus.OtherInstance;
                default:
                    return VirtualServerStatus.None;
            }
        }
    }
}