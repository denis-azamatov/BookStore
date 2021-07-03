using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Commands.BookCommands
{
    /// <summary>
    /// Команда добавления книг в корзину
    /// </summary>
    public class AddToBucketCommand : ICommand<Book>
    {
        public string Name => "Добавить в корзину";

        public void Execute(Book book)
        {
            Storage.Instance.AddBookToBucket(book);
        }
    }
}
