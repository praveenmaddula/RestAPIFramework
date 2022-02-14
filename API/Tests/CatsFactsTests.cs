using AutomatedAPITests.TestData;
using AutomatedAPITests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using static AutomatedAPITests.TestData.TestDataForCatFacts;

namespace AutomatedAPITests
{
    [TestClass]
    public class CatsFactsTests
    {
        [TestMethod]
        public void VerifyBasicAPIResponse()
        {
            string queryParameters = "?animal_type = cat";
            APIHelper<Task> apiHelper = new APIHelper<Task>();
            var request = apiHelper.GetCatsFactsList(queryParameters);

            var response = apiHelper.GetRestResponse(request);
            Assert.AreEqual("OK", response.StatusDescription);
            Assert.AreEqual(200, response.StatusCode); //Failing - Expected status code is 200 but received OK
        }

        [TestMethod]
        public void Verify_WrongQueryReturnsAnErrorMessage()
        {
            string queryParameters = "?animal_type = %$@%$#%$@%$";
            APIHelper<Task> apiHelper = new APIHelper<Task>();
            var request = apiHelper.GetCatsFactsList(queryParameters);

            var response = apiHelper.GetRestResponse(request);
            Assert.AreEqual("Bad Request", response.StatusDescription);
            Assert.AreEqual(400, response.StatusCode); //Failing test - Expected bad request-400 due to providing wrong Query Parameters
        }


        [TestMethod, TestCategory("Regression")]
        public void VerifyListOfCatFactsReturnedAreCorrect()
        {
            string queryParameters = "?animal_type = cat";
            APIHelper<Task> apiHelper = new APIHelper<Task>();
            var request = apiHelper.GetCatsFactsList(queryParameters);

            var response = apiHelper.GetRestResponse(request);
            var catsFactsResponse = JsonConvert.DeserializeObject<List<CatsFactsResponse>>(response.Content);

            //Testing the 1st response object
            Assert.AreEqual(true, catsFactsResponse[0].status.verified);

            Assert.AreEqual(FirstIdDetails.user, catsFactsResponse[0].user);
            Assert.AreEqual(FirstIdDetails.id, catsFactsResponse[0]._id);
            Assert.AreEqual(FirstIdDetails.fact, catsFactsResponse[0].text);

            //Testing the 2nd response object
            Assert.AreEqual(true, catsFactsResponse[1].status.verified);

            Assert.AreEqual(SecondIdDetails.user, catsFactsResponse[1].user);
            Assert.AreEqual(SecondIdDetails.id, catsFactsResponse[1]._id);
            Assert.AreEqual(SecondIdDetails.fact, catsFactsResponse[1].text);

            //Testing the 3rd response object
            Assert.AreEqual(true, catsFactsResponse[2].status.verified);

            Assert.AreEqual(ThirdIdDetails.user, catsFactsResponse[2].user);
            Assert.AreEqual(ThirdIdDetails.id, catsFactsResponse[2]._id);
            Assert.AreEqual(ThirdIdDetails.fact, catsFactsResponse[2].text);

            //Testing the 4th response object
            Assert.AreEqual(true, catsFactsResponse[4].status.verified);

            Assert.AreEqual(FourthIdDetails.user, catsFactsResponse[3].user);
            Assert.AreEqual(FourthIdDetails.id, catsFactsResponse[3]._id); //Failing here for mismatching IDs
            Assert.AreEqual(FourthIdDetails.fact, catsFactsResponse[3].text);//Failing

            //Testing the 5th response object
            Assert.AreEqual(true, catsFactsResponse[4].status.verified);

            Assert.AreEqual(FifthIdDetails.user, catsFactsResponse[4].user);
            Assert.AreEqual(FifthIdDetails.id, catsFactsResponse[4]._id);//Failing
            Assert.AreEqual(FifthIdDetails.fact, catsFactsResponse[4].text);//Failing

            //Testing the 5th response object
            Assert.AreEqual(true, catsFactsResponse[5].status.verified);

            Assert.AreEqual(SixthIdDetails.user, catsFactsResponse[5].user);
            Assert.AreEqual(SixthIdDetails.id, catsFactsResponse[5]._id);
            Assert.AreEqual(SixthIdDetails.fact, catsFactsResponse[5].text);
        }

        [TestMethod, TestCategory("Smoke")]
        public void Verify_CatFactResponseDetailsForFirstID_AreCorrect()
        {
            string FactId = "58e008800aac31001185ed07";

            APIHelper<Task> apiHelper = new APIHelper<Task>();
            var request = apiHelper.GetACatFact(FactId);

            var response = apiHelper.GetRestResponse(request);
            var singleCatFactResponse = apiHelper.GetDeserialisedResponseContect<SingleCatFactResponse>(response);
            Assert.AreEqual(FactId, singleCatFactResponse.Id);
            Assert.AreEqual(FirstIdDetails.user, singleCatFactResponse.User.Id);
            Assert.AreEqual(FirstIdDetails.fact, singleCatFactResponse.Text);
            Assert.AreEqual(firstName, singleCatFactResponse.User.Name.First);
            Assert.AreEqual(lastName, singleCatFactResponse.User.Name.Last);
        }

        [TestMethod, TestCategory("Smoke")]
        public void Verify_CatFactResponseDetailsForSecondID_AreCorrect()
        {
            string FactId = "58e008630aac31001185ed01";

            APIHelper<Task> apiHelper = new APIHelper<Task>();
            var request = apiHelper.GetACatFact(FactId);

            var response = apiHelper.GetRestResponse(request);
            var singleCatFactResponse = apiHelper.GetDeserialisedResponseContect<SingleCatFactResponse>(response);
            Assert.AreEqual(FactId, singleCatFactResponse.Id);
            Assert.AreEqual(SecondIdDetails.user, singleCatFactResponse.User.Id);
            Assert.AreEqual(SecondIdDetails.fact, singleCatFactResponse.Text);
            Assert.AreEqual(firstName, singleCatFactResponse.User.Name.First);
            Assert.AreEqual(lastName, singleCatFactResponse.User.Name.Last);
        }

        [TestMethod, TestCategory("Smoke")]
        public void Verify_CatFactResponseDetailsForThirdID_AreCorrect()
        {
            string FactId = "58e00a090aac31001185ed16";

            APIHelper<Task> apiHelper = new APIHelper<Task>();
            var request = apiHelper.GetACatFact(FactId);

            var response = apiHelper.GetRestResponse(request);
            var singleCatFactResponse = apiHelper.GetDeserialisedResponseContect<SingleCatFactResponse>(response);
            Assert.AreEqual(FactId, singleCatFactResponse.Id);
            Assert.AreEqual(ThirdIdDetails.user, singleCatFactResponse.User.Id);
            Assert.AreEqual(ThirdIdDetails.fact, singleCatFactResponse.Text);
            Assert.AreEqual(firstName, singleCatFactResponse.User.Name.First);
            Assert.AreEqual(lastName, singleCatFactResponse.User.Name.Last);
        }

        [TestMethod, TestCategory("Smoke")] //Failing test case as this ID does not exist
        public void Verify_CatFactResponseDetailsForFourthID_AreCorrect()
        {
            string FactId = "58e009a90aac31001185ed23";

            APIHelper<Task> apiHelper = new APIHelper<Task>();
            var request = apiHelper.GetACatFact(FactId);

            var response = apiHelper.GetRestResponse(request);
            var singleCatFactResponse = apiHelper.GetDeserialisedResponseContect<SingleCatFactResponse>(response);
            Assert.AreEqual(FactId, singleCatFactResponse.Id);
            Assert.AreEqual(FourthIdDetails.user, singleCatFactResponse.User.Id);
            Assert.AreEqual(FourthIdDetails.fact, singleCatFactResponse.Text);
            Assert.AreEqual(firstName, singleCatFactResponse.User.Name.First);
            Assert.AreEqual(lastName, singleCatFactResponse.User.Name.Last);
        }

        [TestMethod, TestCategory("Smoke")]
        public void Verify_CatFactResponseDetailsForFifthID_AreCorrect()
        {
            string FactId = "58e009390aac31001185ed10";

            APIHelper<Task> apiHelper = new APIHelper<Task>();
            var request = apiHelper.GetACatFact(FactId);

            var response = apiHelper.GetRestResponse(request);
            var singleCatFactResponse = apiHelper.GetDeserialisedResponseContect<SingleCatFactResponse>(response);
            Assert.AreEqual(FactId, singleCatFactResponse.Id);
            Assert.AreEqual(FifthIdDetails.user, singleCatFactResponse.User.Id);
            Assert.AreEqual(FifthIdDetails.fact, singleCatFactResponse.Text);
            Assert.AreEqual(firstName, singleCatFactResponse.User.Name.First);
            Assert.AreEqual(lastName, singleCatFactResponse.User.Name.Last);
        }

        [TestMethod, TestCategory("Smoke")]
        public void Verify_CatFactResponseDetailsForSixthID_AreCorrect()
        {
            string FactId = "58e008780aac31001185ed05";

            APIHelper<Task> apiHelper = new APIHelper<Task>();
            var request = apiHelper.GetACatFact(FactId);

            var response = apiHelper.GetRestResponse(request);
            var singleCatFactResponse = apiHelper.GetDeserialisedResponseContect<SingleCatFactResponse>(response);
            Assert.AreEqual(FactId, singleCatFactResponse.Id);
            Assert.AreEqual(SixthIdDetails.user, singleCatFactResponse.User.Id);
            Assert.AreEqual(SixthIdDetails.fact, singleCatFactResponse.Text);
            Assert.AreEqual(firstName, singleCatFactResponse.User.Name.First);
            Assert.AreEqual(lastName, singleCatFactResponse.User.Name.Last);
        }

        [TestMethod, TestCategory("Smoke")] //This test can be repeated for all other responses
        public void Verify_SingleCatFactWithwrongURL_ShouldReturn404()
        {
            string FactId = "58e008780aac31001185ed05/wewtte";

            APIHelper<Task> apiHelper = new APIHelper<Task>();
            var request = apiHelper.GetACatFact(FactId);

            var response = apiHelper.GetRestResponse(request);
            Assert.AreEqual(404, response.StatusDescription);
        }

        /*Other types of tests that can be done - I am only taking in to consideration GET methods for the end points here as others are out of scope
         1. Passing in http instead of https
         2. Passig wrong method types - Post instead of GET, etc
         3. Passing in wrong content type
         4. Passing in multiple types of query parameters
         5. Passing the wrong URL for end points

           ***************** Can also set up some mocks for testing 500, 403 and other errors *************
         */
    }
}
