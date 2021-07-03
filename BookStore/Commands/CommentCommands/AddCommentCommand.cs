using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Commands.CommentCommands.Contexts;
using BookStore.Models;

namespace BookStore.Commands.CommentCommands
{
    /// <summary>
    /// Команда добавления комментария к книге
    /// </summary>
    public class AddCommentCommand : ICommand<AddCommentContext>
    {
        public string Name => "Добавить комментарий";

        public void Execute(AddCommentContext context)
        {
            Storage.Instance.AddComment(new Comment() { BookId = context.Book.Id, Content = context.Text, Id = Guid.NewGuid() });
        }
    }
}
