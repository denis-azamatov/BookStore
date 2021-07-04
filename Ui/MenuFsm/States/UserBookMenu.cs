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
    public class UserBookMenu : BaseState
    {
        private List<string> _items;

        private int _selectedItem;

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
                return new ExecuteResult { State = State.UserCatalog };
            }

            return _items[_selectedItem] switch
            {
                "Распечатать красиво" => new IdExecuteResult() { Id = _id, State = State.BeautifyPrint },
                "Просто распечатать" => new IdExecuteResult() { Id = _id, State = State.SimplePrint },
                _ => new IdExecuteResult() { Id = _id, State = State.BookMenu }
            };
        }

        protected override void Render()
        {
            Console.Clear();

            var headerPoint = Console.WindowWidth / 2 - _header.Length / 2;
            Console.WriteLine(new string(' ', headerPoint) + _header);

            for (int i = 0; i < _items.Count; i++)
            {
                if (_selectedItem == i)
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(_items[i]);
                    Console.ForegroundColor = color;
                }
                else
                {
                    Console.WriteLine(_items[i]);
                }
            }
        }

        protected override bool HandleInput()
        {
            var input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    _selectedItem = _selectedItem > 0 ? --_selectedItem : _items.Count - 1;
                    return true;
                case ConsoleKey.DownArrow:
                    _selectedItem = _selectedItem < _items.Count - 1 ? ++_selectedItem : 0;
                    return true;
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
