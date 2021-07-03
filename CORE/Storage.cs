using System.Collections.Generic;
using CORE.Models;

namespace CORE
{
    public class Storage
    {
        #region Singleton
        private static Storage _instance;

        public static Storage Instance => _instance ??= new Storage();

        private Storage() { }
        #endregion

        public List<Book> Books { get; } = new();

        public List<Comment> Comments { get; } = new();

        public List<Book> Bucket { get; } = new();

        public List<Book> User { get; } = new();

        public void AddBook(Book book) => Books.Add(book);

        public void AddBookToBucket(Book book) => Bucket.Add(book);

        public void AddBookToUser()
        {
            for (int i = 0; i < Bucket.Count; i++)
            {
                User.Add(Bucket[i]);
            }
            Bucket.Clear();
        }

        public void AddComment(Comment comment) => Comments.Add(comment);
    }
}
