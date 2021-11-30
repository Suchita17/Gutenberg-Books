using System;
using System.Collections.Generic;
using System.Text;

namespace Books.BusinessLayer
{
    public class BookApiResult
    {
        public int count { get; set; }
        public string next { get; set; }

        public string previous { get; set; }

        public Book[] results;
    }
}
