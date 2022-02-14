using Newtonsoft.Json;
using RestSharp;
using System.IO;


namespace AutomatedAPITests
{
    public class APIHelper<T>
    {
        /* This class provides basic setup for RestAPI, like starting a restClient instance, */

        //Base URL and other constant values can be configured in app.config file rather than hard coding here
        public string baseURL = "https://cat-fact.herokuapp.com/facts";
        public RestClient restClient;
        public RestRequest restRequest;
        

        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine();
            var restClient = new RestClient(url);
            return restClient;
        }

        public void InstantiateRestClient()
        {
            restClient = new RestClient(baseURL);
        }

        public RestRequest CreatePostRequest(string endpoint, string payload)
        {
            var restRequest = new RestRequest(endpoint, Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreateGetRequest(string endpoint)
        {
            var restRequest = new RestRequest(endpoint, Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest restRequest)
        {
            return client.Execute(restRequest);
        }

        public RestRequest GetCatsFactsList(string queryParameters)
        {
            InstantiateRestClient();
            return CreateGetRequest(queryParameters);
        }

        public RestRequest GetACatFact(string id)
        {
            InstantiateRestClient();
            return CreateGetRequest("/" + id);
        }

        public IRestResponse GetRestResponse(RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }

        public DTO GetDeserialisedResponseContect<DTO>(IRestResponse restResponse)
        {
            var content = restResponse.Content;
            var responseDTO = JsonConvert.DeserializeObject<DTO>(content);
            return responseDTO;
        }

        public object GetDeserialisedResponseContect(IRestResponse restResponse)
        {
            var content = restResponse.Content;
            return JsonConvert.DeserializeObject(content);
        }
    }

}
