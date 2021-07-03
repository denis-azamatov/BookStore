using System;
using System.Collections.Generic;
using CORE.Models;

namespace CORE.Setup
{
    public static class Setup
    {
        public static void FillStorage()
        {
            var books = GetBooks();

            foreach (var book in books)
            {
                Storage.Instance.AddBook(book);
            }
        }

        private static List<Book> GetBooks()
        {
            return new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Author = "Пушкин",
                    Name = "Сказка о Золотой рыбке",
                    Content = "Это превью. А это весь контент.",
                    Genre = Genre.FairyTale
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Author = "Дж. Роулинг",
                    Name = "Гарри Поттер и Тайная комната",
                    Content = "Это превью. А это весь контент.",
                    Genre = Genre.Fantasy
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Author = "Дж. Роулинг",
                    Name = "Гарри Поттер и Узник Азкабана",
                    Content = "Это превью. А это весь контент.",
                    Genre = Genre.Fantasy
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Author = "Дж. Роулинг",
                    Name = "Гарри Поттер и Кубок огня",
                    Content = "Это превью. А это весь контент.",
                    Genre = Genre.Fantasy
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Author = "Филип К. Дик",
                    Name = "Мечтают ли андроиды об электроовцах",
                    Content = "Это превью. А это весь контент.",
                    Genre = Genre.Science
                }
            };
        }
    }
}
