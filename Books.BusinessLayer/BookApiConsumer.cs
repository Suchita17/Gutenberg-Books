using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using static Books.BusinessLayer.BookList;

namespace Books.BusinessLayer
{
    public class BookApiConsumer
    {
        //Get All Records from Api based on Book and Author Name
        public CreateList<string> GetAllData()
        {

            CreateList<string> linkedlist = new CreateList<string>();
            string result = string.Empty;
            string baseUrl = ConfigurationManager.AppSettings["GutendexBaseUrl"].ToString();
            result = GetDataFromApi(baseUrl);
            if (!string.IsNullOrEmpty(result))
            {
                BookApiResult apiResult = Newtonsoft.Json.JsonConvert.DeserializeObject<BookApiResult>(result);

                if (apiResult != null)
                {
                    apiResult.results.ToList().ForEach(book =>
                    {
                        book.authors.ToList().ForEach(author =>
                        {
                            linkedlist.add(author.birth_year, author.Name);
                        });
                    });
                }
            }

            return linkedlist;

        }

        //Get Api Results
        public static string GetDataFromApi(string url)
        {

            string result;
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                StringBuilder path = new StringBuilder();
                path.Append(url).Append("books/?author_year_start=1900&author_year_end=1901&languages=en");
                result = client.DownloadString(path.ToString());
            }
            return result;
        }

    }

}

