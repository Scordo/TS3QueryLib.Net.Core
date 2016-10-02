using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class VersionResponse : CommandResponse
    {
        public string Version { get; protected set; }
        public string Build { get; protected set; }
        public string Platform { get; protected set; }

        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            Version = BodyCommandParameterGroupList.GetParameterValue("version");
            Build = BodyCommandParameterGroupList.GetParameterValue("build");
            Platform = BodyCommandParameterGroupList.GetParameterValue("platform");
        }
    }
}