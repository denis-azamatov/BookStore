using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.Models;
using Ui.MenuFsm.Parameters;
using Ui.MenuFsm.Results;

namespace Ui.MenuFsm.States
{
    public class BookMenu : IState
    {
        private List<string> _items;

        private int _selectedItem;

        private bool _changeState;

        private string _header;

        private Guid _id;

        public ExecuteResult Execute(object v)
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
                return new ExecuteResult { State = State.BookCatalog };
            }

            return _items[_selectedItem] switch
            {
                "Добавить в корзину" => new IdExecuteResult() { Id = _id, State = State.AddToBucket },
                "Комментарии" => new IdExecuteResult() { Id = _id, State = State.CommentCatalog },
                "Превью" => new IdExecuteResult() { Id = _id, State = State.Preview },
                _ => new IdExecuteResult() { Id = _id, State = State.BookMenu }
            };
        }

        private void Render()
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

        private bool HandleInput()
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
