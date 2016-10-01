using System.Threading.Tasks;

namespace TS3QueryLib.Net.Core
{
    public interface ICommandExecutor
    {
        string Execute(string commandText);
        Task<string> ExecuteAsync(string commandText);
    }
}