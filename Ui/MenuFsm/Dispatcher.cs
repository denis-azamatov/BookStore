using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE;
using CORE.Commands.BookCommands;
using CORE.Commands.CommentCommands;
using CORE.Contexts;
using CORE.Models;
using Ui.MenuFsm.Parameters;
using Ui.MenuFsm.Printers;
using Ui.MenuFsm.Results;
using Ui.MenuFsm.States;
using Ui.MenuFsm.States.Base;
using static System.String;

namespace Ui.MenuFsm
{
    /// <summary>
    /// Конечный автомат интерфейса
    /// </summary>
    public class Dispatcher
    {
        private readonly Dictionary<State, IState> _states;

        private State _currentState = State.MainMenu;

        private Guid _currentBookId = Guid.Empty;

        private string _buffer = Empty;

        public Dispatcher(Dictionary<State, IState> states)
        {
            _states = states;
        }

        /// <summary>
        /// Запускает интерфейс
        /// </summary>
        public void Process()
        {
            while (true)
            {
                switch (_currentState)
                {
                    case State.MainMenu:
                        ExecuteMainMenu();
                        break;
                    case State.BookCatalog:
                        ExecuteBookCatalog();
                        break;
                    case State.BookMenu:
                        ExecuteBookMenu();
                        break;
                    case State.AddToBucket:
                        ExecuteAddToBucket();
                        break;
                    case State.CommentCatalog:
                        ExecuteCommentCatalog();
                        break;
                    case State.CommentInput:
                        ExecuteCommentInput();
                        break;
                    case State.AddComment:
                        ExecuteAddComment();
                        break;
                    case State.Preview:
                        ExecutePreview();
                        break;
                    case State.BucketCatalog:
                        ExecuteBucket();
                        break;
                    case State.AddToUser:
                        ExecuteAddToUser();
                        break;
                    case State.UserCatalog:
                        ExecuteUserCatalog();
                        break;
                    case State.UserBookMenu:
                        ExecuteUserBookMenu();
                        break;
                    case State.BeautifyPrint:
                        ExecuteBeautifyPrint();
                        break;
                    case State.SimplePrint:
                        ExecuteSimplePrint();
                        break;
                    case State.PrintOutput:
                        ExecutePrintOutput();
                        break;
                    default: return;
                }
            }
        }

        private void ExecuteMainMenu()
        {
            var parameters = new ItemsParameters<string>()
            {
                Header = "Главное меню",
                Items = new List<string>()
                {
                    "Каталог книг",
                    "Корзина",
                    "Мои книги"
                }
            };

            _currentState = _states[State.MainMenu].Execute(parameters).State;
        }

        private void ExecuteBookCatalog()
        {
            var parameters = new ItemsParameters<Book>()
            {
                Header = "Каталог книг",
                Items = Storage.Instance.Books
            };

            var result = _states[State.BookCatalog].Execute(parameters);

            if (result is IdExecuteResult c)
            {
                _currentBookId = c.Id;
            }

            _currentState = result.State;
        }

        private void ExecuteBookMenu()
        {
            var parameters = new ItemsParameters<string>()
            {
                Header = Storage.Instance.Books.First(b => b.Id == _currentBookId).Name,
                Id = _currentBookId,
                Items = new List<string>()
                {
                    "Добавить в корзину",
                    "Комментарии",
                    "Превью"
                }
            };

            var result = _states[State.BookMenu].Execute(parameters);

            if (result is IdExecuteResult c)
            {
                _currentBookId = c.Id;
            }

            _currentState = result.State;
        }

        private void ExecuteAddToBucket()
        {
            new AddToBucketCommand().Execute(_currentBookId);

            _currentState = State.BookMenu;
        }

        private void ExecuteCommentCatalog()
        {
            var parameters = new ItemsParameters<string>()
            {
                Header = "Комментарии: " + Storage.Instance.Books.First(b => b.Id == _currentBookId).Name,
                Id = _currentBookId,
                Items = Storage.Instance.Comments.Where(comment => comment.BookId == _currentBookId).Select(comment => comment.Content).ToList()
            };

            var result = _states[State.CommentCatalog].Execute(parameters);

            if (result is IdExecuteResult c)
            {
                _currentBookId = c.Id;
            }

            _currentState = result.State;
        }

        private void ExecuteCommentInput()
        {
            var parameters = new BaseParameters()
            {
                Header = "Добавить комментарий: " + Storage.Instance.Books.First(b => b.Id == _currentBookId).Name,
                Id = _currentBookId,
            };

            var result = _states[State.CommentInput].Execute(parameters);

            if (result is TextInputResult c)
            {
                _currentBookId = c.Id;
                _buffer = c.Comment;
            }

            _currentState = result.State;
        }

        private void ExecuteAddComment()
        {
            new AddCommentCommand().Execute(new AddCommentContext() { BookId = _currentBookId, Input = _buffer });

            _currentState = State.CommentCatalog;
        }

        private void ExecutePreview()
        {
            var parameters = new OutputParameters()
            {
                Content = Storage.Instance.Books.First(b => b.Id == _currentBookId).Content.Substring(0, 11),
                Header = "Добавить комментарий: " + Storage.Instance.Books.First(b => b.Id == _currentBookId).Name,
                Id = _currentBookId,
            };

            var result = _states[State.Preview].Execute(parameters);

            _currentState = result.State;
        }

        private void ExecuteBucket()
        {
            if (Storage.Instance.Bucket.Count == 0)
            {
                _currentState = State.MainMenu;
                return;
            }

            var parameters = new ItemsParameters<string>()
            {
                Header = "Корзина",
                Items = Storage.Instance.Bucket.Select(b => b.Name).ToList()
            };

            var resut = _states[State.BucketCatalog].Execute(parameters);

            _currentState = resut.State;
        }

        private void ExecuteAddToUser()
        {
            new AddBookToUserCommand().Execute(null);

            _currentState = State.MainMenu;
        }

        private void ExecuteUserCatalog()
        {
            if (Storage.Instance.User.Count == 0)
            {
                _currentState = State.MainMenu;
                return;
            }

            var parameters = new ItemsParameters<Book>()
            {
                Header = "Мои книги",
                Items = Storage.Instance.User
            };

            var result = _states[State.UserCatalog].Execute(parameters);

            if (result is IdExecuteResult c)
            {
                _currentBookId = c.Id;
            }

            _currentState = result.State;
        }

        private void ExecuteUserBookMenu()
        {
            var parameters = new ItemsParameters<string>()
            {
                Header = Storage.Instance.User.First(b => b.Id == _currentBookId).Name,
                Id = _currentBookId,
                Items = new List<string>()
                {
                    "Распечатать красиво",
                    "Просто распечатать"
                }
            };

            var result = _states[State.UserBookMenu].Execute(parameters);

            if (result is IdExecuteResult c)
            {
                _currentBookId = c.Id;
            }

            _currentState = result.State;
        }

        private void ExecuteBeautifyPrint()
        {
            _buffer = Printer.BeautifyPrinter.Print(Storage.Instance.User.First(b => b.Id == _currentBookId));

            _currentState = State.PrintOutput;
        }

        private void ExecuteSimplePrint()
        {
            _buffer = Printer.SimplePrinter.Print(Storage.Instance.User.First(b => b.Id == _currentBookId));

            _currentState = State.PrintOutput;
        }

        private void ExecutePrintOutput()
        {
            var parameters = new OutputParameters()
            {
                Content = _buffer,
                Header = "Распечатано",
            };

            var result = _states[State.PrintOutput].Execute(parameters);

            _currentState = result.State;
        }
    }
}
