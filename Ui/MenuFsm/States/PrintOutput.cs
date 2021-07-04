using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ui.MenuFsm.Parameters;
using Ui.MenuFsm.Results;
using Ui.MenuFsm.States.Base;

namespace Ui.MenuFsm.States
{
    public class PrintOutput : BaseState
    {
        private string _content;

        private string _header;

        public override ExecuteResult Execute(object v)
        {
            var parameters = v as OutputParameters;

            _content = parameters.Content;

            _header = parameters.Header;

            var render = true;
            while (render)
            {
                Render();

                render = HandleInput();
            }

            return new ExecuteResult() { State = State.UserBookMenu };
        }

        protected override void Render()
        {
            Console.Clear();

            var headerPoint = Console.WindowWidth / 2 - _header.Length / 2;
            Console.WriteLine(new string(' ', headerPoint) + _header);

            Console.WriteLine(_content);
        }

        protected override bool HandleInput()
        {
            var input = Console.ReadKey(true);

            return false;
        }
    }
}
