using System;
using Ui.MenuFsm.Parameters;
using Ui.MenuFsm.Results;

namespace Ui.MenuFsm.States
{
    public class CommentInput : IState
    {
        private bool _changeState;

        private string _buffer = string.Empty;

        private string _header;

        private Guid _id;

        public ExecuteResult Execute(object v)
        {
            var parameters = v as BaseParameters;

            _header = parameters.Header;

            _id = parameters.Id;

            _buffer = string.Empty;

            var render = true;
            while (render)
            {
                Render();

                render = HandleInput();
            }

            if (!_changeState)
            {
                return new ExecuteResult { State = State.CommentCatalog };
            }

            return new TextInputResult() { Id = _id, State = State.AddComment, Comment = _buffer };
        }

        private void Render()
        {
            Console.Clear();

            var headerPoint = Console.WindowWidth / 2 - _header.Length / 2;
            Console.WriteLine(new string(' ', headerPoint) + _header);

            Console.WriteLine("Введите комментарий:");

            if (_buffer != string.Empty)
            {
                Console.WriteLine(_buffer);
                Console.WriteLine("Нажмите Enter чтобы отправить или Backspace чтобы отменить");
            }
        }

        private bool HandleInput()
        {
            if (_buffer == string.Empty)
            {
                _buffer = Console.ReadLine();

                Console.WriteLine("Нажмите Enter чтобы отправить или Backspace чтобы отменить");
            }

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
