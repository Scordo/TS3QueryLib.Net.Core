using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Common.Responses
{
    public class CommandResponse : IDump, ICommandResponse
    {
        #region Properties

        public uint ErrorId { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public uint? FailedPermissionId { get; protected set; }
        public bool IsErroneous => (ErrorId != 0 && ErrorId != 1281) || IsBanned || ResponseText == null;
        public bool IsBanned { get; protected set; }
        public string BanExtraMessage { get; protected set; }
        public string BodyText { get; protected set; }
        public string StatusText { get; protected set; }
        public string ResponseText { get; protected set; }
        

        protected ICommandParameterGroupListParser CommandParameterGroupListParser { get; }
        protected CommandParameterGroupList StatusCommandParameterGroupList { get; private set; }
        protected CommandParameterGroupList BodyCommandParameterGroupList { get; private set; }

        protected virtual bool OnlyPostApplyResponseOnSuccess => true;

        #endregion

        #region Constructor

        public CommandResponse() : this(Net.Core.Common.CommandHandling.CommandParameterGroupListParser.StaticInstance)
        {
            
        }

        public CommandResponse(ICommandParameterGroupListParser commandParameterGroupListParser)
        {
            if (commandParameterGroupListParser == null)
                throw new ArgumentNullException(nameof(commandParameterGroupListParser));

            CommandParameterGroupListParser = commandParameterGroupListParser;
        }

        #endregion

        public virtual void ApplyResponseText(string responseText)
        {
            if (responseText != null)
            {

                ResponseText = responseText;
                responseText = responseText.Trim();
                int index = responseText.LastIndexOf(Util.QUERY_LINE_BREAK, StringComparison.Ordinal);
                BodyText = index == -1 ? null : responseText.Substring(0, index).Trim();
                StatusText = index == -1 ? responseText : responseText.Substring(index + 2).Trim();

                StatusCommandParameterGroupList = CommandParameterGroupListParser.Parse(StatusText);

                try
                {
                    BodyCommandParameterGroupList = CommandParameterGroupListParser.Parse(BodyText);
                }
                catch
                {
                    BodyCommandParameterGroupList = new CommandParameterGroupList();
                }


                if (StatusCommandParameterGroupList.Count == 0)
                    return;

                ErrorId = StatusCommandParameterGroupList.GetParameterValue<uint>("id");
                ErrorMessage = StatusCommandParameterGroupList.GetParameterValue("msg");
                BanExtraMessage = StatusCommandParameterGroupList.GetParameterValue("extra_msg");
                FailedPermissionId = StatusCommandParameterGroupList.GetParameterValue<uint?>("failed_permid");
                IsBanned = ErrorId == 3329 || ErrorId == 3331;
            }
            else
            {
                StatusCommandParameterGroupList = new CommandParameterGroupList();
                BodyCommandParameterGroupList = new CommandParameterGroupList();
            }

            if (!OnlyPostApplyResponseOnSuccess || !IsErroneous)
                OnPostApplyResponse();
        }

        protected virtual void OnPostApplyResponse()
        {
            
        }
    }
}