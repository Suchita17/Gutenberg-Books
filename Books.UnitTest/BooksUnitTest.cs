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
            string url = " https://gutendex.com/";
            var result = BookApiConsumer.GetDataFromApi(url);
            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void CheckIfResultObjAPIResponseIsNotNull()
        {
            string url = " https://gutendex.com/";
            var result = BookApiConsumer.GetDataFromApi(url);
            BookApiResult apiResult = Newtonsoft.Json.JsonConvert.DeserializeObject<BookApiResult>(result);
            Assert.IsTrue(apiResult.results != null);
        }

        [TestMethod]
        public void CheckIfBirthYearObjAPIResponseIsNotNull()
        {
            string url = " https://gutendex.com/";
            var result = BookApiConsumer.GetDataFromApi(url);
            BookApiResult apiResult = Newtonsoft.Json.JsonConvert.DeserializeObject<BookApiResult>(result);
            Assert.IsTrue(apiResult.results != null);
            for(int i= 0;i< apiResult.results.Length;i++)
            {
                Assert.IsNotNull(apiResult.results[i].authors[0].birth_year);
            }
        }

        [TestMethod]
        public void CheckIfAuthorNameObjAPIResponseIsNotNull()
        {
            string url = " https://gutendex.com/";
            var result = BookApiConsumer.GetDataFromApi(url);
            BookApiResult apiResult = Newtonsoft.Json.JsonConvert.DeserializeObject<BookApiResult>(result);
            Assert.IsTrue(apiResult.results != null);
            for (int i = 0; i < apiResult.results.Length; i++)
            {
                Assert.IsNotNull(apiResult.results[i].authors[0].Name);
            }
        }
    }
}
