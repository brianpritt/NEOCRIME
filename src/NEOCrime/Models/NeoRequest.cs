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
        public string TargetDate { get; set; }

        public NeoRequest(string target)
        {
            TargetDate = target;
        }
        public List<NeoResult.RootObject> GetNeoList()
        {
            RestClient client = new RestClient("https://api.nasa.gov/neo/rest/v1/feed");
            RestRequest request = new RestRequest($"?start_date={TargetDate}&end_date={TargetDate}&api_key={EnvironmentVariables.NasaKey}", Method.GET);
            RestResponse response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            JObject jsonResponse1 = JsonConvert.DeserializeObject<JObject>(jsonResponse["near_earth_objects"].ToString());
            List<NeoResult.RootObject> newNeoList = JsonConvert.DeserializeObject<List<NeoResult.RootObject>>(jsonResponse1[TargetDate].ToString()); 
            Console.WriteLine(newNeoList[0]);

            return newNeoList;
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
