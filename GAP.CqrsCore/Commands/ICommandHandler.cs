using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;
namespace GAP.CqrsCore.Commands
{
    /// <summary>
    /// Base interface for command handlers
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public interface ICommandHandler<in TParameter> where TParameter : ICommand
    {

        /// <summ        /// Executes a command handler
        /// </summary>
        /// <param name="command">The command to be used</param>
        Result Execute(TParameter command);
    }

}
