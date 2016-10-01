namespace TS3QueryLib.Net.Core.Common.CommandHandling
{
    public class CommandParameterGroupListParser : ICommandParameterGroupListParser
    {
        public static ICommandParameterGroupListParser StaticInstance { get; } = new CommandParameterGroupListParser();

        CommandParameterGroupList ICommandParameterGroupListParser.Parse(string source)
        {
            return CommandParameterGroupList.Parse(source);
        }
    }
}