using System;
using CORE.Contexts;
using CORE.Models;

namespace CORE.Commands.CommentCommands
{
    /// <summary>
    /// Команда добавления комментария к книге
    /// </summary>
    public class AddCommentCommand : ICommand<AddCommentContext>
    {
        public void Execute(AddCommentContext context)
        {
            Storage.Instance.AddComment(new Comment() { BookId = context.BookId, Content = context.Input, Id = Guid.NewGuid() });
        }
    }
}
