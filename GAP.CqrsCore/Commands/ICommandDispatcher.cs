using GAP.Base.ResultValidation;
using GAP.CqrsCore.Commands;

namespace GAP.CqrsCore.Commands
{   
    public interface ICommandDispatcher
    {
        Result Dispatch<TParameter>(TParameter command) where TParameter : ICommand;
    }
}
