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
    public class BookCatalog : IState
    {
        private readonly List<Filter> _filters = new()
        {
            new() { Name = "Все", Genre = Genre.FairyTale | Genre.Fantasy | Genre.Science },
            new() { Name = "Сказки", Genre = Genre.FairyTale },
            new() { Name = "Фентези", Genre = Genre.Fantasy },
            new() { Name = "Научная фантастика", Genre = Genre.Science },
        };

        private List<Book> _items;

        private List<int> _drawedItems;

        private int _selectedItem;

        private int _selectedFilter;

        private bool _changeState;

        private string _header;

        public ExecuteResult Execute(object v)
        {
            var parameters = v as ItemsParameters<Book>;

            _header = parameters.Header;

            _items = parameters.Items;

            var render = true;
            while (render)
            {
                Render();

                render = HandleInput();
            }

            if (!_changeState)
            {
                return new ExecuteResult { State = State.MainMenu };
            }

            return new IdExecuteResult { Id = _items[_selectedItem].Id, State = State.BookMenu };
        }

        private void Render()
        {
            Console.Clear();

            var headerPoint = Console.WindowWidth / 2 - _header.Length / 2;
            Console.WriteLine(new string(' ', headerPoint) + _header);

            Console.WriteLine($"<<{_filters[_selectedFilter].Name}>>");

            _drawedItems = new List<int>();

            for (int i = 0; i < _items.Count; i++)
            {
                if ((_items[i].Genre & _filters[_selectedFilter].Genre) > 0)
                {
                    _drawedItems.Add(i);
                    if (_selectedItem == i)
                    {
                        var color = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(_items[i].Name);
                        Console.ForegroundColor = color;
                    }
                    else
                    {
                        Console.WriteLine(_items[i].Name);
                    }
                }
            }
        }

        private bool HandleInput()
        {
            var input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    if (_drawedItems.Contains(_selectedItem))
                        _selectedItem = _selectedItem > _drawedItems.Min() ? _drawedItems[_drawedItems.IndexOf(_selectedItem) - 1] : _drawedItems.Max();
                    else
                        _selectedItem = _drawedItems.Min();
                    return true;
                case ConsoleKey.DownArrow:
                    if (_drawedItems.Contains(_selectedItem))
                        _selectedItem = _selectedItem < _drawedItems.Max() ? _drawedItems[_drawedItems.IndexOf(_selectedItem) + 1] : _drawedItems.Min();
                    else
                        _selectedItem = _drawedItems.Min();
                    return true;
                case ConsoleKey.LeftArrow:
                    _selectedFilter = _selectedFilter > 0 ? --_selectedFilter : _filters.Count - 1;
                    return true;
                case ConsoleKey.RightArrow:
                    _selectedFilter = _selectedFilter < _filters.Count - 1 ? ++_selectedFilter : 0;
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
