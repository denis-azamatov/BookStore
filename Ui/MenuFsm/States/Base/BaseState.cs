using Ui.MenuFsm.Results;

namespace Ui.MenuFsm.States.Base
{
    public abstract class BaseState : IState
    {
        /// <summary>
        /// Вызывает состояние
        /// </summary>
        public abstract ExecuteResult Execute(object v);

        /// <summary>
        /// Отрисовывает текущее состояние
        /// </summary>
        protected abstract void Render();

        /// <summary>
        /// Обрабатывает ввод пользователя
        /// </summary>
        protected abstract bool HandleInput();
    }
}
