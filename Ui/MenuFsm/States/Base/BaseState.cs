using Ui.MenuFsm.Results;

namespace Ui.MenuFsm.States.Base
{
    public abstract class BaseState : IState
    {
        public abstract ExecuteResult Execute(object v);
        protected abstract void Render();
        protected abstract bool HandleInput();
    }
}
