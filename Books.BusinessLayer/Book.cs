using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BusinessLayer
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Author[] authors;

    }
}
