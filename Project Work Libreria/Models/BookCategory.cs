﻿namespace Project_Work_Libreria.Models
{
    public class BookCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }

        public BookCategory() { }

        public BookCategory(string name)
        {
            Name = name;
            Books = new();
        }
    }
}
