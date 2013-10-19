using _02.InformationalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02.InformationalApp.Models
{
    public static class Data
    {
        public static List<Category> Categories = new List<Category>()
        {
            new Category() { Id =1, Name = "Fiction" },
            new Category() { Id=2, Name = "Non-fiction"}
        };

        public static List<Author> Authors = new List<Author>()
        {
            new Author() { Id = 1, Name = "Ivan Vazov" },
            new Author() { Id= 2, Name = "Elin Pelin" },
            new Author() { Id=3, Name = "Nakov" },
            new Author() { Id = 4, Name = "Steven Levitt" }
        };

        public static List<Book> Books = new List<Book>()
        {
            new Book() { Id = 1, Name = "Under the Yoke", CategoryId = 1, AuthorId =  1 },
            new Book() { Id = 2, Name = "New Land", CategoryId = 1, AuthorId =   1 },
            new Book() { Id = 3, Name = "Ian Bibian", CategoryId = 1, AuthorId =  2 },
            new Book() { Id = 4, Name = "C# Programming", CategoryId = 2, AuthorId =  3 },
            new Book() { Id = 5, Name = "Java Programming", CategoryId = 2, AuthorId = 3 },
            new Book() { Id = 6, Name = "Freakonomics", CategoryId = 2, AuthorId =  4 }
        };
    }
}