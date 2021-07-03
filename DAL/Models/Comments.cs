using System;

namespace DAL.Models
{
    /// <summary>
    /// Комментарий
    /// </summary>
    public class Comments
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }

        public string Text { get; set; }
    }
}
