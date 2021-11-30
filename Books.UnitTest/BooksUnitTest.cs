using Books.BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Books.UnitTest
{
    [TestClass]
    public class BooksUnitTest
    {
        [TestMethod]
        public void CheckIfApiResponseIsNotNull()
        {
            //string a = ConfigurationManager.AppSettings["GutendexBaseUrl"].ToString();
            string url = " https://gutendex.com/";
            var result = BookApiConsumer.GetDataFromApi(url);
            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void CheckIfResultObjAPIResponseIsNotNull()
        {
            //string a = ConfigurationManager.AppSettings["GutendexBaseUrl"].ToString();
            string url = " https://gutendex.com/";
            var result = BookApiConsumer.GetDataFromApi(url);
            BookApiResult apiResult = Newtonsoft.Json.JsonConvert.DeserializeObject<BookApiResult>(result);
            Assert.IsTrue(apiResult.results != null);
        }
        //[TestMethod] //json 
        //public void CheckifGetdataIsNotNull()
        //{
        //    var result = BookApiConsumer.GetDataFromApi();
        //    Assert.IsTrue(!string.IsNullOrEmpty(result));
        //}
    }
}
