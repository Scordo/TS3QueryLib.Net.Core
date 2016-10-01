namespace TS3QueryLib.Net.Core.Common.CommandHandling
{
    public interface ICommandParameterGroupListParser
    {
        CommandParameterGroupList Parse(string source);
    }
}