namespace TS3QueryLib.Net.Core.Common.Commands
{
    public interface ICommand
    {
        string Name { get; }

        void AddOption(string optionName);
        void AddRaw(string rawText);
        void AddParameter(string parameterName);
        void AddParameter(string parameterName, int parameterValue);
        void AddParameter(string parameterName, string parameterValue);
        void AddParameter(string parameterName, uint parameterValue);
        void AddParameter(string parameterName, ulong parameterValue);
        void AddParameter(string parameterName, char parameterValue);
        void AddParameter(string parameterName, bool parameterValue);
        void AddParameter(string parameterName, string parameterValue, uint? groupIndex);
        void AddParameter(string parameterName, ulong parameterValue, uint? groupIndex);
        void AddParameter(string parameterName, uint parameterValue, uint? groupIndex);
        void AddParameter(string parameterName, int parameterValue, uint? groupIndex);
        void AddParameter(string parameterName, char parameterValue, uint? groupIndex);
        void AddParameter(string parameterName, bool parameterValue, uint? groupIndex);
        string ToString();
    }
}