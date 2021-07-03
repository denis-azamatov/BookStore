using System;

namespace CORE.Models
{
    /// <summary>
    /// Комментарий
    /// </summary>
    public class Comment
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }

        public string Content { get; set; }
    }
}
