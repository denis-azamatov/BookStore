using System.Collections.Generic;
using CORE.Setup;
using Ui.MenuFsm;
using Ui.MenuFsm.States;
using Ui.MenuFsm.States.Base;

namespace Ui
{
    /// <summary>
    /// Класс запуска приложения
    /// </summary>
    internal static class StartUp
    {
        /// <summary>
        /// Запускает приложение
        /// </summary>
        internal static void Start()
        {
            Setup.FillStorage();

            var states = GetStates();

            var dispatcher = new Dispatcher(states);

            dispatcher.Process();
        }

        /// <summary>
        /// Создает состояния для конечного автомата
        /// </summary>
        private static Dictionary<State, IState> GetStates()
        {
            return new()
            {
                { State.MainMenu, new MainMenu() },
                { State.BookCatalog, new BookCatalog() },
                { State.BookMenu, new BookMenu() },
                { State.CommentCatalog, new CommentsCatalog() },
                { State.CommentInput, new CommentInput() },
                { State.Preview, new Preview() },
                { State.BucketCatalog, new BucketCatalog() },
                { State.UserCatalog, new UserCatalog() },
                { State.UserBookMenu, new UserBookMenu() },
                { State.PrintOutput, new PrintOutput() }
            };
        }
    }
}
