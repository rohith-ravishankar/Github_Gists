using RestSharp;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Github_Gists.Resources
{
    public class GistResource
    {
        public RestResponse GetGistResponse(string host, Dictionary<string, string> headers, Dictionary<string, string> queryParameters)
        {
            //Takes header and query parameters, builds the request and returns the GET response
            var client = new RestClient(host);
            var request = new RestRequest();
            if (headers != null)
                request.AddHeaders(headers);
            if (queryParameters != null)
            {
                foreach (var queryParameter in queryParameters.Keys)
                {
                    request.AddQueryParameter(queryParameter, queryParameters[queryParameter]);
                }
            }
            Task<RestResponse> response = client.ExecuteGetAsync(request);
            return response.Result;
        }

        public RestResponse PostGistResponse(string host, Dictionary<string, string> headers, Dictionary<string, string> queryParameters, JsonObject requestBody)
        {
            //Takes header, body and query parameters, builds the request and returns the POST response
            var client = new RestClient(host);
            var request = new RestRequest();
            if (headers != null)
                request.AddHeaders(headers);
            if (queryParameters != null)
            {
                foreach (var queryParameter in queryParameters.Keys)
                {
                    request.AddQueryParameter(queryParameter, queryParameters[queryParameter]);
                }
            }
            if (requestBody != null)
                request.AddJsonBody(requestBody);
            Task<RestResponse> response = client.ExecutePostAsync(request);
            return response.Result;
        }
    }
}
