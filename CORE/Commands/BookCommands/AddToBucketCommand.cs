using System;
using System.Linq;
using CORE.Models;

namespace CORE.Commands.BookCommands
{
    /// <summary>
    /// Команда добавления книг в корзину
    /// </summary>
    public class AddToBucketCommand : ICommand<Guid>
    {
        public void Execute(Guid id)
        {
            Storage.Instance.AddBookToBucket(Storage.Instance.Books.First(b => b.Id == id));
        }
    }
}
