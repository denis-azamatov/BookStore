using Ui.MenuFsm.Results;

namespace Ui.MenuFsm.States.Base
{
    public interface IState
    {
        ExecuteResult Execute(object v);
    }
}