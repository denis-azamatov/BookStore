using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    /// <summary>
    /// Книга
    /// </summary>
    public class Book
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public Genre Genre { get; set; }
    }
}
