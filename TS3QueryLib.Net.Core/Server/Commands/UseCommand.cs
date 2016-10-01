namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class UseCommand : ExecutableValuelessCommand
    {
        public UseCommand(ushort virtualServerPort) : base("Use")
        {
            AddParameter("port", virtualServerPort);
        }

        public UseCommand(uint virtualServerId) : base("Use")
        {
            AddParameter("sid", virtualServerId);
        }
    }
}