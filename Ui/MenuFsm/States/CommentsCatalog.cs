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
    public class CommentsCatalog : BaseState
    {
        private List<string> _items;

        private bool _changeState;

        private string _header;

        private Guid _id;

        public override ExecuteResult Execute(object v)
        {
            var parameters = v as ItemsParameters<string>;

            _items = parameters.Items;

            _header = parameters.Header;

            _id = parameters.Id;

            var render = true;
            while (render)
            {
                Render();

                render = HandleInput();
            }

            if (!_changeState)
            {
                return new IdExecuteResult() { Id = _id, State = State.BookMenu };
            }

            return new IdExecuteResult() { Id = _id, State = State.CommentInput };
        }

        protected override void Render()
        {
            Console.Clear();

            var headerPoint = Console.WindowWidth / 2 - _header.Length / 2;
            Console.WriteLine(new string(' ', headerPoint) + _header);

            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine(_items[i]);
                Console.WriteLine(new string('-', Console.WindowWidth));
            }

            Console.WriteLine("Нажмите Enter чтоба добавить комментарий");
        }

        protected override bool HandleInput()
        {
            var input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.Enter:
                    _changeState = true;
                    return false;
                case ConsoleKey.Backspace:
                    _changeState = false;
                    return false;
                default:
                    return true;
            }
        }
    }
}