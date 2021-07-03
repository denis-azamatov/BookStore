using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore
{
    public class Storage
    {
        #region Singleton
        private static Storage _instance;

        public static Storage Instance => _instance ??= new Storage();

        private Storage() { }
        #endregion

        public List<Book> books { get; } = new();

        public List<Comment> comments { get; } = new();

        public List<Book> bucket { get; } = new();

        public List<Book> user { get; } = new();

        public void AddBook(Book book) => books.Add(book);

        public void AddBookToBucket(Book book) => bucket.Add(book);

        public void AddBookToUser()
        {
            for (int i = 0; i < bucket.Count; i++)
            {
                user.Add(bucket[i]);
            }
            bucket.Clear();
        }

        public void AddComment(Comment comment) => comments.Add(comment);
    }
}
