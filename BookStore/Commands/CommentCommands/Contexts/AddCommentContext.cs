using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Commands.CommentCommands.Contexts
{
    /// <summary>
    /// Контекст добавления комментария
    /// </summary>
    public class AddCommentContext
    {
        public string Text { get; set; }

        public Book Book { get; set; }
    }
}
