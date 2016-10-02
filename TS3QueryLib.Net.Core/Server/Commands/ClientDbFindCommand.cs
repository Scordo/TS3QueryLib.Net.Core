using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientDbFindCommand : ExecutableValueListCommand<uint>
    {
        public ClientDbFindCommand(string pattern, bool useUniqueIdInsteadOfNicknameForSearch = false) : base("ClientDbFind", "cldbid")
        {
            if (pattern.IsNullOrTrimmedEmpty())
                throw new ArgumentException("pattern is null or trimmed empty", nameof(pattern));

            AddParameter("pattern", pattern);

            if (useUniqueIdInsteadOfNicknameForSearch)
                AddOption("uid");
        }
    }
}