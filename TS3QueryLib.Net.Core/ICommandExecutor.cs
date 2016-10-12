using System.Threading.Tasks;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core
{
    public interface ICommandExecutor
    {
        string Execute(ICommand command);
        Task<string> ExecuteAsync(ICommand command);
    }
}