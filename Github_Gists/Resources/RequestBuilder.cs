using Github_Gists.Utils;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Github_Gists.Resources
{
    class RequestBuilder
    {
        public Dictionary<string, string> AddHeaders(IEnumerable<RequestParams> requestParameters, TestConfig test)
        {
            //Creates, builds and returns headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            foreach (var requestParameter in requestParameters)
            {
                //Empty string represent header to be taken from json
                if (requestParameter.value == "" && requestParameter.parameter.Contains("Authorization"))
                    headers.Add(requestParameter.parameter, test.authorization);
                else
                    headers.Add(requestParameter.parameter, requestParameter.value);
            }
            return headers;
        }

        public JsonObject AddRequestBody(IEnumerable<RequestParams> requestParameters)
        {
            //Creates, builds and returns request body as json object
            JsonObject jsonRequestBody = new JsonObject();
            foreach (var requestParameter in requestParameters)
            {
                jsonRequestBody.Add(requestParameter.parameter, requestParameter.value);
            }
            return jsonRequestBody;
        }
    }
}
