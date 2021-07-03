using System.Collections.Generic;
using CORE.Setup;
using Ui.MenuFsm;
using Ui.MenuFsm.States;

namespace Ui
{
    internal static class StartUp
    {
        internal static void Start()
        {
            Setup.FillStorage();

            var states = new Dictionary<State, IState>()
            {
                {State.MainMenu, new MainMenu()},
                {State.BookCatalog,new BookCatalog()},
                {State.BookMenu,new BookMenu()},
                {State.CommentCatalog,new CommentsCatalog()},
                {State.CommentInput,new CommentInput()},
                {State.Preview,new Preview()}
            };

            var dispatcher = new Dispatcher(states);

            dispatcher.Process();
        }
    }
}
