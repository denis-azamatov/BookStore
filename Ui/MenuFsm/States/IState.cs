using Ui.MenuFsm.Results;

namespace Ui.MenuFsm.States
{
    public interface IState
    {
        ExecuteResult Execute(object v);
    }
}