using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
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
