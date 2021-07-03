using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ui.MenuFsm.Parameters;
using Ui.MenuFsm.Results;

namespace Ui.MenuFsm.States
{
    public class Preview : IState
    {
        private string _content;

        private string _header;

        public ExecuteResult Execute(object v)
        {
            var parameters = v as PreviewParameters;

            _content = parameters.Content;

            _header = parameters.Header;

            var render = true;
            while (render)
            {
                Render();

                render = HandleInput();
            }

            return new ExecuteResult() { State = State.BookMenu };
        }

        private void Render()
        {
            Console.Clear();

            var headerPoint = Console.WindowWidth / 2 - _header.Length / 2;
            Console.WriteLine(new string(' ', headerPoint) + _header);

            Console.WriteLine(_content);
        }

        private bool HandleInput()
        {
            var input = Console.ReadKey(true);

            return false;
        }
    }
}
