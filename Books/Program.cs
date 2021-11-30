using Books.BusinessLayer;
using System;
using System.Net;
using System.Net.Http;
using static Books.BusinessLayer.BookList;

namespace Books
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //fetching the data from web api
                BookApiConsumer apiConsume = new BookApiConsumer();
                var list = apiConsume.GetAllData();
                list.sortList();
                Console.WriteLine("Sorted authors:");
                list.display();
                //Export the authors in sort order as a CSV file
                list.ExportCSV();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
        }
    }
}
