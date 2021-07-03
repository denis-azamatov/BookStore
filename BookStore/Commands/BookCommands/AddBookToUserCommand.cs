using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Commands.BookCommands
{
    /// <summary>
    /// Комманда добавления книг в каталог клиента и удаления из корзины
    /// </summary>
    public class AddBookToUserCommand : ICommand<object>
    {
        public string Name => "Купить книги";

        public void Execute(object context)
        {
            Storage.Instance.AddBookToUser();
        }
    }
}
