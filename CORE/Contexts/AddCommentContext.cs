using System;
using CORE.Models;

namespace CORE.Contexts
{
    /// <summary>
    /// Контекст добавления комментария
    /// </summary>
    public class AddCommentContext
    {
        public Guid BookId { get; set; }

        public string Input { get; set; }
    }
}
