namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class ClientDbInfoCommandResponse : ClientInfoBaseCommandResponse
    {
        public string LastIP { get; protected set; }

        protected override void OnPostApplyResponse()
        {
            base.OnPostApplyResponse();
            
            LastIP = BodyCommandParameterGroupList.GetParameterValue("client_lastip");
        }
    }
}