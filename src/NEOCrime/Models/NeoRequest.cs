using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace NEOCrime.Models
{
    public class NeoRequest
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public NeoRequest(string start, string end)
        {
            StartDate = start;
            EndDate = end;
        }
        public JObject GetNeoList()
        {
            RestClient client = new RestClient("https://api.nasa.gov/neo/rest/v1/feed");
            RestRequest request = new RestRequest($"?start_date={StartDate}&end_date={EndDate}&api_key={EnvironmentVariables.NasaKey}", Method.GET);
            RestResponse response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);

            return jsonResponse;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
